using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;

namespace DAO
{
    public class FlowerDAO
    {
        private readonly ApplicationDbContext _context;

        public FlowerDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to add a flower
        public async Task AddFlowerAsync(Flower flower)
        {
            await _context.Flowers.AddAsync(flower);
            await _context.SaveChangesAsync();
        }

        // Method to get a flower by ID
        public Flower GetFlowerByIdAsync(string id)
        {
            return _context.Flowers
                .FirstOrDefault(f => f.Id == id);
        }


        // Method to update a flower
        public void UpdateFlowerAsync(Flower flower)
        {
            var existingFlower = GetFlowerByIdAsync(flower.Id);

            // Check if the flower exists in the database
            if (existingFlower != null)
            {
                existingFlower.RowVersion = flower.RowVersion;
                existingFlower.Price = flower.Price;
                existingFlower.FlowerMedia = flower.FlowerMedia;
                existingFlower.Description = flower.Description;
                existingFlower.Category = flower.Category;
                existingFlower.Name = flower.Name;

                _context.SaveChanges();
            }
            else
            {
                throw new NullReferenceException("The flower with the specified ID does not exist.");
            }
        }

        // Method to delete a flower
        public async Task DeleteFlowerAsync(string id)
        {
            var flower = await _context.Flowers.FindAsync(id);
            if (flower != null)
            {
                _context.Flowers.Remove(flower);
                await _context.SaveChangesAsync();
            }
        }

        // Method to get all flowers (optional)
        public async Task<List<Flower>> GetAllFlowersByUserIdAsync(string userId)
        {
            return await _context.Flowers
                .Where(f => f.AccountId == userId)
                .ToListAsync();
        }

        public async Task<List<Flower>> SearchFlowersByNameAndByUserIdAsync(string name, string userId)
        {
            // Filter flowers by both name and userId
            return await _context.Flowers
                .Where(f => f.Name.Contains(name) && f.AccountId == userId)
                .ToListAsync();
        }


        public async Task<List<FlowerResponseDTO>> GetAllFlowersAsync()
        {
            // Fetch all flowers with their related media
            var flowers = await _context.Flowers
                .Include(f => f.FlowerMedia) // Eager loading FlowerMedia.
                .Include(f => f.Account)
                .ToListAsync();

            // Map to FlowerResponseDTO
            var flowerResponseList = flowers.Select(flower => new FlowerResponseDTO
            {
                Id = flower.Id,
                Category = flower.Category,
                Name = flower.Name,
                Description = flower.Description,
                Price = flower.Price,
                AccountId = flower.Account?.Id,
                FlowerMedia = flower.FlowerMedia.Select(media => new FlowerMediaResponseDTO
                {
                    Id = media.Id,
                    ImageUrl = media.ImageUrl,
                    MediaType = media.MediaType,
                    Caption = media.Caption
                }).ToList(),
                Account = new FlowerResponseDTO.AccountResponseDTO
                {
                    name = flower.Account?.Name // Assuming 'Name' is a property of Account
                }
            }).ToList();

            return flowerResponseList;
        }
    }
}
