using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.DataAccess.Model
{
	public class Photo : IEntityBase
	{
		public int Id { get; set; }
		public byte[] PhotoFile { get; set; }
		public string ImageMimeType { get; set; }
		public bool IsDefault { get; set; }
		public byte[] Version { get; set; }
		public bool? Deleted { get; set; }
		public virtual Employee Employee { get; set; }	
	}
}
