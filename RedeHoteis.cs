using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibi
{
    public class RedeHoteis
    {
        // propriedades
        private string codigo;
        private string nome;
        private List<Hotel> hoteis = new List<Hotel>();

        // getters/setters
        public string Codigo { get => codigo; private set => codigo = value; }
        public string Nome { get => nome; private set => nome = value; }

        // método construtor
        public RedeHoteis(string cod, string nom)
        {
            this.codigo = cod;
            this.nome = nom;
        }
    }
}