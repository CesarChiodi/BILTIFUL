using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BILTIFUL.Core.Entidades;
using BILTIFUL.Core.Entidades.Enums;

namespace BILTIFUL.Core.Crud
{
    public class CrudCadastro
    {


        private static string dataSource = @"DESKTOP-RSRL7O0";
        private static string database = "Bealtiful_Project";
        private static string username = "sa";
        private static string password = "123456";
        static string connString = @"Data Source= " + dataSource + ";Initial Catalog="
            + database + ";Persist Security Info = True;User ID=" + username + ";Password=" + password;

        SqlConnection connection = new SqlConnection(connString);

        public void InsertFornecedor(Fornecedor fornecedor)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_FORNECEDOR_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
                    sql_cmnd.Parameters.AddWithValue("@RAZAO_SOCIAL", fornecedor.RazaoSocial);
                    sql_cmnd.Parameters.AddWithValue("@DATA_ABERTURA", fornecedor.DataAbertura);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }

        public List<Fornecedor> SelectFornecedor()
        {
            List<Fornecedor> fornecedor = new List<Fornecedor>();

            connection.Open();

            String sql = "SELECT CNPJ, RAZAO_SOCIAL, DATA_ABERTURA, ULTIMA_COMPRA, DATA_CADASTRO, SITUACAO_FORNECEDOR FROM dbo.FORNECEDOR";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fornecedor.Add(new Fornecedor
                        {
                            CNPJ = reader["CNPJ"].ToString(),
                            RazaoSocial = reader["RAZAO_SOCIAL"].ToString(),
                            DataAbertura = DateTime.Parse(reader["DATA_ABERTURA"].ToString()),
                            UltimaCompra = DateTime.Parse(reader["ULTIMA_COMPRA"].ToString()),
                            DataCadastro = DateTime.Parse(reader["DATA_CADASTRO"].ToString()),
                            Situacao = (Situacao)char.Parse(reader["SITUACAO_FORNECEDOR"].ToString())
                        });
                    }
                }

            }
            connection.Close();
            return fornecedor;
        }

        public void InsertCliente(Cliente cliente)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_CLIENTE_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@CPF", SqlDbType.NVarChar).Value = cliente.CPF;
                    sql_cmnd.Parameters.AddWithValue("@NOME_CLIENTE", SqlDbType.NVarChar).Value = cliente.Nome;
                    sql_cmnd.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
                    sql_cmnd.Parameters.AddWithValue("@SEXO", SqlDbType.Char).Value = cliente.Sexo;
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }

        public List<Cliente> SelectCliente()
        {
            List<Cliente> clientes = new List<Cliente>();

            connection.Open();

            String sql = "SELECT CPF, NOME_CLIENTE,	DATA_NASCIMENTO, SEXO, ULTIMA_COMPRA, DATA_CADASTRO, SITUACAO_CLIENTE FROM dbo.CLIENTE";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                         {
                            CPF = reader["CPF"].ToString(),
                            Nome = reader["NOME_CLIENTE"].ToString(),
                            DataNascimento = DateTime.Parse(reader["DATA_NASCIMENTO"].ToString()),
                            Sexo = (Sexo)char.Parse(reader["SEXO"].ToString()),
                            UltimaCompra = DateTime.Parse(reader["ULTIMA_COMPRA"].ToString()),
                            DataCadastro = DateTime.Parse(reader["DATA_CADASTRO"].ToString()),
                            Situacao = (Situacao)char.Parse(reader["SITUACAO_FORNECEDOR"].ToString())
                        });
                    }
                }

            }
            connection.Close();
            return clientes;
        }

        public void InsertProduto(Produto produto)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_PRODUTO_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@CODIGO_BARRAS", produto.CodigoBarras);
                    sql_cmnd.Parameters.AddWithValue("@NOME_PRODUTO", produto.Nome);
                    sql_cmnd.Parameters.AddWithValue("@VALOR_VENDA", produto.ValorVenda);
                    sql_cmnd.Parameters.AddWithValue("@ULTIMA_VENDA", produto.UltimaVenda);
                    sql_cmnd.Parameters.AddWithValue("@DATA_CADASTRO", produto.DataCadastro);
                    sql_cmnd.Parameters.AddWithValue("@SITUACAO_PRODUTO", produto.Situacao);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }

        public List<Produto> SelectProduto()
        {
            List<Produto> produtos = new List<Produto>();

            connection.Open();

            String sql = "SELECT CODIGO_BARRAS, NOME_PRODUTO, VALOR_VENDA, ULTIMA_VENDA, DATA_CADASTRO, SITUACAO_PRODUTO FROM dbo.PRODUTO";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produtos.Add(new Produto
                        {
                            CodigoBarras = reader["CODIGO_BARRAS"].ToString(),
                            Nome = reader["CODIGO_COMPRA"].ToString(),
                            ValorVenda = reader["VALOR_VENDA"].ToString(),
                            UltimaVenda = DateTime.Parse(reader["ULTIMA_VENDA"].ToString()),
                            DataCadastro = DateTime.Parse(reader["DATA_CADASTRO"].ToString()),
                            Situacao = (Situacao)char.Parse(reader["SITUACAO_FORNECEDOR"].ToString())
                        });
                    }
                }

            }
            connection.Close();
            return produtos;
        }

        public void InsertCompra(Compra compra)
        {
            
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_COMPRA_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@VALOR_TOTAL", compra.ValorTotal);
                    sql_cmnd.Parameters.AddWithValue("@CNPJ_FORNECEDOR", compra.Fornecedor);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }

        public List<Compra> SelectCompra()
        {
            List<Compra> compras = new List<Compra>();

            connection.Open();

            String sql = "SELECT CODIGO_COMPRA, DATA_COMPRA, VALOR_TOTAL, CNPJ_FORNECEDOR FROM dbo.COMPRA";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        compras.Add(new Compra
                        {
                            Id = reader["CODIGO_COMPRA"].ToString(),
                            DataCompra = DateTime.Parse(reader["DATA_COMPRA"].ToString()),
                            ValorTotal = reader["VALOR_TOTAL"].ToString(),
                            Fornecedor = reader["CNPJ_FORNECEDOR"].ToString()   
                            
                        });
                    }
                }

            }
            connection.Close();
            return compras;
        }

        public void InsertMateriaPrima(MPrima mPrima)
        {
            mPrima.Id = "MP" + (Count() + 1).ToString().PadLeft(4, '0');
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_MATERIA_PRIMA_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@CODIGO_MATERIA_PRIMA", mPrima.Id);
                    sql_cmnd.Parameters.AddWithValue("@NOME_MATERIA_PRIMA ", SqlDbType.VarChar).Value = mPrima.Nome;
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }

        public List<MPrima> SelectMateriaPrima()
        {
            List<MPrima> mPrimas = new List<MPrima>();

            connection.Open();

            String sql = "SELECT CODIGO_MATERIA_PRIMA, NOME_MATERIA_PRIMA, ULTIMA_COMPRA, DATA_CADASTRO, SITUACAO_MATERIA_PRIMA FROM dbo.MATERIA_PRIMA";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mPrimas.Add(new MPrima
                        {
                            Id = reader["CODIGO_MATERIA_PRIMA"].ToString(),
                            Nome = reader["NOME_MATERIA_PRIMA"].ToString(),
                            UltimaCompra = DateTime.Parse(reader["ULTIMA_COMPRA"].ToString()),
                            DataCadastro = DateTime.Parse(reader["DATA_CADASTRO"].ToString()),
                            Situacao = (Situacao)char.Parse(reader["SITUACAO_MATERIA_PRIMA"].ToString()),
                        });
                    }
                }

            }
            connection.Close();
            return mPrimas;
        }

        public int Count()
        {
            connection.Open();
            int GReader = 0;
            string query = "SELECT COUNT(*) FROM MATERIA_PRIMA_PROC";
            var reader = new SqlCommand(query, connection).ExecuteReader();
            reader.Read();
            GReader = reader.GetInt32(0);
            connection.Close();
            return GReader;
        }

        public void InsertVendaCliente(Venda venda)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_VENDA_CLIENTE_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@VALOR_TOTAL", venda.ValorTotal);
                    sql_cmnd.Parameters.AddWithValue("@CPF_CLIENTE", venda.Cliente);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }

        public List<Venda> SelectVenda()
        {
            List<Venda> vendas = new List<Venda>();

            connection.Open();

            String sql = "SELECT CODIGO_VENDA, DATA_VENDA, VALOR_TOTAL, CPF_CLIENTE, FROM dbo.VENDA_CLIENTE";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vendas.Add(new Venda
                        {
                            Id = reader["CODIGO_VENDA"].ToString(),
                            DataVenda = DateTime.Parse(reader["DATA_VENDA"].ToString()),
                            ValorTotal = reader["VALOR_TOTAL"].ToString(),
                            Cliente = reader["CPF_CLIENTE"].ToString(),   
                        });
                    }
                }
            }
            connection.Close();
            return vendas;
        }

        public void InsertItemCompra(ItemCompra itemCompra)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_ITEM_COMPRA_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@QUANTIDADE", itemCompra.Quantidade);
                    sql_cmnd.Parameters.AddWithValue("@VALOR_UNITARIO", itemCompra.ValorUnitario);
                    sql_cmnd.Parameters.AddWithValue("@TOTAL_ITEM", itemCompra.TotalItem);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }



        public void InsertProducao(Producao producao) //renato me explicou +/-
        {
            try
            {
                string query;
                connection.Open();
                query = "INSERT INTO PRODUCAO" + "(PRODUTO, QUANTIDADE) " + "OUTPUT Inserted.CODIGO_PRODUTO " + "VALUES(@PODUCAO, @QUANTIDADE)";

                SqlCommand command = new SqlCommand(query, connection);
              
                command.Parameters.AddWithValue("@PRODUTO", producao.Produto);
                command.Parameters.AddWithValue("@QUANTIDADE", producao.Quantidade);
                var reader = command.ExecuteReader();
                reader.Read();
                producao.Id = reader["CODIGO_PRODUCAO"].ToString();    //nao ta pronto ainda
                producao.Itens.ForEach(e =>
                {
                    e.Id = producao.Id;
                    
                });
                connection.Close();
               
            }
            
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }

        public List<Producao> SelectProducao()
        {
            List<Producao> producaos = new List<Producao>();

            connection.Open();

            String sql = "SELECT CODIGO_PRODUCAO, DATA_PRODUCAO, QUANTIDADE, CODIGO_BARRAS_PRODUTO FROM dbo.MATERIA_PRIMA";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        producaos.Add(new Producao
                        {
                            Id = reader["CODIGO_PRODUCAO"].ToString(),
                            DataProducao = DateTime.Parse(reader["DATA_PRODUCAO"].ToString()),
                            Quantidade = reader["QUANTIDADE"].ToString(),
                            Produto = reader["CODIGO_BARRAS_PRODUTO"].ToString()
                        });
                    }
                }
            }
            connection.Close();
            return producaos;
        }

        public void InsertItemProducao(ItemProducao itemProducao)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_ITEM_PRODUCAO_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@CODIGO_MATERIA_PRIMA", itemProducao.MateriaPrima);
                    sql_cmnd.Parameters.AddWithValue("@QUANTIDADE_MATERIA_PRIMA", itemProducao.QuantidadeMateriaPrima);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }

        public void InsertItemVenda(ItemVenda itemvenda)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_ITEM_VENDA_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@ITEM_VENDA_CODIGO_VENDA", itemvenda.Id);
                    sql_cmnd.Parameters.AddWithValue("@ITEM_VENDA_CODIGO_BARRAS_PRODUTO", itemvenda.Produto);
                    sql_cmnd.Parameters.AddWithValue("@QUANTIDADE", itemvenda.Quantidade);
                    sql_cmnd.Parameters.AddWithValue("@TOTAL_ITEM", itemvenda.TotalItem);
                    sql_cmnd.Parameters.AddWithValue("@VALOR_UNITARIO", itemvenda.ValorUnitario);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }

        public void BloqueioCliente(string CPF)
        {
            using (connection)
            {
                connection.Open();
                SqlCommand sql_cmnd = new SqlCommand("INSERT INTO RISCO(CPF) VALUES(@CPF)", connection);
                sql_cmnd.Parameters.AddWithValue("@CPF", CPF);
                sql_cmnd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public bool CompativelBloqueioCliente(string CPF)
        {
            bool clienteCompativel;
            connection.Open();
            String Sql = "SELECT CPF FROM dbo.RISCO WHERE CPF =" + CPF + "";
            using (SqlCommand command = new SqlCommand(Sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    clienteCompativel = reader.Read();
                }
            }
            connection.Close();
            return clienteCompativel;
        }

        public void RemoverBloqueioCliente(string CPF)
        {
            using (connection)
            {
                connection.Open();
                SqlCommand sql_cmnd = new SqlCommand("INSERT INTO RISCO(CPF) VALUES(@CPF)", connection);
                sql_cmnd.Parameters.AddWithValue("@CPF", CPF);
                sql_cmnd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void BloqueioFornecedor(string CNPJ)
        {
            using (connection)
            {
                connection.Open();
                SqlCommand sql_cmnd = new SqlCommand("INSERT INTO BLOQUEADO(CNPJ) VALUES(@CNPJ)", connection);
                sql_cmnd.Parameters.AddWithValue("@CNPJ", CNPJ);
                sql_cmnd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public bool CompativelBloqueioFornecedor(string CNPJ)
        {
            bool fornecedorCompativel;
            connection.Open();
            String Sql = "SELECT CNPJ FROM dbo.BLOQUEADO WHERE CNPJ =" + CNPJ + "";
            using (SqlCommand command = new SqlCommand(Sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    fornecedorCompativel = reader.Read();
                }
            }
            connection.Close();
            return fornecedorCompativel;
        }

        public void RemoverBloqueioFornecedor(string CNPJ)
        {
            using (connection)
            {
                connection.Open();
                SqlCommand sql_cmnd = new SqlCommand("INSERT INTO BLOQUEADO(CNPJ) VALUES(@CNPJ)", connection);
                sql_cmnd.Parameters.AddWithValue("@CNPJ", CNPJ);
                sql_cmnd.ExecuteNonQuery();
                connection.Close();
            }
        }


    }
}
