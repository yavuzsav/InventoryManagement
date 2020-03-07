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
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                        Name = "Bilgisayar"
                    },
                    new Category
                    {
                        Name = "Cep Telefonu"
                    },
                    new Category
                    {
                        Name = "Temizlik",
                        Description = "Temizlik malzemeleri"
                    },
                    new Category
                    {
                        Name = "İçecek",
                        Description = "Alkolsüz içecekler"
                    },
                    new Category
                    {
                        Name = "Peynir",
                        Description = "Peynir çeşitleri"
                    },
                };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }

            if (!context.Stores.Any())
            {
                var stores = new List<Store>
                {
                    new Store
                    {
                        Name = "Merkez Depo Ankara",
                        Province = "Ankara",
                        District = "Yenimahalle",
                        Address = "Yenimahalle/Ankara"
                    },
                    new Store
                    {
                        Name = "Bursa Depo - 1",
                        Province = "Bursa",
                        District = "Nilüfer",
                        Address = "Nilüfer/Bursa"
                    }
                };

                await context.Stores.AddRangeAsync(stores);
                await context.SaveChangesAsync();
            }
        }
    }
}