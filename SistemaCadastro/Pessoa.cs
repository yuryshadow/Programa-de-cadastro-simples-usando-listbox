using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
    class Pessoa
    {
        public String Nome { get; set; }
        public String DataNascimento { get; set; }
        public String EstadoCivil { get; set; }
        public String Telefone { get; set; }
        public bool casaPropria { get; set; }
        public bool Veiculo { get; set; }
        public char Sexo { get; set; }
    }
}
