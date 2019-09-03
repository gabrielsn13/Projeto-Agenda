using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Agenda.Web.ViewModels;
using AgendaOnline.Dominio;
using AgendaOnline.Dominio.Interfaces;
using AgendaOnline.Dominio.Negocios;
using Microsoft.VisualBasic;

namespace Agenda.Web.Controllers
{
    public class AgendamentoController : Controller
    {
        private AgendamentoNegocios _agendamentoNegocios = new AgendamentoNegocios();
        private SalaNegocios _salasNegocios = new SalaNegocios();

        public ActionResult ListaAgendamentos()
        {
            //este metodo retorna para a view index os clientes listados 
            var agendamentos = _agendamentoNegocios.ListarAgendamentos();
            return View(agendamentos);
        }

        [HttpGet]
        public ActionResult CadastrarAgendamento()
        {
            //sempre colocar o combo box nos metodos get para serem criados antes de serem postados
            //criar uma view para listagem de cada combo box 
            SalaNegocios sala = new SalaNegocios();
            ClienteNegocios cliente = new ClienteNegocios();

            ViewBag.Salas = new SelectList(sala.ListarSalas(), "IDSALA", "SALA");
            ViewBag.Clientes = new SelectList(cliente.ListarTodos(), "IDCLIENTE", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarAgendamento(AgendamentoViewModel model, int Clientes,int Salas)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (_salasNegocios.BuscarId(Salas).ID_STATUS == 1) {
                Agendamento agendamento = new Agendamento
                {
                    TITULO = model.TITULO,
                    ID_SALA = Salas,
                    ID_CLIENTE = Clientes,
                    DATA = DateTime.Now,
                    OBSERVACOES = model.OBSERVACOES
                };
                _agendamentoNegocios.Salvar(agendamento);
                var salaAux = _salasNegocios.BuscarId(Salas);
                var sala = new Sala
                {
                    IDSALA = salaAux.IDSALA,
                    SALA = salaAux.SALA,
                    ID_STATUS = 2
                };
                _salasNegocios.Alterar(sala);
                return RedirectToAction("ListaAgendamentos", new RouteValueDictionary(new { Controller = "Agendamento", Action = "ListaAgendamentos" }));
            }
            else
            {
                Interaction.MsgBox("Sala indisponível !", MsgBoxStyle.OkOnly, "AVISO");             
                return RedirectToAction("CadastrarAgendamento");
            }
        }
        [HttpGet]
        public ActionResult ExcluirAgendamento(int id)
        {
            var agendamento = _agendamentoNegocios.BuscarId(id);
            return View(new AgendamentoViewModel(agendamento));
        }

        [HttpPost, ActionName("ExcluirAgendamento")]
        public ActionResult ExcluirAgendamentoConfirma(int id)
        {
                
            var agendamento = _agendamentoNegocios.BuscarId(id);
            var salaAux = _salasNegocios.BuscarId(_agendamentoNegocios.BuscarId(id).ID_SALA);
            var sala = new Sala
            {
                IDSALA = salaAux.IDSALA,
                SALA = salaAux.SALA,
                ID_STATUS = 1
            };
            _agendamentoNegocios.Deletar(agendamento);
            _salasNegocios.Alterar(sala);
            // nao podemos utilizar return view pois nao passamaos nenhum parametro para a INDEX
            return RedirectToAction("ListaAgendamentos");
        }
    }
}