using MyMVCNET.UI.Models.DBFirst;
using MyMVCNET.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Caching;

namespace MyMVCNET.UI.Models.DAL
{
    public class KategoriDAL
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public List<KategoriVM> KategoriGetir()
        {
            //   List<KategoriVM> krm = new List<KategoriVM>();
            //   //krm = db.Categories.ToList().ToArray();
            //   return krm;
            //  return db.Categories.ToList();

            return (from c in db.Categories
                    //where c.AktifMi == true
                    //orderby c.CategoryID ascending
                    select new KategoriVM()
                    {
                        ID = c.CategoryID,
                        KategoriAdi = c.CategoryName
                    })/*.OrderBy(a=>a.ID)*/.ToList();

        }


        public KategoriVM IDBilgisineGoreKategoriBilgileriniGetir(int? kategoriID)
        {
            var hede = db.Categories
                .Where(a => a.CategoryID == kategoriID)
                .Select(a => new KategoriVM() { ID = a.CategoryID, KategoriAdi = a.CategoryName })
                .SingleOrDefault();
            return hede;
        }

        public void KategoriyiVeriTabanınaEkle(Categories categories)
        {
	        db.Categories.Add(categories);
	        db.SaveChanges();
        }

        public int KategoriyiVeriTabanındaDuzenle(KategoriVM duzenlenmisData)
        {
            //todo attach
            var eskiVeri = db.Categories.Find(duzenlenmisData.ID);
            eskiVeri.CategoryName = duzenlenmisData.KategoriAdi;
            return db.SaveChanges();
        }

        public List<Categories> CacheTest()
        {
	        var query = from c in db.Categories
		        select c;

	        return query.ToList();
            

        }
    }
}