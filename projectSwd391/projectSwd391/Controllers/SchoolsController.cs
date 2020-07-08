using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projectSwd391.Models;
using projectSwd391.Services;

namespace projectSwd391.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {

        private ISchoolService _service;

        public SchoolsController()
        {
            _service = new SchoolServiceImp();
        }
        [HttpGet]
        public List<School> GetSchool(int page, int perPage, string sort, string search)
        {
            return _service.GetSchool(page, perPage, sort, search);
        }
        [HttpGet("{id}")]
        public School FindSchoolById(int id)
        {
            return _service.FindSchoolById(id);
        }

        [HttpPost]
        public bool InsertSchool(string name, string phone, string address, string latitude, string longitude, int districtId, int insId, int updId)
        {
            return _service.InsertSchool(name, phone, address, latitude, longitude, districtId, insId, updId);
        }

        [HttpPut]
        public bool UpdateSchool(int id, string phone, string address, string latitude, string longitude, int districtId, int updId)
        {
            return _service.UpdateSchool(id, phone, address, latitude, longitude, districtId, updId);
        }

        [HttpDelete]
        public bool DeleteSchool(int id)
        {
            return _service.DeleteSchool(id);
        }
    }
}
