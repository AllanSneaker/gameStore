﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.DTO
{
   public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Views { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
