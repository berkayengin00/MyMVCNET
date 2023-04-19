using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCNET.UI.Models.DAL
{
	public class DBProductsAddVM
	{
		public string UrunAdi { get; set; }
		public decimal UrunFiyati { get; set; }
		public short StokMiktari { get; set; }
		public int KategoriId { get; set; }
		public int Tedarikci { get; set; }
	}
}