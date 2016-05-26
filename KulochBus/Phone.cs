using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace KulochBus
{
    class Phone:Person
    {
        public string Areacode { get; set; }
        public string Phonenumber { get; set; }
    }
}
