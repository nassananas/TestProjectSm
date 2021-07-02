using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    [Table("department")]
    public class Department
    {
        private int departmentId;
        private string name;
        private string phone;

        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public int DepartmentId { get => departmentId; set => departmentId = value; }
    }
}
