using System.Collections.Generic;
using System.Linq;
using shopapp.webui.Models;

namespace shopapp.webui.Data
{
    public static class ProductRepository//örnek oluşturmasın 1 tane olsun tek excel gibi
    {
        private static List<Product> _product = null;
        static ProductRepository()
        {
            _product = new List<Product>{
           new Product{ProductId=1, Name="Iphone 8", Price=3000,Description="İyi telefon",IsApproved=true,ImageUrl="1.jpg",CategoryId=1},
           new Product{ProductId=2,Name="Iphone X", Price=6000,Description="Güzel telefon",IsApproved=true,ImageUrl="2.jpg",CategoryId=1},
           new Product{ProductId=9,Name="Iphone X", Price=6000,Description="Güzel telefon",IsApproved=true,ImageUrl="2.jpg",CategoryId=1},
           new Product{ProductId=10,Name="Iphone X", Price=6000,Description="Güzel telefon",IsApproved=true,ImageUrl="2.jpg",CategoryId=1},
           new Product{ProductId=3,Name="Iphone 9", Price=6000,Description="Güzel telefon",IsApproved=false,ImageUrl="3.jpg",CategoryId=1},
           new Product{ProductId=4,Name="Iphone 10", Price=6000,Description="Güzel telefon",ImageUrl="4.jpg",CategoryId=1},
           new Product{ProductId=5, Name="Lenova 8", Price=3000,Description="İyi Bilgisayar",IsApproved=true,ImageUrl="1.jpg",CategoryId=2},
           new Product{ProductId=6,Name="Lenova X", Price=6000,Description="Güzel Bilgisayar",IsApproved=true,ImageUrl="2.jpg",CategoryId=2},
           new Product{ProductId=7,Name="Elektronik 9", Price=6000,Description="Güzel Elektronik",IsApproved=false,ImageUrl="3.jpg",CategoryId=3},
           new Product{ProductId=8,Name="Elektronik 10", Price=6000,Description="Güzel Elektronik",ImageUrl="4.jpg",CategoryId=3}
           };

        }

        public static List<Product> Products
        {
            get
            {
                return _product;
            }
        }

        public static void AddProduct(Product product)
        {
            _product.Add(product);
        }
        public static Product GetProductById(int Id)
        {
            return _product.FirstOrDefault(i => i.ProductId == Id);
        }

        public static void EditProduct(Product product){//bakıyo yeni gelen bilgiyi eski bilginin üzerie atıyor tabi altta idyi kontrol ediyor
            foreach (var p in _product)
            {
                if (p.ProductId==product.ProductId)//eğer dışarıdan gönderdiğimiz pid product idye eşitse güncellemek istediğimiz ürüne ulaştık demektir.
                {
                    p.Name=product.Name;//dışardan gelen içerdekine gitsin
                    p.Price=product.Price;
                    p.ImageUrl=product.ImageUrl;
                    p.Price=product.Price;
                    p.Description=product.Description;
                    p.IsApproved=product.IsApproved;
                    p.CategoryId=product.CategoryId;
                }
            }
        }




    }
}