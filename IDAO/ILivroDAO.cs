using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface ILivroDAO
    {
        List<Livro> Listar();
        void Gravar(Livro livro);
        void Excluir(Livro livro);
    }
}
