using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Sibi
{
    public class Hotel
    {
        // campos
        private string codigo;
        private string nome;
        private string cidade;

        private List<Reserva> reservas = new List<Reserva>();
        private List<Pagamento> pagamentos = new List<Pagamento>();
        private List<ServicoExtra> servicosExtras = new List<ServicoExtra>();
        private List<Hospede> hospedes = new List<Hospede>();
        private List<Quarto> quartos = new List<Quarto>();

        // propriedades
        public string Codigo { get => codigo; private set => codigo = value; }
        public string Nome { get => nome; private set => nome = value; }
        public string Cidade { get => cidade; private set => cidade = value; }

        // método construtor
        public Hotel(string cod, string nom, string cida)
        {
            this.codigo = cod;
            this.nome = nom;
            this.cidade = cida;
        }
    }
}