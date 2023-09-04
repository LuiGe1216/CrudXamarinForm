using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CrudXamarin.Models
{
    public class User
    {
        [PrimaryKey]
        public int id { get; set; }
        [MaxLength(50)]
        public string nombres { get; set; }
        [MaxLength(50)]
        public string apellidos { get; set; }
        [MaxLength(8)]
        public int dni { get; set; }
        [MaxLength(9)]
        public int celular { get; set; }
        [MaxLength(50)]
        public  string correo { get; set; }

        public override string ToString()
        {
            return this.nombres + "\n" + this.apellidos + "\n" + this.dni
                + "\n" + this.celular + "\n" + this.correo;
        }

    }
}
