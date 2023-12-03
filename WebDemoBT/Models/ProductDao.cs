namespace WebDemoBT.Models
{
    public class ProductDao
    {
        private static ProductDao instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDao();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Product> GetAllroducts()
        {
            List<Product> products = new List<Product>()
            {
             new Product {Id = 1, Name = "Laptop Dell", Description="Laptop", Price=160000.500M},
             new Product {Id = 2, Name = "Laptop Acer", Description="Laptop", Price=170000.500M},
             new Product {Id = 3, Name = "Laptop Dell", Description="Laptop", Price=190000.500M},
             new Product {Id = 4, Name = "Laptop Asus", Description="Laptop", Price=165000.500M},
             new Product {Id = 5, Name = "Bàn phím Logitech", Description="Bàn phím", Price=18000.500M},
             new Product {Id = 6, Name = "Chuột Dell", Description="Chuột", Price=1800.500M},
            };
            return products;
        }
    }
}
