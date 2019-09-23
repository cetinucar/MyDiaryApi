using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDiary.DTOs
{
    public class UpdateMetinDTO
    {
        public int Id { get; set; }

        public string Baslik { get; set; }

        public string Icerik { get; set; }
    }
}