using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Walmart.Models;
using DataAccessLayer;
using System.Configuration;

namespace Walmart.Controllers
{
    public class EstadoController : Controller
    {
        //
        // GET: /Estados/

        public ActionResult Index()
        {
            var repository = new RepositorioEstado(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
            var model = repository.Lista();
            return View(model);
        }

        //
        // GET: /Estados/Details/5

        public ActionResult Details(int id)
        {
            var repository = new RepositorioEstado(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
            Estado entity = new Estado();
            entity.CodEstado = id;
            return View(repository.Seleciona(entity));
        }

        //
        // GET: /Estados/Create

        public ActionResult Create()
        {
            return View(new Estado());
        }

        //
        // POST: /Estados/Create

        [HttpPost]
        public ActionResult Create(Estado newEstado)
        {

            if (ModelState.IsValid)
            {
                var repository = new RepositorioEstado(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
                repository.Adiciona(newEstado);
                return RedirectToAction("Index");
            }
            else
                return View(newEstado);
        }

        //
        // GET: /Estados/Edit/5

        public ActionResult Edit(int id)
        {
            var repository = new RepositorioEstado(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
            Estado entity = new Estado();
            entity.CodEstado = id;
            return View(entity = repository.Seleciona(entity));
        }

        //
        // POST: /Estados/Edit/5

        [HttpPost]
        public ActionResult Edit(Estado estadoAntigo)
        {
            
            if (ModelState.IsValid)
            {
                var repository = new RepositorioEstado(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
                repository.Atualiza(estadoAntigo);
                return RedirectToAction("Index");
            }
            else
                return View(estadoAntigo);
        }

        //
        // GET: /Estados/Delete/5

        public ActionResult Delete(int id)
        {
            var repository = new RepositorioEstado(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
            Estado entity = new Estado();
            entity.CodEstado = id;
            return View(repository.Seleciona(entity));
        }

        //
        // POST: /Estados/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var repository = new RepositorioEstado(ConfigurationManager.ConnectionStrings["Walmart"].ToString());
            repository.Deleta(id);
            return RedirectToAction("Index");
        }
    }
}
