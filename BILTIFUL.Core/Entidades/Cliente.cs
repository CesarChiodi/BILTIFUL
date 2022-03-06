﻿using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Cliente
    {

        public long cpf { get; set; }
        public string nome { get; set; }
        public DateTime dnascimento { get; set; }
        public Sexo sexo { get; set; }
        public DateTime ucompra { get; set; } = DateTime.Now;
        public DateTime dcadastro { get; set; } = DateTime.Now;
        public Situacao situacao { get; set; } = Situacao.Ativo;

        public Cliente()
        {
        }

        public Cliente(long cpf, string nome, DateTime dnascimento, Sexo sexo)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.dnascimento = dnascimento;
            this.sexo = sexo;
            this.situacao = situacao;
        }

        public Cliente(long cpf, string nome, DateTime dnascimento, Sexo sexo, DateTime ucompra, DateTime dcadastro, Situacao situacao)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.dnascimento = dnascimento;
            this.sexo = sexo;
            this.ucompra = ucompra;
            this.dcadastro = dcadastro;
            this.situacao = situacao;
        }

        public string ConverterParaEDI()
        {
            return $"{cpf}{nome.PadRight(50,' ')}{dnascimento.ToString("dd/MM/yyyy")}{(char)sexo}{ucompra.ToString("dd/MM/yyyy")}{dcadastro.ToString("dd/MM/yyyy")}{(char)situacao}";
        }
        public override string ToString()
        {
            return "Nome: "+nome+"\nCPF: "+cpf+"\nData de nascimento: "+dnascimento.ToString("dd/MM/yyyy") + "\nSexo: "+(char)sexo+"\nUltima compra: "+ucompra.ToString("dd/MM/yyyy") + "\nData de cadastro: "+dcadastro.ToString("dd/MM/yyyy");
        }
    }

}
