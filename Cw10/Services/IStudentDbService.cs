using Cw10.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.Services
{
    public interface IStudentDbService
    {
        public List<Student> ZwrocenieListyStudentow();
        public int UsuniecieStudenta(String index);
        public int ModyfikacjaStudenta(Student dane);
    }
}
