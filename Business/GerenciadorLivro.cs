using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
using IBusiness;

namespace Business
{
    public class GerenciadorLivro : IGerenciadorLivro
    {
        private LivroDAO livroDAO = new LivroDAO();

        public List<Livro> Listar()
        {
            return livroDAO.Listar();
        }

        public void Gravar(Livro livro)
        {
            livroDAO.Gravar(livro);
        }

        public void Excluir(Livro livro)
        {
            livroDAO.Excluir(livro);
        }
    }
}
