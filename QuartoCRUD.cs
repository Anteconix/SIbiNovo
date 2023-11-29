using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibi
{
    public class QuartoCRUD
    {
        private string codigo, nome, numero, tipo, disponivel;
        private BancoDados bd;
        private Tela tl;
        private int posicao;


        public QuartoCRUD(BancoDados banco, Tela tela)
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
            this.posicao = bd.buscar("Quarto", this.codigo);

            if (this.posicao == -1)
            {
                // cadastro
                resp = tl.fazerPergunta(11, 14, "Registro NÃO encontrado. Deseja cadastrar (S/N):");
                if (resp.ToUpper() == "S")
                {
                    this.entrarDados();
                    resp = tl.fazerPergunta(11, 14, "Confirma cadastro (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.gravar("Quarto", new Quarto(this.codigo, this.nome, this.numero, this.tipo, this.disponivel));
                    }
                }
            }
            else
            {
                // alteração / exclusão
                Quarto obj = (Quarto)bd.recuperar("Quarto", this.posicao);
                this.numero = obj.Numero;
                this.tipo = obj.Tipo;
                this.disponivel = obj.Disponivel;

                this.mostrarDados();
                resp = tl.fazerPergunta(11, 14, "Deseja alterar/excluir/voltar (A/E/V):");
                if (resp.ToUpper() == "A")
                {
                    this.tl.limparArea(27, 9, 69, 10);
                    this.entrarDados();
                    resp = tl.fazerPergunta(11, 14, "Confirma alteração (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        Quarto novoObj = new Quarto(this.codigo, this.nome, this.numero, this.tipo, this.disponivel);
                        bd.alterar("Quarto", obj, novoObj);
                    }
                }
                if (resp.ToUpper() == "E")
                {
                    resp = tl.fazerPergunta(11, 14, "Confirma exclusão (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.excluir("Quarto", obj);
                    }
                }
            }

        }

        public void montarTela()
        {
            tl.montarMoldura(10, 6, 70, 13, "Cadastro de Quarto");
            Console.SetCursorPosition(11, 8);
            Console.Write("Codigo:     ");
            Console.SetCursorPosition(11, 9);
            Console.Write("Numero:     ");
            Console.SetCursorPosition(11, 10);
            Console.Write("Tipo:       ");
            Console.SetCursorPosition(11, 11);
            Console.Write("Disponivel: ");
            Console.SetCursorPosition(11, 12);
        }

        public void entrarCodigo()
        {
            Console.SetCursorPosition(27, 8);
            this.codigo = Console.ReadLine();
        }

        public void entrarDados()
        {
            Console.SetCursorPosition(27, 9);
            this.numero = Console.ReadLine();
            Console.SetCursorPosition(27, 10);
            this.tipo = Console.ReadLine();
            Console.SetCursorPosition(27, 11);
            this.disponivel = Console.ReadLine();
            Console.SetCursorPosition(27, 12);
        }

        public void mostrarDados()
        {
            Console.SetCursorPosition(27, 9);
            Console.Write(this.numero);
            Console.SetCursorPosition(27, 10);
            Console.Write(this.tipo);
            Console.SetCursorPosition(27, 11);
            Console.Write(this.disponivel);
            Console.SetCursorPosition(27, 12);
        }
    }
}
