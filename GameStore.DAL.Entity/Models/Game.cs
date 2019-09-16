using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.DAL.Entity.Models
{
	public class Game
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Views { get; set; }
	}
}
