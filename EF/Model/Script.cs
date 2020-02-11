using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EF.Model
{
    public class Script
    {
        public string Издательство { get; set; }
        public int Роман { get; set; }
        public int ИсторическийРоман { get; set; }
        public int ПриключенческийРоман { get; set; }
        public int ПоэмаВПрозе { get; set; }
        public int Трагедия { get; set; }
    }
}
