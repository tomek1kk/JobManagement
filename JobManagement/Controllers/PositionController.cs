using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagement.Data;
using JobManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace JobManagement.Controllers
{
    public class PositionController : Controller
    {
        private GenericUoW<Position> positionUoW;

        public PositionController(GenericUoW<Position> positionUoW)
        {
            this.positionUoW = positionUoW;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New(Position position = null)
        {
            return View(position);
        }

        public IActionResult AddPosition(Position position)
        {
            if (position.PositionID > 0)
            {
                var pos = positionUoW.Repository.GetItem(position.PositionID);
                pos.PositionName = position.PositionName;
                pos.Location = position.Location;
                pos.Description = position.Description;
                pos.Salary = position.Salary;

                positionUoW.Repository.UpdateItem(pos);
            }
            else
            {
                position.AddTime = DateTime.Now;
                positionUoW.Repository.AddItem(position);
            }
            positionUoW.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Position position = positionUoW.Repository.GetItem(id);

            return View(position);
        }

        public IActionResult Edit(int id)
        {
            Position position = positionUoW.Repository.GetItem(id);

            return RedirectToAction("New", new RouteValueDictionary(position));
        }
    }
}