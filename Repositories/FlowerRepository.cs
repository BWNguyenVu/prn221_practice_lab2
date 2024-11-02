using BusinessObject;
using DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly FlowerDAO _flowerDAO;

        public FlowerRepository(FlowerDAO flowerDAO)
        {
            _flowerDAO = flowerDAO;
        }
        public Task AddFlowerAsync(Flower flower)
        {
            return _flowerDAO.AddFlowerAsync(flower);
        }

        public Flower GetFlowerByIdAsync(string id)
        {
            return _flowerDAO.GetFlowerByIdAsync(id);
        }

        public void UpdateFlowerAsync(Flower flower)
        {
            _flowerDAO.UpdateFlowerAsync(flower);
        }

        public async Task DeleteFlowerAsync(string id)
        {
            await _flowerDAO.DeleteFlowerAsync(id);
        }

        public async Task<List<Flower>> GetAllFlowersByUserIdAsync(string userId)
        {
            return await _flowerDAO.GetAllFlowersByUserIdAsync(userId);
        }

        public async Task<List<Flower>> SearchFlowersByNameAndByUserIdAsync(string name, string userId)
        {
            return await _flowerDAO.SearchFlowersByNameAndByUserIdAsync(name, userId);
        }
        public async Task<List<FlowerResponseDTO>> GetAllFlowersAsync()
        {
            return await _flowerDAO.GetAllFlowersAsync();
        }
        

    }
}
