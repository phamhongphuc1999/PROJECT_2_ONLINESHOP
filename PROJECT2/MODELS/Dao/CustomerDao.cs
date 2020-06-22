using System.Collections.Generic;
using System.Linq;
using MODELS.EF;

namespace MODELS.Dao
{
    public class CustomerDao:BaseDao
    {
        public List<Customer> customerList;

        public CustomerDao() : base()
        {
            customerList = db.Customers.ToList();
        }

        public Customer GetByID(int id)
        {
            return db.Customers.Find(id);
        }

        public bool Add(Customer entity)
        {
            try
            {
                entity.Type = "D";
                db.Customers.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Customer entity)
        {
            try
            {
                Customer customer = GetByID(entity.Id);
                customer.Name = entity.Name;
                customer.Birthday = entity.Birthday;
                customer.Phone = entity.Phone;
                customer.Address = entity.Address;
                customer.Node = entity.Node;
                customer.Sex = entity.Sex;
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
                Customer customer = GetByID(id);
                List<Invoice> invoiceList = db.Invoices.Where(x => x.IdCustomer == id).ToList();
                foreach(Invoice item in invoiceList)
                {
                    item.Status = false;
                }
                db.Customers.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Customer> SearchCustomer(string stringSearch)
        {
            return db.Customers.Where(x => x.Name.Contains(stringSearch)).ToList();
        }
    }
}
