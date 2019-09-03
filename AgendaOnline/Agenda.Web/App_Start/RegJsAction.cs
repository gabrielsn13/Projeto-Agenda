using System;

[assembly: WebActivator.PreApplicationStartMethod(
    typeof(Agenda.Web.App_Start.RegJsAction), "PreStart")]

namespace Agenda.Web.App_Start {
    public static class RegJsAction {
        public static void PreStart() {
            System.Web.Routing.RouteTable.Routes.Add("JsActionRoute", JsAction.JsActionRouteHandlerInstance.JsActionRoute);
        }
    }
}
