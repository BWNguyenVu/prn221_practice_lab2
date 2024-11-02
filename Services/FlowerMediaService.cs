using BusinessObject;
using DAO;
using Microsoft.Extensions.Logging;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FlowerMediaService : IFlowerMediaService
    {
        private readonly IFlowerMediaRepository _flowerMediaRepository;
        private readonly ILogger<FlowerMediaService> _logger;

        public FlowerMediaService(IFlowerMediaRepository flowerMediaRepository, ILogger<FlowerMediaService> logger)
        {
            _flowerMediaRepository = flowerMediaRepository;
            _logger = logger;
        }

        public Task AddFlowerMediaAsync(FlowerMedia flowerMedia)
        {
            return _flowerMediaRepository.AddFlowerMediaAsync(flowerMedia);
        }

        public async Task<FlowerMedia> GetFlowerMediaByIdAsync(string id)
        {
            return await _flowerMediaRepository.GetFlowerMediaByIdAsync(id);
        }

        public void UpdateFlowerMediaAsync(FlowerMedia flowerMedia)
        {
            _flowerMediaRepository.UpdateFlowerMediaAsync(flowerMedia);
        }

        public async Task DeleteFlowerMediaAsync(string id)
        {
            await _flowerMediaRepository.DeleteFlowerMediaAsync(id);
        }
        public async Task<List<FlowerMedia>> GetAllMediaByFlowerIdAsync(string flowerId)
        {
            return await _flowerMediaRepository.GetAllMediaByFlowerIdAsync(flowerId);
        }

        public List<FlowerMedia> GetAllMediaByFlowerIdAsyncV2(string flowerId)
        {
            return _flowerMediaRepository.GetAllMediaByFlowerIdAsyncV2(flowerId);
        }
    }
}
