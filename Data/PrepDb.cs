namespace PlatformService.Data
{
    public  static class PrepDb
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        
            private static void SeedData(AppDbContext context )
            {
                if(!context.Platforms.Any())
                {
                    Console.WriteLine ("Seeding data now..."); 

                    context.Platforms.AddRange(
                        new Models.Platform(){ Name = ".Net", Publisher="Microsoft", Cost = "Free"},
                        new Models.Platform(){ Name = "Oracle DataBase", Publisher="Oracle", Cost = "100"},
                        new Models.Platform(){ Name = "Kubernetes", Publisher="Cloud Native", Cost = "Free"},
                        new Models.Platform(){ Name = "Java", Publisher="Oracle", Cost = "Free"}
                    );

                    context.SaveChanges();

                }
                else 
                {
                    Console.WriteLine ("Data already exist");
                }

                
            }
    }
}