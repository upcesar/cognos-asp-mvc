﻿using cognossystem_testes.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        // GET: Empresas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
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
        public ActionResult Edit(int id, FormCollection collection)
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