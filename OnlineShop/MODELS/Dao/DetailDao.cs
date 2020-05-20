using MODELS.EF;
using System;
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
                entity.ImportPrice = product.ImportPrice;
                entity.ExportPrice = product.ImportPrice * product.Profix / 100;
                entity.Money = entity.ExportPrice * entity.Amount;
                entity.NameProduct = product.NameProduct;
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
                entity.DaySell = invoice.DaySell;
                entity.ImportPrice = product.ImportPrice;
                entity.ExportPrice = (((product.ImportPrice * (product.Profix + 100)) / 100) * ((100 - product.Sale))) / 100;
                entity.Money = entity.ExportPrice * entity.Amount;
                entity.NameProduct = product.NameProduct;
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
                detail.IdPackage = entity.IdPackage;
                detail.IdProduct = entity.IdProduct;
                detail.NameProduct = entity.NameProduct;
                detail.ImportPrice = entity.ImportPrice;
                detail.ExportPrice = entity.ExportPrice;
                detail.Money = entity.Money;
                detail.DaySell = entity.DaySell;
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

        public IQueryable<Product> ListProduct(string idProduct, string idPackage)
        {
            return db.Products.Where(x => (x.Id == idProduct) && (x.IdPackage == idPackage));
        }

        public IQueryable<Detail> ListDetail(int id)
        {
            return db.Details.Where(x => x.IdInvoice == id);
        }

        public IQueryable<Detail> FilterByDaySell(DateTime start, DateTime end, string nameProduct = "")
        {
            if (nameProduct == "") return db.Details.Where(x => (x.DaySell >= start) && (x.DaySell <= end));
            else
                return db.Details.Where(x => (x.DaySell >= start) && (x.DaySell <= end) && x.NameProduct == nameProduct);
        }

    }
}
