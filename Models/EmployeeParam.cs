using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class EmployeeParam
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public int companyId { get; set; }
        public string passportType { get; set; }
        public string passportNumber { get; set; }
        public int departmentId { get; set; }

        public EmployeeParam(Employee employee)
        {
            this.id = employee.Id;
            this.name = employee.Name;
            this.surname = employee.Surname;
            this.phone = employee.Phone;
            this.companyId = employee.CompanyId;
            this.departmentId = employee.DepartmentId;
            if (employee.Passport != null)
            {
                this.passportType = employee.Passport.Type;
                this.passportNumber = employee.Passport.Number;
            }         
        }
    }
}
