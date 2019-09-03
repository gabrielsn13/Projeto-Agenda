using AgendaOnline.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Agenda.Web.ViewModels
{
    public class ClienteViewModel
    {
        //obs.: como forma de boa pratica, as validaçoes nao sao feitas direto na classe Cliente, por ser uma classe 
        //da entidade. Logo criamos ClienteViewModel para realizar tais validaçoes
        public int IDCLIENTE { get; set; }
        public string CPF_CNPJ { get; set; }
        //Validação informando que o campo 'nome' é necessario
        [Required(ErrorMessage = " * Campo obrigatório")]
        public string NOME { get; set; }
        [Required(ErrorMessage = " * Campo obrigatório")]
        public string SOBRENOME { get; set; }
        [Required(ErrorMessage = " * Campo obrigatório")]
        public string CONJUGE { get; set; }
        [Required(ErrorMessage = " * Campo obrigatório")]
        public int ID_TIPO { get; set; }

        public int ID_CBO { get; set; }

        public int ID_CIDADE { get; set; }
        public ClienteViewModel()
        {
        }
        public ClienteViewModel(Cliente cliente)
        {
            IDCLIENTE = cliente.IDCLIENTE;
            CPF_CNPJ = cliente.CPF_CNPJ;
            NOME = cliente.NOME;
            SOBRENOME = cliente.SOBRENOME;
            CONJUGE = cliente.CONJUGE;
            ID_TIPO = cliente.ID_TIPO;
            ID_CBO = cliente.ID_CBO;
            ID_CIDADE = cliente.ID_CIDADE;
        }
    }
}