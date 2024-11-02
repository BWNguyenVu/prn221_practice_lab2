﻿using BusinessObject;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IFlowerRepository
    {
        Task AddFlowerAsync(Flower flower);
        Flower GetFlowerByIdAsync(string id);
        void UpdateFlowerAsync(Flower flower);
        Task DeleteFlowerAsync(string id);
        Task<List<Flower>> GetAllFlowersByUserIdAsync(string userId);
        Task<List<Flower>> SearchFlowersByNameAndByUserIdAsync(string name, string userId);
        Task<List<FlowerResponseDTO>> GetAllFlowersAsync();
    }
}