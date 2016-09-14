using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cognossystem_testes.DAL;
using cognossystem_testes.Models;

namespace cognossystem_testes.Controllers
{
    public class ContatosController : Controller
    {
        private CognosDataContext db = new CognosDataContext();

        // GET: Contatos
        public ActionResult Index()
        {
            var contatos = db.Contatos.Include(c => c.Empresa);
            return View(contatos.ToList());
        }

        // GET: Contatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatos contatos = db.Contatos.Find(id);
            if (contatos == null)
            {
                return HttpNotFound();
            }
            return View(contatos);
        }

        // GET: Contatos/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaID = new SelectList(db.Empresas, "ID", "Nome");
            return View();
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Cargo,Email,Telefone,Celular,Status,Data_Inclusao,Data_Ultima_alteracao,EmpresaID")] Contatos contatos)
        {
            if (ModelState.IsValid)
            {
                db.Contatos.Add(contatos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaID = new SelectList(db.Empresas, "ID", "Nome", contatos.EmpresaID);
            return View(contatos);
        }

        // GET: Contatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatos contatos = db.Contatos.Find(id);
            if (contatos == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaID = new SelectList(db.Empresas, "ID", "Nome", contatos.EmpresaID);
            return View(contatos);
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Cargo,Email,Telefone,Celular,Status,Data_Inclusao,Data_Ultima_alteracao,EmpresaID")] Contatos contatos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contatos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaID = new SelectList(db.Empresas, "ID", "Nome", contatos.EmpresaID);
            return View(contatos);
        }

        // GET: Contatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatos contatos = db.Contatos.Find(id);
            if (contatos == null)
            {
                return HttpNotFound();
            }
            return View(contatos);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contatos contatos = db.Contatos.Find(id);
            db.Contatos.Remove(contatos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
