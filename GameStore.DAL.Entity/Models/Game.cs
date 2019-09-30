using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameStore.DAL.Entity.Models
{
	public class Game
	{
		public int Id { get; set; }
        [Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public uint Views { get; set; }
	}
}
