using projectSwd391.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectSwd391.Services
{
    interface ISchoolService
    {
        List<School> GetSchool();

        bool InsertSchool(string name, string phone, string address, string latitude, string longitude, int districtId, int insId, int updId);

        bool UpdateSchool(int id, string phone, string address, string latitude, string longitude, int districtId, int updId);

        bool DeleteSchool(int id);

        School FindSchoolById(int id);
    }
}
