using MODELS.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MODELS.Dao
{
    public class DetailDao:BaseDao
    {
        public DetailDao() : base()
        {

        }

        public Detail GetByID(int id)
        {
            return db.Details.Find(id);
        }

        public bool AddByProduct(Detail entity)
        {
            try
            {
                Product product = db.Products.Find(entity.IdProduct);
                db.Details.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddByInvoice(Detail entity, Product product)
        {
            try
            {
                Invoice invoice = new InvoiceDao().GetByID(entity.IdInvoice);
                product.Amount = product.Amount - entity.Amount;
                db.Details.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Detail entity)
        {
            try
            {
                Detail detail = GetByID(entity.Id);
                detail.IdInvoice = entity.IdInvoice;
                detail.IdProduct = entity.IdProduct;
                detail.Money = entity.Money;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Detail Delete(int id)
        {
            try
            {
                Detail detail = GetByID(id);
                db.Details.Remove(detail);
                db.SaveChanges();
                return detail;
            }
            catch
            {
                return null;
            }
        }

        public Product FindProduct(string idProduct, string idPackage)
        {
            return db.Products.Find(idProduct, idPackage);
        }

        public List<Detail> ListDetail(int idInvoice)
        {
            return db.Details.Where(x => x.IdInvoice == idInvoice).ToList();
        }
    }
}
