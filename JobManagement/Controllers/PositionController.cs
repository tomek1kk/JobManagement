using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagement.Data;
using JobManagement.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult New()
        {
            return View();
        }

        public IActionResult AddPosition(Position position)
        {
            position.AddTime = DateTime.Now;
            positionUoW.Repository.AddItem(position);
            positionUoW.Save();

            return RedirectToAction("Index");
        }
    }
}