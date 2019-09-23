using Microsoft.AspNet.Identity;
using MyDiary.DTOs;
using MyDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyDiary.Controllers
{
    [Authorize]
    public class MetinController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public string UserId { get { return User.Identity.GetUserId(); } }



        //GET:api/MEtin/MetinGetir
        [HttpGet]
        public IHttpActionResult MetniGetir(int id)
        {
            return Ok(db.Metinler.FirstOrDefault(x => x.YazarId == UserId && x.Id == id));
        }



        //GET:api/Metin/MetinleriGetir
        [HttpGet]
        public IHttpActionResult MetinleriGetir()
        {
            return Ok(db.Metinler.Where(x => x.YazarId == UserId).ToList());
        }



        //POST:api/Metin/MetinEkle
        [HttpPost]
        public IHttpActionResult MetinEkle(PostMetinDTO model)
        {
            Metin metin = new Metin
            {
                YazarId = User.Identity.GetUserId(),
                OluşturulmaTarihi = DateTime.Now,
                Baslik = model.Baslik,
                Icerik = model.Icerik,
            };
            db.Metinler.Add(metin);
            db.SaveChanges();
            return Ok(metin);

        }



        //PUT:api/Metin/MetinGuncelle
        [HttpPut]
        public IHttpActionResult MetinGuncelle(UpdateMetinDTO model)
        {
            if (ModelState.IsValid)
            {
                Metin metin = db.Metinler.Find(model.Id);
                if (metin.YazarId != UserId)
                {
                    return Unauthorized();
                }
                metin.Baslik = model.Baslik;
                metin.Icerik = model.Icerik;
                metin.DüzenlenmeTarihi = DateTime.Now;

                db.SaveChanges();

                return Ok(metin);
            }
            return BadRequest();


        }



        //DELETE:api/Metin/MetinSil/1
        [HttpDelete]
        public IHttpActionResult MetinSil(int id)
        {

            Metin metin = db.Metinler.Find(id);

            if (metin.YazarId != UserId)
            {
                return Unauthorized();
            }

            db.Metinler.Remove(metin);
            metin.DüzenlenmeTarihi = DateTime.Now;
            db.SaveChanges();
            return Ok(metin);


        }
    }
}
