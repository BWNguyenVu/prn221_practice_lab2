using System;
using System.Collections.Generic;

namespace DTOs
{
    public class FlowerResponseDTO
    {
        public string Id { get; set; } // Assuming there's an Id in BaseEntity
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string AccountId { get; set; } // If you want to include the account ID
        public List<FlowerMediaResponseDTO> FlowerMedia { get; set; } // List of FlowerMedia DTOs

        public AccountResponseDTO Account { get; set; }

        public FlowerResponseDTO()
        {
            FlowerMedia = new List<FlowerMediaResponseDTO>();
            Account = new AccountResponseDTO();
        }

        public class AccountResponseDTO
        {
            public string name { get; set; }
            
        }
    }

    
}
