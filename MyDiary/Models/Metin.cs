using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyDiary.Models
{
    [Table("Metinler")]
    public class Metin
    {
        public int Id { get; set; }

        [Required]
        public string YazarId { get; set; }

        [Required]
        public string Baslik { get; set; }

        public string Icerik { get; set; }

        [Required]
        public DateTime? OluşturulmaTarihi { get; set; }

        public DateTime? DüzenlenmeTarihi { get; set; }

        [ForeignKey("YazarId")]
        public virtual ApplicationUser Yazar { get; set; }


    }
}