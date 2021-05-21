using Dapper;
using DapperOrmDemo.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperOrmDemo.Repository
{
    public class EmployeeRepository
    { 
        private readonly dbCon _dbCon;
        public EmployeeRepository()
        {
            _dbCon = new dbCon();
        } 

        public void Add(Employee Emp) {
            using (IDbConnection dbConnection = _dbCon.Connection) {
                string sQuery = @"Insert into Employee(FullName,DateofBirth,ContactNo,PanNo,AadharNo,Address,Salary,DepartmentId)values(@FullName,@DateofBirth,@ContactNo,@PanNo,@AadharNo,@Address,@Salary,@DepartmentId)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Emp);
            }
        }

        public IEnumerable<Employee> GetAllEmployee() {
            using (IDbConnection dbConnection = _dbCon.Connection)
            {
                string sQuery = @"select e.EmployeeId,e.FullName,e.DateofBirth,e.contactno,e.PanNo,e.AadharNo,e.Address,e.Salary,d.DepartmentName,d.departmentid from employee e
                                  inner join department d on d.DEPARTMENTID = e.Departmentid  ";
                dbConnection.Open();
                return dbConnection.Query<Employee>(sQuery);
            }
        }

        public Employee GetById(int id)
        {
            using (IDbConnection dbConnection = _dbCon.Connection)
            {
                string sQuery = @"select e.EmployeeId,e.FullName,e.DateofBirth,e.contactno,e.PanNo,e.AadharNo,e.Address,e.Salary,d.DepartmentName,d.departmentid from employee e
                                inner join department d on d.DEPARTMENTID = e.Departmentid   where EmployeeId =@Id";
                dbConnection.Open();
                return dbConnection.Query<Employee>(sQuery, new { Id = id}).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _dbCon.Connection)
            {
                string sQuery = @"Delete from Employee where EmployeeId =@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }
        public void Update(Employee Emp)
        {
            using (IDbConnection dbConnection = _dbCon.Connection)
            {
                string sQuery = @"Update Employee Set FullName = @FullName,DateofBirth = @DateofBirth,ContactNo = @ContactNo,PanNo = @PanNo,AadharNo = @AadharNo,Address = @Address,Salary = @Salary";
                dbConnection.Open();
                dbConnection.Query(sQuery, Emp);
            }
        }
    }
}
