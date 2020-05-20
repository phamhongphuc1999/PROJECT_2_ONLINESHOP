using MODELS.EF;
using System.Collections.Generic;
using System.Linq;

namespace MODELS.Dao
{
    public class InvoiceDao: BaseDao
    {
        public List<Invoice> invoiceList;

        public InvoiceDao() : base() 
        {
            invoiceList = db.Invoices.ToList();
        }

        public Invoice GetByID(int id)
        {
            return db.Invoices.Find(id);
        }

        public bool Add(Invoice entity)
        {
            try
            {
                db.Invoices.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Invoice entity)
        {
            try
            {
                Invoice invoice = GetByID(entity.Id);
                invoice.IdCustomer = entity.IdCustomer;
                invoice.IdEmployee = entity.IdEmployee;
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
                Invoice invoice = GetByID(id);
                db.Invoices.Remove(invoice);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Detail> ListDetail(int id)
        {
            return db.Details.Where(x => x.IdInvoice == id);
        }
    }
}
