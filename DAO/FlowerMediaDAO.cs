using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class FlowerMediaDAO
    {
        private readonly ApplicationDbContext _context;

        public FlowerMediaDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddFlowerMediaAsync(FlowerMedia flowerMedia)
        {
            await _context.FlowerMedia.AddAsync(flowerMedia);
            await _context.SaveChangesAsync();
        }

        public async Task<FlowerMedia> GetFlowerMediaByIdAsync(string id)
        {
            return await _context.FlowerMedia
                .FirstOrDefaultAsync(fm => fm.Id == id);
        }

        public FlowerMedia GetFlowerMediaByIdAsyncV2(string id)
        {
            return  _context.FlowerMedia
                .FirstOrDefault(fm => fm.Id == id);
        }

        // Method to update flower media
        public void UpdateFlowerMediaAsync(FlowerMedia flowerMedia)
        {
            var existingFlowerMedia = GetFlowerMediaByIdAsyncV2(flowerMedia.Id);
            if (existingFlowerMedia != null)
            {
                existingFlowerMedia.Caption = flowerMedia.Caption;
                existingFlowerMedia.MediaType = flowerMedia.MediaType;
                _context.SaveChanges();
            }
        }

        public async Task DeleteFlowerMediaAsync(string id)
        {
            var flowerMedia = await _context.FlowerMedia.FindAsync(id);
            if (flowerMedia != null)
            {
                _context.FlowerMedia.Remove(flowerMedia);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<FlowerMedia>> GetAllMediaByFlowerIdAsync(string flowerId)
        {
            return await _context.FlowerMedia
                .Where(fm => fm.FlowerId == flowerId)
                .ToListAsync();
        }

        public List<FlowerMedia> GetAllMediaByFlowerIdAsyncV2(string flowerId)
        {
            return _context.FlowerMedia
                .Where(fm => fm.FlowerId == flowerId)
                .ToList();
        }
    }
}
