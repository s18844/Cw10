using Cw10.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.Services
{
    public class EfStudentDbService : IStudentDbService
    {
        private readonly s18844Context _dbContext;

        public EfStudentDbService(s18844Context context)
        {
            _dbContext = context;
        }

        public List<Student> ZwrocenieListyStudentow()
        {
            return _dbContext.Student.ToList();
        }

        public int UsuniecieStudenta(String index)
        {
            int modyfikacje = 0;


                var pobrany = new Student
                {
                    IndexNumber = index
                };
                      _dbContext.Entry(pobrany).State = EntityState.Deleted;
            try
            {
                modyfikacje = _dbContext.SaveChanges();
            }
            catch (Exception x)
            {

            }       
            return modyfikacje;     

        }

        public int ModyfikacjaStudenta(Student dane)
        {
            int modyfikacje = 0;
            var pobrany = _dbContext.Student.Where(d => d.IndexNumber == dane.IndexNumber).First();

            pobrany.IndexNumber = dane.IndexNumber;
            pobrany.FirstName = dane.FirstName;
            pobrany.LastName = dane.LastName;
            pobrany.BirthDate = dane.BirthDate;
            pobrany.IdEnrollment = dane.IdEnrollment;
            
            try
            {
                modyfikacje = _dbContext.SaveChanges();
            }
            catch (Exception x)
            {

            }
            return modyfikacje;
        }


       
    }
}
