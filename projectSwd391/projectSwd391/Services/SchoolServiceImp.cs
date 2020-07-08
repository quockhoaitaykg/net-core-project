using projectSwd391.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace projectSwd391.Services
{
    public class SchoolServiceImp : ISchoolService
    {
        
        private devContext db;

        public SchoolServiceImp()
        {
            this.db = new devContext();
        }

        public School FindSchoolById(int id)
        {
            return db.School.FirstOrDefault(x => x.Id == id);
        }

        public List<School> GetSchool(int page, int perPage, string sort, string search)
        {
            var query = db.School.AsQueryable();
            string orderBy = "Id";

            if (search != null)
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            if (sort != null)
            {
                string[] tmp = sort.Split(',');
                string result = "";
                foreach (string word in tmp)
                {
                    if (word[0] == '-')
                    {
                        result += word.Substring(1, word.Length - 1) + " DESC,";
                    }
                    else
                    {
                        result += word + " ASC,";
                    }
                }
                orderBy = result.Substring(0, result.Length - 1);
            }

            return query.OrderBy(x =>orderBy).Skip(page * perPage).Take(perPage).ToList();
        }

        public bool InsertSchool(string name, string phone, string address, string latitude, string longitude, int districtId, int insId, int updId)
        {
            try
            {

                School school = new School();
                school.Name = name;
                school.DelFlg = false;
                school.Ver = 1;
                school.InsId = insId;
                school.InsDateTime = DateTime.Now;
                school.UpdId = updId;
                school.UpdDateTime = DateTime.Now;
                db.School.Add(school);

                Location location = new Location();
                location.StreetAddress = address;
                location.Latitude = latitude;
                location.Longitude = longitude;
                location.DistrictId = districtId;
                location.DelFlg = false;
                location.Ver = 1;
                location.InsId = insId;
                location.InsDateTime = DateTime.Now;
                location.UpdId = updId;
                location.UpdDateTime = DateTime.Now;
                db.Location.Add(location);


                int lastId = db.School.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                int lastLocation = db.Location.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                SchoolBranch schoolBranch = new SchoolBranch();
                schoolBranch.SchoolId = lastId + 1;
                schoolBranch.LocationId = lastLocation + 1;
                schoolBranch.Phone = phone;
                schoolBranch.DelFlg = false;
                schoolBranch.Ver = 1;
                schoolBranch.InsId = insId;
                schoolBranch.InsDateTime = DateTime.Now;
                schoolBranch.UpdId = updId;
                schoolBranch.UpdDateTime = DateTime.Now;
                db.SchoolBranch.Add(schoolBranch);


                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateSchool(int id, string phone, string address, string latitude, string longitude, int districtId, int updId)
        {
            try
            {


                SchoolBranch schoolBranch = db.SchoolBranch.FirstOrDefault(x => x.Id == id);
                Location location = db.Location.FirstOrDefault(x => x.Id == schoolBranch.LocationId);
                if (schoolBranch == null)
                {
                    return false;
                }

                if (phone != null)
                {
                    schoolBranch.Phone = phone;
                }
                if (address != null)
                {
                    location.StreetAddress = address;
                }
                if (latitude != null)
                {
                    location.Latitude = latitude;
                }
                if (longitude != null)
                {
                    location.Longitude = longitude;
                }
                if (districtId.ToString() != null)
                {
                    location.DistrictId = districtId;
                }


                schoolBranch.Ver = schoolBranch.Ver + 1;
                schoolBranch.UpdDateTime = DateTime.Now;
                schoolBranch.Ver = schoolBranch.Ver + 1;
                schoolBranch.UpdDateTime = DateTime.Now;
                location.Ver = location.Ver + 1;
                location.UpdDateTime = DateTime.Now;
                db.SchoolBranch.Update(schoolBranch);
                db.Location.Update(location);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSchool(int id)
        {
            SchoolBranch schoolBranch = db.SchoolBranch.FirstOrDefault(x => x.Id == id);
            Location location = db.Location.FirstOrDefault(x => x.Id == schoolBranch.LocationId);
            
            if (schoolBranch == null)
            {
                return false;
            }
            schoolBranch.DelFlg = true;
            location.DelFlg = true;
            db.SchoolBranch.Update(schoolBranch);
            db.Location.Update(location);
            db.SaveChanges();
            return true;
        }
    }
}
