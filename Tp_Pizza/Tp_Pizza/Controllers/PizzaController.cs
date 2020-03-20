using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tp_Pizza.Models;
using Tp_Pizza.Utils;

namespace Tp_Pizza.Controllers
{
    public class PizzaController : Controller
    {



        
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDB.Instance.Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            var pizza = FakeDB.Instance.Pizzas.FirstOrDefault(p => p.Id == id); if (pizza != null) { return View(pizza); }

            return RedirectToAction("Index");
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaViewModel vm = new PizzaViewModel();

            vm.Pates = FakeDB.Instance.patesDispo.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            vm.Ingredients = FakeDB.Instance.ingredientDispo.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel vm)
        {
            try
            {
                Pizza pizza = vm.Pizza;

                pizza.Pate = FakeDB.Instance.patesDispo.FirstOrDefault(x => x.Id == vm.IdPate);

                pizza.Ingredients = FakeDB.Instance.ingredientDispo.Where(
                    x => vm.IdsIngredients.Contains(x.Id))
                    .ToList();

                // Insuffisant
                //pizza.Id = FakeDb.Instance.Pizzas.Count + 1;

                pizza.Id = FakeDB.Instance.Pizzas.Count == 0 ? 1 : FakeDB.Instance.Pizzas.Max(x => x.Id) + 1;

                FakeDB.Instance.Pizzas.Add(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {

            PizzaViewModel vm = new PizzaViewModel();

            vm.Pates = FakeDB.Instance.patesDispo.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            vm.Ingredients = FakeDB.Instance.ingredientDispo.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            vm.Pizza = FakeDB.Instance.Pizzas.FirstOrDefault(x => x.Id == id);

            if (vm.Pizza.Pate != null) {
                vm.IdPate = vm.Pizza.Pate.Id;
            }

            if (vm.Pizza.Ingredients.Any())
            {
                vm.IdsIngredients = vm.Pizza.Ingredients.Select(x => x.Id).ToList();
            }

            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaViewModel vm)
        {
            try
            {
                Pizza pizza = FakeDB.Instance.Pizzas.FirstOrDefault(p => p.Id == vm.Pizza.Id);
                pizza.Nom = vm.Pizza.Nom;
                pizza.Pate = FakeDB.Instance.patesDispo.FirstOrDefault(x => x.Id == vm.IdPate);

                pizza.Ingredients = FakeDB.Instance.ingredientDispo.Where(
                    x => vm.IdsIngredients.Contains(x.Id))
                    .ToList();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            var pizza = FakeDB.Instance.Pizzas.FirstOrDefault(p => p.Id == id); if (pizza != null) { return View(pizza); }

            return RedirectToAction("Index");
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var pizza = FakeDB.Instance.Pizzas.FirstOrDefault(p => p.Id == id); if (pizza != null) {
                    FakeDB.Instance.Pizzas.Remove(pizza);
                   }

                
            }
            catch
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
