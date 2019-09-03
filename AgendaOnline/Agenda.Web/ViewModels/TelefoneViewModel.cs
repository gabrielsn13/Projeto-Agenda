using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgendaOnline.Dominio;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Web.ViewModels
{
    public class TelefoneViewModel
    {
        //obs.: como forma de boa pratica, as validaçoes nao sao feitas direto na classe Cliente, por ser uma classe 
        //da entidade. Logo criamos ClienteViewModel para realizar tais validaçoes
        public int IDTELEFONE { get; set; }
        public string DDD { get; set; }
        public string TELEFONE { get; set; }
        //Validação informando que o campo 'nome' é necessario
        [Required(ErrorMessage = " * Campo obrigatório")]
        public int ID_TIPOTEL { get; set; }
        [Required(ErrorMessage = " * Campo obrigatório")]
        public int ID_CLIENTE { get; set; }

        public TelefoneViewModel()
        {
        }
        public TelefoneViewModel(Telefone telefone)
        {
            IDTELEFONE = telefone.IDTELEFONE;
            DDD = telefone.DDD;
            TELEFONE = telefone.TELEFONE;
            ID_TIPOTEL = telefone.ID_TIPOTEL;
            ID_CLIENTE = telefone.ID_CLIENTE;
        }
    }
}