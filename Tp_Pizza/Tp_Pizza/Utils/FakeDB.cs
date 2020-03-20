using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tp_Pizza.Utils
{
    public class FakeDB
    {


        private static FakeDB _instance;
        static readonly object instanceLock = new object();

        private FakeDB() {

            pizzas = this.getListePizzas();
            initIngredient();
            initPate();
        }

        public static FakeDB Instance
        {
            get
            {
                if (_instance == null) //Les locks prennent du temps, il est préférable de vérifier d'abord la nullité de l'instance.
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
                            _instance = new FakeDB();
                    }
                }
                return _instance;
            }
        }

        private List<Pizza> pizzas;

        public List<Pizza> Pizzas
        {
            get { return pizzas; }
        }

        private List<Pizza> getListePizzas() {
            pizzas = new List<Pizza>
            {
                new Pizza{Id=1,

                    Ingredients = new List<Ingredient>
                    {
                        Pizza.IngredientsDisponibles.First(i => i.Id == 1),
                        Pizza.IngredientsDisponibles.First(i => i.Id == 2),
                        Pizza.IngredientsDisponibles.First(i => i.Id == 4),
                        Pizza.IngredientsDisponibles.First(i => i.Id == 6),
                    },
                    Nom="Pizza 1",
                    Pate=Pizza.PatesDisponibles.First(p=>p.Id == 1)



                    },

                new Pizza{Id=2,

                    Ingredients = new List<Ingredient>
                    {
                        Pizza.IngredientsDisponibles.First(i => i.Id == 2),
                        Pizza.IngredientsDisponibles.First(i => i.Id == 4),
                        Pizza.IngredientsDisponibles.First(i => i.Id == 6),
                        Pizza.IngredientsDisponibles.First(i => i.Id == 8),
                    },
                    Nom="Pizza 2",
                    Pate=Pizza.PatesDisponibles.First(p=>p.Id == 2)



                    },

                new Pizza{Id=3,

                    Ingredients = new List<Ingredient>
                    {
                        Pizza.IngredientsDisponibles.First(i => i.Id == 1),
                        Pizza.IngredientsDisponibles.First(i => i.Id == 3),
                        Pizza.IngredientsDisponibles.First(i => i.Id == 5),
                        Pizza.IngredientsDisponibles.First(i => i.Id == 7),
                    },
                    Nom="Pizza 3",
                    Pate=Pizza.PatesDisponibles.First(p=>p.Id == 3)



                    },

                new Pizza{Id=4,

                    Ingredients = new List<Ingredient>
                    {
                        Pizza.IngredientsDisponibles.First(i => i.Id == 1),
                        Pizza.IngredientsDisponibles.First(i => i.Id == 2),
                        Pizza.IngredientsDisponibles.First(i => i.Id == 5),
                        Pizza.IngredientsDisponibles.First(i => i.Id == 8),
                    },
                    Nom="Pizza 4",
                    Pate=Pizza.PatesDisponibles.First(p=>p.Id == 4)



                    }
            };

            return Pizzas;
        }

        private List<Ingredient> IngredientDispo;

        public List<Ingredient> ingredientDispo
        {
            get { return IngredientDispo; }
           
        }

        private List<Pate> PatesDispo;

        public List<Pate> patesDispo
        {
            get { return PatesDispo; }
        }

        private void initIngredient()
        {
            IngredientDispo = BO.Pizza.IngredientsDisponibles;
        }

        private void initPate()
        {
            PatesDispo = BO.Pizza.PatesDisponibles;
        }

        public void addPizza(Pizza pizza) {
            pizzas.Add(pizza);
        }

    }
}