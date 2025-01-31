﻿using BILTIFUL.Core.Entidades.Base;
using System;
using System.Collections.Generic;

namespace BILTIFUL.Core.Entidades
{
    public class Producao : EntidadeBase
    {
        public DateTime DataProducao { get; set; } = DateTime.Now;
        //ID produto
        public string Produto { get; set; }
        public string Quantidade { get; set; }
        public List<ItemProducao> Itens { get; set; }

        public Producao()
        {
            Itens = new List<ItemProducao>();
        }

        public Producao(string id, string produto, string quantidade)
        {
            Id = id;
            Produto = produto;
            Quantidade = quantidade;
            Itens = new List<ItemProducao>();
        }

        public Producao(string produto, string quantidade)
        {
            Produto = produto;
            Quantidade = quantidade.PadLeft(5, '0');
        }

        public Producao(string id,DateTime dataProducao, string produto, string quantidade)
        {
            Id = id;
            DataProducao = dataProducao;
            Produto = produto;
            Quantidade = quantidade;
        }

        public string Dados()
        {

            return $"\n\t\t\tData: {DataProducao.ToString("dd/MM/yyyy")}\n" +
                    $"\t\t\tQuantidade Produto: {Quantidade}";
        }


        public string ConverterParaEDI()
        {
            return $"{Id.PadLeft(5, '0')}{DataProducao.ToString("dd/MM/yyyy")}{Produto}{Quantidade.PadLeft(5, '0')}";
        }
        public string DadosProducao()
        {
            return $"-------------------------------------------\nId: {Id}\nData produção: {DataProducao}\n-------------------------------------------";
        }
    }
}
