﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibi
{
    public class HospedeCRUD
    {
        public string codigo, nome, cpf, endereco, telefone;
        public BancoDados bd;
        public Tela tl;
        public int posicao;


        public HospedeCRUD(BancoDados banco, Tela tela)
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
            this.posicao = bd.buscar("Hospede", this.codigo);

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
                        bd.gravar("Hospede", new Hospede(this.codigo, this.nome, this.cpf, this.endereco, this.telefone));
                    }
                }
            }
            else
            {
                // alteração / exclusão
                Hospede obj = (Hospede)bd.recuperar("Hospede", this.posicao);
                this.codigo = obj.Codigo;
                this.nome = obj.Nome;
                this.cpf = obj.Cpf;
                this.endereco = obj.Endereco;
                this.telefone = obj.Telefone;

                this.mostrarDados();
                resp = tl.fazerPergunta(11, 14, "Deseja alterar/excluir/voltar (A/E/V):");
                if (resp.ToUpper() == "A")
                {
                    this.tl.limparArea(27, 9, 69, 10);
                    this.entrarDados();
                    resp = tl.fazerPergunta(11, 14, "Confirma alteração (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        Hospede novoObj = new Hospede(this.codigo,this.nome, this.cpf, this.endereco, this.telefone);
                        bd.alterar("Hospede", obj, novoObj);
                    }
                }
                if (resp.ToUpper() == "E")
                {
                    resp = tl.fazerPergunta(11, 14, "Confirma exclusão (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.excluir("Hospede", obj);
                    }
                }
            }

        }

        public void montarTela()
        {
            tl.montarMoldura(10, 6, 70, 13, "Cadastro de Hospede");
            Console.SetCursorPosition(11, 8);
            Console.Write("Codigo:    ");
            Console.SetCursorPosition(11, 9);
            Console.Write("Nome:      ");
            Console.SetCursorPosition(11, 10);
            Console.Write("CPF:       ");
            Console.SetCursorPosition(11, 11);
            Console.Write("Endereço:  ");
            Console.SetCursorPosition(11, 12);
            Console.Write("Telefone:  ");
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
