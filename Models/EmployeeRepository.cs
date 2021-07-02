using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace TestProject.Models
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Delete(int id);
        int? GetEmployee(int id);
        int? GetDepartment(int id);
        List<Object> GetByCompany(int companyId);
        List<Object> GetByDepartment(int department);
        void Update(Employee employee);
    }
    public class EmployeeRepository:IEmployeeRepository
    {
        string connectionString = null;
        public EmployeeRepository(string conn)
        {
            connectionString = conn;
        }

        public void Add(Employee employee)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
               var sqlQuery = "BEGIN TRANSACTION DECLARE @DataID int; " +
                    "INSERT INTO employee(Name, Surname, Phone, CompanyId, DepartmentId) VALUES(@Name, @Surname, @Phone, @CompanyId, @DepartmentId); " +
                    "SELECT @DataID = scope_identity();" +
                    "INSERT INTO passport(EmployeeId, Type, Number) VALUES(@DataID, @PassportType, @PassportNumber);" +
                    "COMMIT";
 
                int? employeeId = db.Query<int>(sqlQuery, new EmployeeParam(employee)).FirstOrDefault();
                employee.Id = employeeId.Value;       
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM employee WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public int? GetEmployee(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "SELECT * FROM employee WHERE Id = @id";
                return db.Query<int?>(sqlQuery, new { id }).FirstOrDefault();
            }
        }

        public int? GetDepartment(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "SELECT DepartmentId FROM department WHERE DepartmentId = @id";
                return db.Query<int?>(sqlQuery, new { id }).FirstOrDefault();
            }
        }

        public List<Object> GetByCompany(int companyId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Object>("SELECT * FROM passport JOIN employee ON employee.Id = passport.EmployeeId JOIN department ON employee.DepartmentId = department.DepartmentId WHERE employee.CompanyId = @companyId", new { companyId }).ToList();
            }
        }

        public List<Object> GetByDepartment(int departmentId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Object>("SELECT * FROM employee JOIN department ON employee.DepartmentId = department.DepartmentId JOIN passport ON employee.Id = passport.EmployeeId WHERE employee.DepartmentId = @departmentId", new { departmentId }).ToList();
            }
        }

        public void Update(Employee employee)
        {
            int id = employee.Id;
            string sqlQuery = "UPDATE employee SET ";
            if (employee.Name != null) sqlQuery += "Name = @Name ";
            if (employee.Surname != null) sqlQuery += ",Surname = @Surname ";
            if (employee.Phone != null) sqlQuery += ",Phone = @Phone ";
            if (employee.CompanyId != 0) sqlQuery += ",CompanyId = @CompanyId ";
            if (employee.DepartmentId != 0) sqlQuery += ",DepartmentId = @DepartmentId ";
            sqlQuery += $"WHERE Id = {id}";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(sqlQuery, employee);
            }
            if(employee.Passport != null)
            {
                sqlQuery = "UPDATE passport SET ";
                if (employee.Passport.Type != null) sqlQuery += "Type = @Type ";
                if (employee.Passport.Number != null) sqlQuery += ",Number = @Number ";
                sqlQuery += $"WHERE EmployeeId = {id}";
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Execute(sqlQuery, employee.Passport);
                }
            }
        }
    }
}
