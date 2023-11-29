using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibi
{
    public class ReservaCRUD
    {
        private string codigo, nome, cpf, endereco, telefone;
        private BancoDados bd;
        private Tela tl;
        private int posicao;

        public ReservaCRUD(BancoDados banco, Tela tela)
        {
            this.bd = banco;
            this.tl = tela;
        }

        public void executarCRUD()
        {
            string resp;
            this.posicao = -1;

            this.montarTela();
            this.entrarCodigo();
            this.posicao = bd.buscar("reserva", this.codigo);

            if (this.posicao == -1)
            {
                // cadastro
                resp = tl.fazerPergunta(11, 11, "Registro NÃO encontrado. Deseja cadastrar (S/N):");
                if (resp.ToUpper() == "S")
                {
                    this.entrarDados();
                    resp = tl.fazerPergunta(11, 11, "Confirma cadastro (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.gravar("reserva", new Reserva(this.nome, this.cpf, this.endereco, this.telefone));
                    }
                }
            }
            else
            {
                // alteração / exclusão
                Reserva obj = (Reserva)bd.recuperar("reserva", this.posicao);
                this.nome = obj.Nome;
                this.cpf = obj.cpf;
                this.endereco = obj.endereco;
                this.telefone = obj.telefone;

                this.mostrarDados();
                resp = tl.fazerPergunta(11, 11, "Deseja alterar/excluir/voltar (A/E/V):");
                if (resp.ToUpper() == "A")
                {
                    this.tl.limparArea(27, 9, 69, 10);
                    this.entrarDados();
                    resp = tl.fazerPergunta(11, 11, "Confirma alteração (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        Reserva novoObj = new Reserva(this.nome, this.cpf, this.endereco, this.telefone);
                        bd.alterar("reserva", obj, novoObj);
                    }
                }
                if (resp.ToUpper() == "E")
                {
                    resp = tl.fazerPergunta(11, 11, "Confirma exclusão (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.excluir("reserva", obj);
                    }
                }
            }

        }

        public void montarTela()
        {
            tl.montarMoldura(10, 6, 70, 12, "Cadastro de Reserva");
            Console.SetCursorPosition(11, 8);
            Console.Write("Nome        :");
            Console.SetCursorPosition(11, 9);
            Console.Write("CPF         :");
            Console.SetCursorPosition(11, 10);
            Console.Write("Endereco    :");
            Console.SetCursorPosition(11, 11);
            Console.Write("Telefone    :");
        }

        public void entrarCodigo()
        {
            Console.SetCursorPosition(27, 8);
            this.codigo = Console.ReadLine();
        }

        public void entrarDados()
        {
            Console.SetCursorPosition(27, 9);
            this.nome = Console.ReadLine();
            Console.SetCursorPosition(27, 10);
            this.cpf = Console.ReadLine();
            Console.SetCursorPosition(27, 11);
            this.endereco = Console.ReadLine();
            Console.SetCursorPosition(27, 12);
            this.telefone = Console.ReadLine();
        }

        public void mostrarDados()
        {
            Console.SetCursorPosition(27, 9);
            Console.Write(this.nome);
            Console.SetCursorPosition(27, 10);
            Console.Write(this.cpf);
            Console.SetCursorPosition(27, 11);
            Console.Write(this.endereco);
            Console.SetCursorPosition(27, 12);
            Console.Write(this.telefone);
        }
    }
}
