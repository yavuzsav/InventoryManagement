using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            var categoryId1 = new Guid("415feee1-1f26-4cf7-993f-a868a6271309");
            var categoryId2 = new Guid("4d44e08e-ace5-4a43-b860-4e6de32578ac");
            var categoryId3 = new Guid("c6fda773-3e6a-4590-bbcf-c860a31a38b0");

            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                        Id = categoryId1,
                        Name = "Bilgisayar"
                    },
                    new Category
                    {
                        Id = categoryId2,
                        Name = "Cep Telefonu"
                    },
                    new Category
                    {
                        Id = categoryId3,
                        Name = "İçecek",
                        Description = "Alkolsüz içecekler"
                    },
                };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }

            var storeId1 = new Guid("1ab868c3-bb1d-4a48-84f0-9fa55613cbdc");
            var storeId2 = new Guid("73f82824-c0c3-45b9-b573-17984243468c");

            if (!context.Stores.Any())
            {
                var stores = new List<Store>
                {
                    new Store
                    {
                        Id = storeId1,
                        Name = "Merkez Depo Ankara",
                        Province = "Ankara",
                        District = "Yenimahalle",
                        Address = "Yenimahalle/Ankara"
                    },
                    new Store
                    {
                        Id = storeId2,
                        Name = "Bursa Depo - 1",
                        Province = "Bursa",
                        District = "Nilüfer",
                        Address = "Nilüfer/Bursa"
                    }
                };

                await context.Stores.AddRangeAsync(stores);
                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Macbook Pro",
                        Barcode = "123-123-123",
                        QuantityPerUnit = "1 adet",
                        UnitPrice = 25000,
                        CategoryId = categoryId1,
                        StoreId = storeId1
                    },
                    new Product
                    {
                        Name = "Asus Zenbook",
                        Barcode = "111-111-111",
                        QuantityPerUnit = "1 adet",
                        UnitPrice = 15000,
                        CategoryId = categoryId1,
                        StoreId = storeId1
                    },
                    new Product
                    {
                        Name = "IPhone 6",
                        Barcode = "222-222-222",
                        QuantityPerUnit = "1 adet",
                        UnitPrice = 3000,
                        CategoryId = categoryId2,
                        StoreId = storeId2
                    },
                    new Product
                    {
                        Name = "IPhone 10",
                        Barcode = "333-333-333",
                        QuantityPerUnit = "1 adet",
                        UnitPrice = 10000,
                        CategoryId = categoryId2,
                        StoreId = storeId1
                    },
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}