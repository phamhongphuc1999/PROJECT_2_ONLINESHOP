using System.Collections.Generic;
using System.Linq;
using MODELS.EF;

namespace MODELS.Dao
{
    public class EmployeeDao:BaseDao
    {
        public List<Employee> employeeList;
        public EmployeeDao():base()
        {
            employeeList = db.Employees.ToList();
        }

        public Employee GetByName(string name, bool isUserName)
        {
            if (isUserName)
                return db.Employees.SingleOrDefault(x => x.Username == name);
            else return db.Employees.SingleOrDefault(x => x.Name == name);
        }

        public Employee GetByID(int id)
        {
            return db.Employees.Find(id);
        }

        public int Insert(Employee entity)
        {
            db.Employees.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Edit(Employee entity)
        {
            try
            {
                Employee employee = GetByID(entity.Id);
                employee.Name = entity.Name;
                employee.Address = entity.Address;
                employee.Birthday = entity.Birthday;
                employee.Phone = entity.Phone;
                employee.Sex = entity.Sex;
                employee.Username = entity.Username;
                employee.Password = entity.Password;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }   
        }

        public bool Delete(int id)
        {
            try
            {
                Employee employee = GetByID(id);
                db.Employees.Remove(employee);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int CountUsername(string username)
        {
             return db.Employees.Count(x => x.Username == username);
        }

        public bool Login(string username, string password)
        {
            var result = db.Employees.Count(x => x.Username == username && x.Password == password);
            if (result > 0)
            {
                return true;
            }
            else return false;
        }
    }
}
