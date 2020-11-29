using CardapioCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardapioCrud.Core;
using CardapioCrud.Data;

namespace CardapioCrud
{
    [ViewComponent(Name = "Game")]
    public class AddEditGameComponent : ViewComponent
    {
        private GameContext context;

        public AddEditGameComponent(GameContext context)
        {
            this.context = context;
        }
        public IViewComponentResult Invoke(int id = 0)
        {

            GameModel model = new GameModel();
            if (id != 0)
            {
                Game Game = context.Set<Game>().SingleOrDefault(c => c.Id == id);
                if (Game != null)
                {
                    model.Id = Game.Id;
                    model.Name = Game.name;

                }
            }
            return View("~/Views/Game/_AddEditGame.cshtml", model);
        }
    }

}
