using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Services.Description;
using System.Web.UI;
using System.Windows;
using Agenda.Web.ViewModels;
using AgendaOnline.Dominio;
using AgendaOnline.Dominio.Interfaces;
using AgendaOnline.Dominio.Negocios;
using Microsoft.VisualBasic;

namespace Agenda.Web.Controllers
{
   
    public class ClienteController : Controller
    {
        private ClienteNegocios _clienteNegocios = new ClienteNegocios();
        private TelefoneNegocios _telefoneNegocios = new TelefoneNegocios();
        // GET: Cliente


        public ActionResult Index()
        {
            //este metodo retorna para a view index os clientes listados 
            var clientes = _clienteNegocios.ListarTodos();
            return View(clientes);
        }


        //no posto o valor selecionado do dropdawnlist
        //sera recebido no parametr IDCLIENTE
        [HttpGet]
        public ActionResult Inserir()
        {
            //sempre colocar o combo box nos metodos get para serem criados antes de serem postados
            //criar uma view para listagem de cada combo box 
            TipoClienteNegocios tipoCliente = new TipoClienteNegocios();
            CboNegocios cbo = new CboNegocios();
            CidadeNegocios cidade = new CidadeNegocios();

            ViewBag.TipoCliente = new SelectList(tipoCliente.ListarTodos(), "IDTIPO", "TIPO");
            ViewBag.Cbo = new SelectList(cbo.ListarTodos(), "IDCBO", "PROFISSAO");
            ViewBag.Cidade = new SelectList(cidade.ListarTodos(), "IDCIDADE", "CIDADE");
            return View();
        }
        //usado para indicar que ao clicar no botão, ele ira pegar todos os dados e criar um modelo
        //passando como parametro no metodo inserir
        [HttpPost]
        public ActionResult Inserir(ClienteViewModel model,int TipoCliente, int Cbo, int Cidade)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Cliente cliente = new Cliente
            {
                NOME = model.NOME,
                SOBRENOME = model.SOBRENOME,
                CPF_CNPJ = model.CPF_CNPJ,
                CONJUGE = model.CONJUGE,
                ID_TIPO = TipoCliente,
                ID_CBO = Cbo,
                ID_CIDADE = Cidade
            };
            ClienteNegocios clienteaux = new ClienteNegocios();
            string cpfCliente = clienteaux.BuscarCpf(cliente.CPF_CNPJ);

            //se o CPF for nulo o cliente nao existe no banco, logo ele pode ser inserido
            if (cpfCliente == null)
            {
                //para passarmos o idCliente para a outra view de cadastro de telefones 
                //criamos um cliente auxiliar para buscar o id do cliente que acabou de ser salvo no banco
                _clienteNegocios.Salvar(cliente);
                Cliente aux = new Cliente();
                aux = clienteaux.ListarCliente(cliente.CPF_CNPJ);
                int idCliente = aux.IDCLIENTE;
                return RedirectToAction("InserirTelefone",new RouteValueDictionary(new { Controller="Telefone",Action= "InserirTelefone", id = aux.IDCLIENTE  }));
            }
            //se o cliente ja estiver cadastrado, printar na tela mensagem para o usuario..
            return View();
            //apos cadastrar o cliente, o usuario ira ser redirecionado para a view index
        }
        [HttpGet]
        public ActionResult ConsultarCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ConsultarCliente(string cpf)
        {
            var cliente = _clienteNegocios.BuscarId(cpf);
            if (cliente == null)
            {
                return View();
            }
            return View("Detalhes",new ClienteViewModel(cliente));
        }

        [HttpGet]
        public ActionResult Detalhes(int id)
        {
            var cliente = _clienteNegocios.BuscarId(id);
            return View(new ClienteViewModel(cliente));
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            TipoClienteNegocios tipoCliente = new TipoClienteNegocios();
            CboNegocios cbo = new CboNegocios();
            CidadeNegocios cidade = new CidadeNegocios();
            var cliente = _clienteNegocios.BuscarId(id);
            ViewBag.TipoCliente = new SelectList(tipoCliente.ListarTodos(), "IDTIPO", "TIPO",cliente.ID_TIPO);
            ViewBag.Cbo = new SelectList(cbo.ListarTodos(), "IDCBO", "PROFISSAO",cliente.ID_CBO);
            ViewBag.Cidade = new SelectList(cidade.ListarTodos(), "IDCIDADE", "CIDADE",cliente.ID_CIDADE);

            return View(new ClienteViewModel(cliente));
        }

        [HttpPost]

        public ActionResult Editar(ClienteViewModel model,int id, int TipoCliente, int Cbo, int Cidade)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var cliente = new Cliente
            {
                IDCLIENTE = id,
                NOME = model.NOME,
                CPF_CNPJ = model.CPF_CNPJ,
                SOBRENOME = model.SOBRENOME,
                CONJUGE = model.CONJUGE,
                ID_TIPO = TipoCliente,
                ID_CBO = Cbo,
                ID_CIDADE = Cidade
            };

            _clienteNegocios.Alterar(cliente);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            var cliente = _clienteNegocios.BuscarId(id);
            return View(new ClienteViewModel(cliente));
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(int id)
        {
        
            if (_clienteNegocios.BuscarAgendamento(id) == 0) {
                var telefone = _telefoneNegocios.BuscarIdTelefone(id);
                var cliente = _clienteNegocios.BuscarId(id);
                _telefoneNegocios.Deletar(telefone);
                _clienteNegocios.Deletar(cliente);
                // nao podemos utilizar return view pois nao passamaos nenhum parametro para a INDEX
                return RedirectToAction("Index");
            }
            else
            {
                Interaction.MsgBox("Nao e possivel excluir clientes com agendamentos!", MsgBoxStyle.OkOnly, "AVISO");           
                return RedirectToAction("Index");
            }
        }
      

    }
}