using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BacklogChamados.Services;
using BacklogChamados.Models;
using System.Data;
namespace BacklogChamados.Controllers
{
    public class UsuarioController
    {
        public static Usuario Autenticar(int id, string senha)
        {
            DataBaseMariaDB db = new DataBaseMariaDB();

            try{
                string query = @"SELECT * FROM usuarios
                                WHERE id = @id AND senha = @senha";

                db.LimparParametros();
                db.AdicionarParametros("@id", id);
                db.AdicionarParametros("@senha", senha);

                DataTable tabela = db.ExecutarConsulta(CommandType.Text, query);

                if (tabela.Rows.Count == 1)
                {
                    DataRow linha = tabela.Rows[0];

                    Usuario usuario = new Usuario
                    {
                        Id = Convert.ToInt32(linha["id"]),
                        Nome = linha["nome"].ToString(),
                        Email = linha["email"].ToString(),
                        Senha = linha["senha"].ToString()
                    };
                    return usuario;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao autenticar usuário: " + ex.Message);
            }
        }
    }
}
