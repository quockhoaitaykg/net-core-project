using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using projectSwd391.Models;
using projectSwd391.Services;

namespace projectSwd391.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private IDistributedCache _distributedCache;
        private ISchoolService _service;

        public SchoolsController(IDistributedCache distributedCache)
        {
            _service = new SchoolServiceImp();
            _distributedCache = distributedCache;   
        }
        [HttpGet]     
        public List<School> GetSchool()
        {

            var value = new List<School>();
            if (string.IsNullOrEmpty(_distributedCache.GetString("value")))
            {
                value = _service.GetSchool();
                var valueInString = JsonConvert.SerializeObject(value);
                _distributedCache.SetString("value", valueInString);
            }
            else
            {
                var valueFromCache = _distributedCache.GetString("value");
                value = JsonConvert.DeserializeObject<List<School>>(valueFromCache);
            }
            return value;
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
