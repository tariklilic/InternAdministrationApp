﻿using Backend.Models;

namespace Backend.Dtos
{
    public class AddSelectionDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }


    }
}
