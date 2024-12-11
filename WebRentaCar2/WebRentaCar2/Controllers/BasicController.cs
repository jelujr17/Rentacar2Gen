using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NHibernate;
using Rentacar2Gen.Infraestructure.CP;
using Rentacar2Gen.Infraestructure.Repository.RentaCar2;
using WebRentaCar2.Models;

namespace WebRentaCar2.Controllers
{
    public class BasicController : Controller
    {
        private NHibernate.ISession sessionInside;
        protected SessionCPNHibernate session;

        protected BasicController()
        {
        }

        protected void SessionInitialize()
        {
            if (session == null)
            {
                sessionInside = NHibernateHelper.OpenSession();
                session = new SessionCPNHibernate(sessionInside);
            }
        }

        protected void SessionClose()
        {
            if (session != null && sessionInside.IsOpen)
            {
                sessionInside.Close();
                sessionInside.Dispose();
                session = null;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (usuario != null)
            {
                ViewData["Layout"] = "_LayoutLoggedIn";
            }
            else
            {
                ViewData["Layout"] = "_Layout";
            }
            base.OnActionExecuting(context);
        }
    }
}
