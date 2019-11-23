using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagement.Data;
using JobManagement.Models;
using JobManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobManagement.Controllers
{
    [ApiController]
    public class PositionApiController : ControllerBase
    {
        private GenericUoW<Position> positionUoW;

        public PositionApiController(GenericUoW<Position> positionUoW)
        {
            this.positionUoW = positionUoW;
        }

        [HttpGet]
        [Route("api/Position/GetAll")]
        public IEnumerable<Position> GetAll()
        {
            return positionUoW.Repository.GetAll();
        }

        [HttpGet]
        [Route("api/Position/GetListViewModel")]
        public IEnumerable<PositionViewModel> GetListViewModel()
        {
            var positions = positionUoW.Repository.GetAll();
            List<PositionViewModel> positionViews = new List<PositionViewModel>();
            for (int i = 0; i < positions.Count; i++)
            {
                positionViews.Add(new PositionViewModel
                {
                    PositionId = positions[i].PositionID,
                    CreatedDate = positions[i].AddTime,
                    PositionName = positions[i].PositionName,
                    Salary = positions[i].Salary,
                    Location = positions[i].Location
                });
            }

            return positionViews;
        }

        [HttpGet]
        [Route("api/Position/Get/{id}")]
        public Position Get(int id)
        {
            return positionUoW.Repository.GetAll().Find(p => p.PositionID == id);
        }

        [HttpDelete]
        [Route("api/Position/Delete/{id}")]
        public void Delete(int id)
        {
            positionUoW.Repository.DeleteItem(positionUoW.Repository.GetAll().Find(p => p.PositionID == id));
            positionUoW.Save();
        }

        [HttpPut]
        [Route("api/Position/Update")]
        public void Update([FromBody] Position position)
        {
            positionUoW.Repository.UpdateItem(position);
            positionUoW.Save();
        }
    }
}