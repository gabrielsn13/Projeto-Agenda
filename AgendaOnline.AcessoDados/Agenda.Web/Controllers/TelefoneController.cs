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
using JsAction;

namespace Agenda.Web.Controllers
{

    public class TelefoneController : Controller
    {
        private TelefoneNegocios _telefoneNegocios = new TelefoneNegocios();
        private int _idCliente;

 

        [HttpGet]
        public ActionResult InserirTelefone(int id)
        {
            //sempre colocar o combo box nos metodos get para serem criados antes de serem postados
            //criar uma view para listagem de cada combo box 
            TipoTelefoneNegocios tipoTelefone = new TipoTelefoneNegocios();
            ViewBag.TipoTelefone = new SelectList(tipoTelefone.ListarTodos(), "IDTIPOTEL", "TIPO");

            _idCliente = id;
            return View();
        }

        [HttpPost]
        [MyHandlerError(ExceptionType=typeof(ArgumentException),View ="ErrorView")]
        public ActionResult InserirTelefone(TelefoneViewModel model,int TipoTelefone,int id) {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                return (AdicionarTelefone(model, TipoTelefone, id));
            }
            catch (ArgumentException)
            {
                throw new ArgumentException();
                
            }
           
        }

        public class MyHandlerError : HandleErrorAttribute
        {
            public override void OnException(ExceptionContext filterContext)
            {
                base.OnException(filterContext);    
            }
        }
        public ActionResult ConcluirTelefone()
        {
                    return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "Cliente", Action = "Index" }));
        }
        public ActionResult AdicionarTelefone(TelefoneViewModel model, int TipoTelefone, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Telefone telefone = new Telefone
            {
                DDD = model.DDD,
                TELEFONE = model.TELEFONE,
                ID_TIPOTEL = TipoTelefone,
                ID_CLIENTE = id
            };
            _telefoneNegocios.Salvar(telefone);
            return RedirectToAction("InserirTelefone", new RouteValueDictionary(new { Controller = "Telefone", Action = "InserirTelefone" }));

        }

    }
}