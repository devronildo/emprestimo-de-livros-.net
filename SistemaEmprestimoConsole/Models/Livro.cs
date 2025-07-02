using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEmprestimoConsole.Models
{
    public class Livro
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Autor {  get; set; }

        public bool Disponivel { get; set; } = true;

        internal Livro FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
