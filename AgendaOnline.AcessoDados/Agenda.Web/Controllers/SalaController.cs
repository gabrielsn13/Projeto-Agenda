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

namespace Agenda.Web.Controllers
{
    public class SalaController : Controller
    {
        private SalaNegocios _salasNegocios = new SalaNegocios();
        public ActionResult ListagemSalas()
        {
            //este metodo retorna para a view index os clientes listados 
            var salas = _salasNegocios.ListarSalas();
            return View(salas);
        }

        [HttpGet]
        public ActionResult CadastrarSala()
        {
            //sempre colocar o combo box nos metodos get para serem criados antes de serem postados
            //criar uma view para listagem de cada combo box 
            StatusSalaNegocios statusSala = new StatusSalaNegocios();

            ViewBag.Status = new SelectList(statusSala.ListarTodos(), "IDSTATUS", "STATUS");
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarSala(SalaViewModel model, int Status)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Sala sala = new Sala
            {
                SALA = model.SALA,
                ID_STATUS = Status
            };
            _salasNegocios.Salvar(sala);
            return RedirectToAction("ListagemSalas", new RouteValueDictionary(new { Controller = "Sala", Action = "ListagemSalas" }));

        }

        [HttpGet]
        public ActionResult EditarSala(int id)
        {       
            StatusSalaNegocios statusSala = new StatusSalaNegocios();
            ViewBag.Status = new SelectList(statusSala.ListarTodos(), "IDSTATUS", "STATUS", _salasNegocios.BuscarId(id).ID_STATUS);

            var sala = _salasNegocios.BuscarId(id);
            return View(new ListagemSalaViewModel(sala));
        }

        [HttpPost]
        public ActionResult EditarSala(ListagemSalaViewModel model, int id, int Status)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var sala = new Sala
            {
                IDSALA = id,
                SALA = model.SALA,
                ID_STATUS = Status
            };

            _salasNegocios.Alterar(sala);

            return RedirectToAction("ListagemSalas");
        }



    }
}