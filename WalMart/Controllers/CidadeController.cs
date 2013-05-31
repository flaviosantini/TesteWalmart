using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Walmart.Models;
using System.Configuration;

namespace Walmart.Controllers
{
    public class CidadeController : Controller
    {

        //
        // GET: /Cidade/

        public ActionResult Index()
        {
            var repository = new RepositorioCidade(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
            var model = repository.Lista();
            return View(model);
        }

        //
        // GET: /Cidade/Details/5

        public ActionResult Details(int id)
        {
            var repository = new RepositorioCidade(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
            Cidade entity = new Cidade();
            entity.CodCidade = id;
            return View(repository.Seleciona(entity));
        }

        //
        // GET: /Cidade/Create

        public ActionResult Create()
        {
            return View(new Cidade());
        }

        //
        // POST: /Cidade/Create

        [HttpPost]
        public ActionResult Create(Cidade newCidade)
        {
            if (ModelState.IsValid)
            {
                var repository = new RepositorioCidade(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
                repository.Adiciona(newCidade);
                return RedirectToAction("Index");
            }
            else
                return View(newCidade);
        }

        //
        // GET: /Cidade/Edit/5

        public ActionResult Edit(int id)
        {
            var repository = new RepositorioCidade(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
            Cidade entity = new Cidade();
            entity.CodCidade = id;
            return View(entity = repository.Seleciona(entity));
        }

        //
        // POST: /Cidade/Edit/5

        [HttpPost]
        public ActionResult Edit(Cidade cidadeAntiga)
        {
            if (ModelState.IsValid)
            {
                var repository = new RepositorioCidade(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
                repository.Atualiza(cidadeAntiga);
                return RedirectToAction("Index");
            }
            else
                return View(cidadeAntiga);
        }

        //
        // GET: /Cidade/Delete/5

        public ActionResult Delete(int id)
        {
            var repository = new RepositorioCidade(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
            Cidade entity = new Cidade();
            entity.CodCidade = id;
            return View(repository.Seleciona(entity));
        }

        //
        // POST: /Cidade/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var repository = new RepositorioCidade(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
            repository.Deleta(id);
            return RedirectToAction("Index");
        }
    }
}
