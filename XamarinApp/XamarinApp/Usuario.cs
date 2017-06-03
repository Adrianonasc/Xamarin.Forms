using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace XamarinApp
{
    [Table("Usuarios")]
    public class Usuario
    {
        [PrimaryKey, Unique]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public decimal salario { get; set; }
        public byte[] Foto { get; set; }

        public Usuario()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

    }

}
