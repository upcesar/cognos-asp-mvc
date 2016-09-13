﻿using System;
using cognossystem_testes.DAL;
using cognossystem_testes.Models;
using System.Linq;
using System.Web.Mvc;

namespace cognossystem_testes.Controllers
{
    public class EmpresasController : Controller
    {
        // GET: Empresas
        public ActionResult Index()
        {
            var db = new CognosDataContext();
            
            var Model = from e in db.Empresas
                        where e.Status == Models.Status.Cadastrado
                        select e;

            return View(Model);            
                
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        [HttpPost]
        public ActionResult Create(Empresas Empresa)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Empresa.Data_Inclusao = DateTime.Now;
                    using (var db = new CognosDataContext())
                    {
                        db.Empresas.Add(Empresa);
                        db.SaveChanges();                        
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Empresas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Empresas Empresa)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empresas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
