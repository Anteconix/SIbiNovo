using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibi
{
    public class PagamentoCRUD
    {
        public string codigo, nome, valor, tipo;
        public BancoDados bd;
        public Tela tl;
        public int posicao;


        public PagamentoCRUD(BancoDados banco, Tela tela)
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
            this.posicao = bd.buscar("Pagamento", this.codigo);

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
                        bd.gravar("pagamento", new Pagamento(this.codigo, this.nome, this.valor,this.tipo));
                    }
                }
            }
            else
            {
                // alteração / exclusão
                Pagamento obj = (Pagamento)bd.recuperar("Pagamento", this.posicao);
                this.valor = obj.Valor;
                this.tipo = obj.Tipo;

                this.mostrarDados();
                resp = tl.fazerPergunta(11, 14, "Deseja alterar/excluir/voltar (A/E/V):");
                if (resp.ToUpper() == "A")
                {
                    this.tl.limparArea(27, 9, 69, 10);
                    this.entrarDados();
                    resp = tl.fazerPergunta(11, 14, "Confirma alteração (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        Pagamento novoObj = new Pagamento(this.codigo, this.nome, this.valor, this.tipo);
                        bd.alterar("Pagamento", obj, novoObj);
                    }
                }
                if (resp.ToUpper() == "E")
                {
                    resp = tl.fazerPergunta(11, 14, "Confirma exclusão (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.excluir("Pagamento", obj);
                    }
                }
            }

        }

        public void montarTela()
        {
            tl.montarMoldura(10, 6, 70, 13, "Cadastro de Pagamento");
            Console.SetCursorPosition(11, 8);
            Console.Write("Codigo: ");
            Console.SetCursorPosition(11, 9);
            Console.Write("Valor:  ");
            Console.SetCursorPosition(11, 10);
            Console.Write("Tipo:   ");
            Console.SetCursorPosition(11, 11);
        }

        public void entrarCodigo()
        {
            Console.SetCursorPosition(27, 8);
            this.codigo = Console.ReadLine();
        }

        public void entrarDados()
        {
            Console.SetCursorPosition(27, 9);
            this.valor = Console.ReadLine();
            Console.SetCursorPosition(27, 10);
            this.tipo = Console.ReadLine();
            Console.SetCursorPosition(27, 11);
        }

        public void mostrarDados()
        {
            Console.SetCursorPosition(27, 9);
            Console.Write(this.valor);
            Console.SetCursorPosition(27, 10);
            Console.Write(this.tipo);
            Console.SetCursorPosition(27, 11);
        }
    }
}
