using System;
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

        public Product GetByID(string id, string idPackage)
        {
            return db.Products.Find(id, idPackage);
        }

        public Product FindByIDAndPackage(string id, string idPackage)
        {
            return db.Products.Where(x => (x.Id == id) && (x.IdPackage == idPackage)).FirstOrDefault();
        }

        public Product CreateNewProduct(string idPackage = "L00001")
        {
            Product product = new Product();
            var lastProduct = db.Products.OrderByDescending(c => c.Id).FirstOrDefault();
            if (lastProduct == null) product.Id = "S00001";
            else
            {
                //using string substring method to get the number of the last inserted employee's EmployeeID 
                product.Id = "S" + (Convert.ToInt32(lastProduct.Id.Substring(1, lastProduct.Id.Length - 1)) + 1).ToString("D5");
            }
            product.IdPackage = idPackage;
            return product;
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
                Product product = FindByIDAndPackage(entity.Id, entity.IdPackage);
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

        public bool Delete(string id, string idPackage)
        {
            try
            {
                Product product = FindByIDAndPackage(id, idPackage);
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
