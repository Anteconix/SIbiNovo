﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibi
{
    public class RedeHoteisCRUD
    {
        private string codigo, nome;
        private BancoDados bd;
        private Tela tl;
        private int posicao;


        public RedeHoteisCRUD(BancoDados banco, Tela tela)
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
            this.posicao = bd.buscar("RedeHoteis", this.codigo);

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
                        bd.gravar("RedeHoteis", new RedeHoteis(this.codigo, this.nome));
                    }
                }
            }
            else
            {
                // alteração / exclusão
                RedeHoteis obj = (RedeHoteis)bd.recuperar("RedeHoteis", this.posicao);
                this.nome = obj.Nome;               

                this.mostrarDados();
                resp = tl.fazerPergunta(11, 14, "Deseja alterar/excluir/voltar (A/E/V):");
                if (resp.ToUpper() == "A")
                {
                    this.tl.limparArea(27, 9, 69, 10);
                    this.entrarDados();
                    resp = tl.fazerPergunta(11, 14, "Confirma alteração (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        RedeHoteis novoObj = new RedeHoteis(this.codigo,this.nome);
                        bd.alterar("RedeHoteis", obj, novoObj);
                    }
                }
                if (resp.ToUpper() == "E")
                {
                    resp = tl.fazerPergunta(11, 14, "Confirma exclusão (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.excluir("RedeHoteis", obj);
                    }
                }
            }

        }

        public void montarTela()
        {
            tl.montarMoldura(10, 6, 70, 13, "Cadastro de RedeHoteis");
            Console.SetCursorPosition(11, 8);
            Console.Write("Codigo:  ");
            Console.SetCursorPosition(11, 9);
            Console.Write("Nome:    ");
            Console.SetCursorPosition(11, 10);
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
        }

        public void mostrarDados()
        {
            Console.SetCursorPosition(27, 9);
            Console.Write(this.nome);
            Console.SetCursorPosition(27, 10);
        }
    }
}
