using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBusiness
{
    public interface IGerenciadorLivro
    {
        List<Livro> Listar();
        void Gravar(Livro livro);
        void Excluir(Livro livro);
    }
}
