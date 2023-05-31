using PlatformService.Models;


namespace PlatformService.Data
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _context;

        public PlatformRepository(AppDbContext context)
        {
           _context = context;             
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentException(nameof(platform));
            }
           _context.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
           return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            var result =  _context.Platforms.FirstOrDefault(p =>p.Id == id);
            if (result == null)
             throw new ArgumentException(nameof(result));
            
            return result;
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}