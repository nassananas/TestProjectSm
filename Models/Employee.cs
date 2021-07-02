using Dapper.Contrib.Extensions;

namespace TestProject.Models
{
    [Table("employee")]
    public class Employee
    {
        private int id;
        private string name;
        private string surname;
        private string phone;
        private int companyId;
        private Passport passport;
        private int departmentId;
        private Department department;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Phone { get => phone; set => phone = value; }
        public int CompanyId { get => companyId; set => companyId = value; }
        public Passport Passport { get => passport; set => passport = value; }
        public Department Department { get => department; set => department = value; }
        public int DepartmentId { get => departmentId; set => departmentId = value; }
    }
}
