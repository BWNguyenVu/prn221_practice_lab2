using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IFlowerMediaService
    {
        Task AddFlowerMediaAsync(FlowerMedia flowerMedia);
        Task<FlowerMedia> GetFlowerMediaByIdAsync(string id);
        void UpdateFlowerMediaAsync(FlowerMedia flowerMedia);
        Task DeleteFlowerMediaAsync(string id);
        Task<List<FlowerMedia>> GetAllMediaByFlowerIdAsync(string flowerId);
        List<FlowerMedia> GetAllMediaByFlowerIdAsyncV2(string flowerId);
    }
}
