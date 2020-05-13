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

        public Boolean UsuniecieStudenta(String index)
        {
            var pobrany = new Student
            {
                IndexNumber = index
            };
          
            try
            {
                _dbContext.Entry(pobrany).State = EntityState.Deleted;
            }
            catch(Exception x)
            {
                return false;
            }

            return true;
        }

        public void EnrollStudent()
        {
            throw new NotImplementedException();
        }

        public void PromotesStudents()
        {
            throw new NotImplementedException();
        }
    }
}
