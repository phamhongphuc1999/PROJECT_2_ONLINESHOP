using System.Collections.Generic;
using System.Linq;
using MODELS.EF;

namespace MODELS.Dao
{
    public class ProductDao: BaseDao
    {
        public List<Product> productList;

        public ProductDao() : base()
        {
            productList = db.Products.ToList();
        }

        public Product GetByID(int id)
        {
            return db.Products.Find(id);
        }

        public bool Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Edit(Product entity)
        {
            try
            {
                Product product = db.Products.Find(entity.Id);
                product.NameProduct = entity.NameProduct;
                product.ImportPrice = entity.ImportPrice;
                product.Guarantee = entity.Guarantee;
                product.Sale = entity.Sale;
                product.Profix = entity.Profix;
                product.Amount = entity.Amount;
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
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
