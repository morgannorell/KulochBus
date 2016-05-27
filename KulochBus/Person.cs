using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace KulochBus
{
    //abstract klass (går endast att ärva från)
    public abstract class Person
    {
        public string PersonId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string SecurityNr { get; set; }
        public string Address { get; set;  }
        public string Zipcode { get; set; }
        public string City { get; set;  }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Cellphone { get; set; }
    }
}
