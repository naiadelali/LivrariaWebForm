using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class LivroDAO : ILivroDAO
    {
        public List<Livro> Listar()
        {
            DataTable dt = DbCommands.Consult("select * from Livro");
            List<Livro> lstLivros = new List<Livro>();

            foreach (DataRow dr in dt.Rows)
            {
                lstLivros.Add(new Livro()
                {
                    id = (int)dr["id"],
                    nome = (string)dr["nome"],
                    genero = (string)dr["genero"],
                    sinopse = (string)dr["sinopse"]
                });
            }

            return lstLivros;
        }

        public void Gravar(Livro livro)
        {
            string sql = string.Empty;

            if (livro.id <= 0)
                sql = "insert into Livro (nome,genero,sinopse) values(@nome,@genero,@sinopse)";
            else
                sql = "update Livro set nome = @nome, genero= @genero, sinopse = @sinopse where id = @id";

            DbCommands.Execute(sql, new List<SqlParameter>() 
            { 
                new SqlParameter("@id",livro.id),
                new SqlParameter("@nome",livro.nome),
                new SqlParameter("@genero",livro.genero),
                new SqlParameter("@sinopse",livro.sinopse),
            });
        }

        public void Excluir(Livro livro)
        {
            string sql = "delete from Livro where id = @id";

            DbCommands.Execute(sql, new List<SqlParameter>() 
            { 
                new SqlParameter("@id",livro.id),
            });
        }
    }
}
