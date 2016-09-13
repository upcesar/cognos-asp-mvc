using cognossystem_testes.DAL;
using cognossystem_testes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cognossystem_testes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using(var db = new CognosDataContext())
            {
                var empresa = new Empresas()
                {
                    Nome = "test",
                    Site = "ertert",
                    Status = Status.Cadastrado,
                    Data_Inclusao = DateTime.Now,
                };

                db.Empresas.Add(empresa);
                db.SaveChanges();

                var q = from e in db.Empresas
                        select e;

                System.Diagnostics.Debugger.Break();

            }
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}