using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Web;

namespace MyMVCNET.UI.Validation
{
	public class AgeControl:ValidationAttribute
	{
		private int _yasBaslangic = 0;
		private int _yasBitis = 0;
		public AgeControl(int yasBaslangic,int yasBitis)
		{
			_yasBaslangic = yasBaslangic;
			_yasBitis = yasBitis;

		}
		
		public override bool IsValid(object value)
		{
			int gelenDeger = Convert.ToInt32(value);
			if (gelenDeger<_yasBaslangic || gelenDeger >_yasBitis)
			{
				// hata
				ErrorMessage = "Aralık Dışında bir değer girilmeye çalışıldı";
				return false;
			}
			return true;
		}
	}
}