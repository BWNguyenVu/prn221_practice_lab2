using BusinessObject;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FlowerMediaRepository : IFlowerMediaRepository
    {
        private readonly FlowerMediaDAO _flowerMediaDAO;

        public FlowerMediaRepository(FlowerMediaDAO flowerMediaDAO)
        {
            _flowerMediaDAO = flowerMediaDAO;
        }
        public Task AddFlowerMediaAsync(FlowerMedia flowerMedia)
        {
            return _flowerMediaDAO.AddFlowerMediaAsync(flowerMedia);
        }

        public async Task<FlowerMedia> GetFlowerMediaByIdAsync(string id)
        {
            return await _flowerMediaDAO.GetFlowerMediaByIdAsync(id);
        }

        public void UpdateFlowerMediaAsync(FlowerMedia flowerMedia)
        {
            _flowerMediaDAO.UpdateFlowerMediaAsync(flowerMedia);
        }

        public async Task DeleteFlowerMediaAsync(string id)
        {
            await _flowerMediaDAO.DeleteFlowerMediaAsync(id);
        }
        public async Task<List<FlowerMedia>> GetAllMediaByFlowerIdAsync(string flowerId)
        {
            return await _flowerMediaDAO.GetAllMediaByFlowerIdAsync(flowerId);
        }

        public List<FlowerMedia> GetAllMediaByFlowerIdAsyncV2(string flowerId)
        {
            return _flowerMediaDAO.GetAllMediaByFlowerIdAsyncV2(flowerId);
        }
    }
}
