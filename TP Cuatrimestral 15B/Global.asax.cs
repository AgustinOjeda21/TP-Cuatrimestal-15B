using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace TP_Cuatrimestral_15B
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_AcquireRequestState(object sender, EventArgs e)
        {
            string ruta = Request.AppRelativeCurrentExecutionFilePath;

            if (ruta.StartsWith("~/Admin/", StringComparison.OrdinalIgnoreCase))
            {
                var usuario = Session["Usuario"] as Dominio.Entidades.Usuario;

                if (usuario == null || usuario.Rol != Dominio.Entidades.Usuario.Roles.Administrador)
                {
                    Response.Redirect("~/Log_in.aspx");
                }
            }
        }
    }
}
