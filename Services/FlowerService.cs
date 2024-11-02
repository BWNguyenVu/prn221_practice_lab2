using BusinessObject;
using DAO;
using DTOs;
using Microsoft.Extensions.Logging; // Import the logging namespace
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class FlowerService : IFlowerService
    {
        private readonly IFlowerRepository _flowerRepository;
        private readonly ILogger<FlowerService> _logger;

        public FlowerService(IFlowerRepository flowerRepository, ILogger<FlowerService> logger)
        {
            _flowerRepository = flowerRepository;
            _logger = logger;
        }

        public async Task CreateFlowerAsync(Flower flower)
        {
            _logger.LogInformation("Creating flower: {Name}, Category: {Category}", flower.Name, flower.Category);
            await _flowerRepository.AddFlowerAsync(flower);
        }

        public Flower GetFlowerByIdAsync(string id)
        {
            _logger.LogInformation("Getting flower by ID: {Id}", id);
            return _flowerRepository.GetFlowerByIdAsync(id);
        }

        public void UpdateFlowerAsync(Flower flower)
        {
            _logger.LogInformation("Updating flower: {Id}", flower.Id);
            _flowerRepository.UpdateFlowerAsync(flower);
        }

        public async Task DeleteFlowerAsync(string id)
        {
            _logger.LogInformation("Deleting flower by ID: {Id}", id);
            await _flowerRepository.DeleteFlowerAsync(id);
        }

        public async Task<List<Flower>> GetAllFlowersByUserIdAsync(string userId)
        {
            _logger.LogInformation("Retrieving all flowers");
            return await _flowerRepository.GetAllFlowersByUserIdAsync(userId);
        }

        public async Task<List<Flower>> SearchFlowersByNameAndByUserIdAsync(string name, string userId)
        {
            _logger.LogInformation("Searching flowers by name: {Name}", name);
            return await _flowerRepository.SearchFlowersByNameAndByUserIdAsync(name, userId);
        }

        public async Task<List<FlowerResponseDTO>> GetAllFlowersAsync()
        {
            return await _flowerRepository.GetAllFlowersAsync();
        }
    }
}
