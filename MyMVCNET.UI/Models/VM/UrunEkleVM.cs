using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace MyMVCNET.UI.Models.VM
{
	public class UrunEkleVM
	{
		public string UrunAdi { get; set; }
		public decimal UrunFiyati { get; set; }
		public short StokMiktari { get; set; }
		public int KategoriId { get; set; }
		public int Tedarikci { get; set; }

		public List<SelectListItem> KategoriListesi { get; set; }
		public List<SelectListItem> TedarikciListesi { get; set; }
		
	}
}