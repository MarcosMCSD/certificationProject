using _01_DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_DAL.DataModel;

namespace _01_DAL.Dto
{
    public class ProductDetail
    {
        #region constructors
        public ProductDetail() { }

        public ProductDetail(int id,
            string name, double price, int subcategory, int employeeId)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.SubcategoryId = subcategory;
            this.EmployeeId = employeeId;
        }
        #endregion

        #region properties
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int SubcategoryId { get; set; }
        public int EmployeeId { get; set; }
        #endregion

        #region methods
        //Cloned object to be displayed on GUI
        public static ProductDetail CreateFromDBObject(Product dbProduct)
        {
            ProductDetail productDetail =
                new ProductDetail(dbProduct.Id, dbProduct.Name, dbProduct.Price,
                dbProduct.SubcategoryId, dbProduct.EmployeeId);

            return productDetail;
        }

        //Create
        public ProductDetail PersistToDb()
        {
            using (Context context = new Context())
            {
                Product dbProduct =
                    new Product(Name, Price, SubcategoryId, EmployeeId);

                context.Products.Add(dbProduct);
                context.SaveChanges();

                return CreateFromDBObject(dbProduct);
            }
        }

        //Cloned objects to be displayed on GUI
        public static IEnumerable<ProductDetail> CreateFromDBObjects(IEnumerable<Product> dbProducts)
        {
            List<ProductDetail> products = new List<ProductDetail>();

            foreach (var dbProduct in dbProducts)
                products.Add(CreateFromDBObject(dbProduct));

            return products;
        }

        //Update
        public ProductDetail UpdateObjectInDb(ProductDetail productDetail)
        {
            using (Context context = new Context())
            {
                Product dbProduct =
                    new Product(productDetail.Name, productDetail.Price, productDetail.SubcategoryId,
                    productDetail.EmployeeId); //duvida

                context.SaveChanges();
                return CreateFromDBObject(dbProduct);
            }
        }

        //Remove
        public bool RemoveObjectInDb(ProductDetail productDetail)
        {

            using (Context context = new Context())
            {
                Product dbProduct = context.Products.FirstOrDefault(p => p.Id == productDetail.Id);

                if (dbProduct == null)
                    return false;

                context.Products.Remove(dbProduct);
                context.SaveChanges();
                return true;
            }
        }
        #endregion
    }
}
