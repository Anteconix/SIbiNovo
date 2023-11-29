using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibi
{
    // esta classe fornece serviço de guarda dos dados
    public class BancoDados
    {
        List<Hospede> hospedes = new List<Hospede>();
        List<Hotel> hoteis = new List<Hotel>();
        List<Pagamento> pagamentos = new List<Pagamento>();
        List<Quarto> quartos = new List<Quarto>();
        List<RedeHoteis> redeshoteis = new List<RedeHoteis>();
        List<Reserva> reservas = new List<Reserva>();
        List<ServicoExtra> servicosextras = new List<ServicoExtra>();


        public BancoDados()
        {
            // cria alguns registros para realizar permitir o uso rápido do sistema

            // adiciona alguns hoteis
            this.hoteis.Add(new Hotel("1", "Mont'Rei", "Joinville"));
            this.hoteis.Add(new Hotel("2", "Glorian Real", "Barra Velha"));

            // adiciona alguns Quartos
            this.quartos.Add(new Quarto("1", "Carlos", "1001", "Suíte Premium", "s"));
            this.quartos.Add(new Quarto("2", "Bryann", "101", "Suíte Báscia", "n"));

            // adicona alguns hospedes
            this.hospedes.Add(new Hospede("1", "Carlos Magno", "00000000000", "Rua Fulano de Tal, 101", "4799999-9999"));
            this.hospedes.Add(new Hospede("2", "Bryann Lucas", "10000000000", "Rua Fulano de Tal, 102", "4799999-9991"));
            this.hospedes.Add(new Hospede("3", "Rafael Pavesi", "20000000000", "Rua Fulano de Tal, 103", "4799999-9992"));
        }

        public int buscar(string onde, string oque)
        {
            int posicao = -1;

            if (onde == "hospede") posicao = this.hospedes.FindIndex(o => o.Codigo == oque);
            if (onde == "hotel") posicao = this.hoteis.FindIndex(o => o.Codigo == oque);
            if (onde == "pagamento") posicao = this.pagamentos.FindIndex(o => o.Codigo == oque);
            if (onde == "quarto") posicao = this.quartos.FindIndex(o => o.Codigo == oque);
            if (onde == "redehotel") posicao = this.redeshoteis.FindIndex(o => o.Codigo == oque);
            if (onde == "reserva") posicao = this.reservas.FindIndex(o => o.Codigo == oque);
            if (onde == "servicoextra") posicao = this.servicosextras.FindIndex(o => o.Codigo == oque);

            return posicao;
        }

        public object recuperar(string onde, int qual)
        {
            Object obj = null;
            if (onde == "hospede") obj = this.hospedes[qual];
            if (onde == "hotel") obj = this.hoteis[qual];
            if (onde == "pagamento") obj = this.pagamentos[qual];
            if (onde == "quarto") obj = this.quartos[qual];
            if (onde == "redehotel") obj = this.redeshoteis[qual];
            if (onde == "reserva") obj = this.reservas[qual];
            if (onde == "servicoextra") obj = this.servicosextras[qual];
            return obj;
        }


        public void gravar(string onde, Object oque)
        {
            if (onde == "hospede") this.hospedes.Add((Hospede)oque);
            if (onde == "hotel") this.hoteis.Add((Hotel)oque);
            if (onde == "pagamento") this.pagamentos.Add((Pagamento)oque);
            if (onde == "quarto") this.quartos.Add((Quarto)oque);
            if (onde == "redehotel") this.redeshoteis.Add((RedeHoteis)oque);
            if (onde == "reserva") this.reservas.Add((Reserva)oque);
            if (onde == "servicoextra") this.servicosextras.Add((ServicoExtra)oque);

        }


        public void alterar(string onde, Object oque, Object novo)
        {
            if (onde == "hospede")
            {
                int x = this.buscar("hospede", ((Hospede)oque).Codigo);
                this.hospedes[x] = (Hospede)novo;
            }
            if (onde == "hotel")
            {
                int x = this.buscar("hotel", ((Hotel)oque).Codigo);
                this.hoteis[x] = (Hotel)novo;
            }
            if (onde == "pagamento")
            {
                int x = this.buscar("pagamento", ((Pagamento)oque).Codigo);
                this.pagamentos[x] = (Pagamento)novo;
            }
            if (onde == "quarto")
            {
                int x = this.buscar("quarto", ((Quarto)oque).Codigo);
                this.quartos[x] = (Quarto)novo;
            }
            if (onde == "redehotel")
            {
                int x = this.buscar("redehotel", ((RedeHoteis)oque).Codigo);
                this.redeshoteis[x] = (RedeHoteis)novo;
            }
            if (onde == "reserva")
            {
                int x = this.buscar("reserva", ((Reserva)oque).Codigo);
                this.reservas[x] = (Reserva)novo;
            }
            if (onde == "servicoextra")
            {
                int x = this.buscar("servicoextra", ((ServicoExtra)oque).Codigo);
                this.servicosextras[x] = (ServicoExtra)novo;
            }
        }


        public void excluir(string onde, Object oque)
        {
            if (onde == "hospede") this.hospedes.Remove((Hospede)oque);
            if (onde == "hotel") this.hoteis.Remove((Hotel)oque);
            if (onde == "pagamento") this.pagamentos.Remove((Pagamento)oque);
            if (onde == "quarto") this.quartos.Remove((Quarto)oque);
            if (onde == "redehotel") this.redeshoteis.Remove((RedeHoteis)oque);
            if (onde == "reserva") this.reservas.Remove((Reserva)oque);
            if (onde == "servicoextra") this.servicosextras.Remove((ServicoExtra)oque);
        }


        public string recuperarNome(string onde, string oque)
        {
            string result = "Não encontrado";
            int pos = this.buscar(onde, oque);

            if (pos >= 0)
            {
                if (onde == "hospede") result = this.hospedes[pos].Nome;
                if (onde == "hotel") result = this.hoteis[pos].Nome;
                if (onde == "pagamento") result = this.pagamentos[pos].Nome;
                if (onde == "quarto") result = this.quartos[pos].Nome;
                if (onde == "redehotel") result = this.redeshoteis[pos].Nome;
                if (onde == "reserva") result = this.reservas[pos].Nome;
                if (onde == "servicoextra") result = this.servicosextras[pos].Nome;
            }
            return result;
        }
    }
}