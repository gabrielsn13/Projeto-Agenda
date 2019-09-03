using AgendaOnline.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Agenda.Web.ViewModels
{
    public class AgendamentoViewModel
    {

        //obs.: como forma de boa pratica, as validaçoes nao sao feitas direto na classe Cliente, por ser uma classe 
        //da entidade. Logo criamos ClienteViewModel para realizar tais validaçoes
        public int IDAGENDAMENTO { get; set; }
        public string TITULO { get; set; }
        //Validação informando que o campo 'nome' é necessario
        [Required(ErrorMessage = " * Campo obrigatório")]
        public int ID_SALA { get; set; }
        [Required(ErrorMessage = " * Campo obrigatório")]

        public int ID_CLIENTE { get; set; }
        [Required(ErrorMessage = " * Campo obrigatório")]
        public DateTime DATA { get; set; }
        [Required(ErrorMessage = " * Campo obrigatório")]
        public string OBSERVACOES { get; set; }
 
        public AgendamentoViewModel()
        {
        }
        public AgendamentoViewModel(Agendamento agendamento)
        {
            IDAGENDAMENTO = agendamento.IDAGENDAMENTO;
            TITULO = agendamento.TITULO;
            ID_SALA = agendamento.ID_SALA;
            ID_CLIENTE = agendamento.ID_CLIENTE;
            DATA = agendamento.DATA;
            OBSERVACOES = agendamento.OBSERVACOES;
        }
    }
}
