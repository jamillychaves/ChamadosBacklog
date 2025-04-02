using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BacklogChamados.Models;
using BacklogChamados.Services;
using System.Data;

namespace BacklogChamados.Controllers
{
    public class ChamadoController
    {
        public static void CadastrarChamado(Chamado chamado)
        {
            var db = new DataBaseMariaDB();

            string query = @"INSERT INTO chamados 
                            (numero_chamado, telefone, status, data_cadastro, data_ultima_movimentacao, usuario_id)
                            VALUES (@numero, @telefone, @status, @cadastro, @movimentacao, @usuarioId)";

            db.LimparParametros();
            db.AdicionarParametros("@numero", chamado.NumeroChamado);
            db.AdicionarParametros("@telefone", chamado.Telefone);
            db.AdicionarParametros("@status", chamado.Status);
            db.AdicionarParametros("@cadastro", chamado.DataCadastro);
            db.AdicionarParametros("@movimentacao", chamado.DataUltimaMovimentacao);
            db.AdicionarParametros("@usuarioId", chamado.UsuarioId);

            db.ExecutarManipulacao(CommandType.Text, query);
        }

        // Busca chamados por usuário
        public static List<Chamado> BuscarChamadosPorUsuario(int usuarioId)
        {
            var db = new DataBaseMariaDB();
            var lista = new List<Chamado>();

            string query = @"SELECT * FROM chamados WHERE usuario_id = @usuarioId";

            db.LimparParametros();
            db.AdicionarParametros("@usuarioId", usuarioId);

            DataTable tabela = db.ExecutarConsulta(CommandType.Text, query);

            foreach (DataRow row in tabela.Rows)
            {
                lista.Add(new Chamado
                {
                    Id = Convert.ToInt32(row["id"]),
                    NumeroChamado = row["numero_chamado"].ToString(),
                    Telefone = row["telefone"].ToString(),
                    Status = row["status"].ToString(),
                    DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                    DataUltimaMovimentacao = Convert.ToDateTime(row["data_ultima_movimentacao"]),
                    UsuarioId = Convert.ToInt32(row["usuario_id"])
                });
            }
            return lista;
        }

        // Atualiza status do chamado
        public static void AtualizarStatus(int chamadoId, string novoStatus)
        {
            var db = new DataBaseMariaDB();

            string query = @"UPDATE chamados SET status = @status, data_ultima_movimentacao = @movimentacao WHERE id = @id";

            db.LimparParametros();
            db.AdicionarParametros("@status", novoStatus);
            db.AdicionarParametros("@movimentacao", DateTime.Now);
            db.AdicionarParametros("@id", chamadoId);

            db.ExecutarManipulacao(CommandType.Text, query);
        }

        // Registrar movimentações em log
        public static void RegistrarMovimentacao(int  chamadoId, string statusAnterior, string statusNovo)
        {
            var db = new DataBaseMariaDB();

            string query = @"INSERT INTO movimentacoes (chamado_id, status_anterior, status_novo, data_movimentacao) VALUES (@id, @antigo, @novo, @data)";

            db.LimparParametros();
            db.AdicionarParametros("@id", chamadoId);
            db.AdicionarParametros("@antigo", statusAnterior);
            db.AdicionarParametros("@novo", statusNovo);
            db.AdicionarParametros("@data", DateTime.Now);

            db.ExecutarManipulacao(CommandType.Text, query);
        }

        // Método para buscar movimentações do dia
        public static List<Movimentacao> BuscarMovimentacaoDoDia(int usuarioId)
        {
            var db = new DataBaseMariaDB();
            var lista = new List<Movimentacao>();

            string query = @"SELECT m.*, c.numero_chamado
                            FROM movimentacoes m
                            INNER JOIN chamados c ON c.id = m.chamado_id
                            WHERE DATE(m.data_movimentacao) = CURDATE()
                            AND c.usuario_id = @usuarioId";
            db.LimparParametros();
            db.AdicionarParametros("@usuarioId", usuarioId);

            DataTable tabela = db.ExecutarConsulta(CommandType.Text, query);

            foreach (DataRow row in tabela.Rows)
            {
                lista.Add(new Movimentacao
                {
                    Id = Convert.ToInt32(row["id"]),
                    ChamadoId = Convert.ToInt32(row["chamado_id"]),
                    NumeroChamado = row["numero_chamado"].ToString(),
                    StatusAnterior = row["status_anterior"].ToString(),
                    StatusNovo = row["status_novo"].ToString(),
                    DataMovimentacao = Convert.ToDateTime(row["data_movimentacao"])

                });
            }
            return lista;
        }
    }
}
