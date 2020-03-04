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
                        CategoryName = "Bilgisayar"
                    },
                    new Category 
                    {
                        CategoryName = "Cep Telefonu"
                    },
                    new Category 
                    {
                        CategoryName = "Temizlik",
                        Description = "Temizlik malzemeleri"
                    },
                    new Category 
                    {
                        CategoryName = "İçecek",
                        Description = "Alkolsüz içecekler"
                    },
                    new Category 
                    {
                        CategoryName = "Peynir",
                        Description = "Peynir çeşitleri"
                    },
                };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }
        }
    }
}