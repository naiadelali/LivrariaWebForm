using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Livro
    {
        private int _id { get; set; }
        private string _nome { get; set; }
        private string _genero { get; set; }
        private string _sinopse { get; set; }

        public int id 
        {
            get { return _id; }
            set { _id = value; }
        }

        public string nome 
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public string sinopse
        {
            get { return _sinopse; }
            set { _sinopse = value; }
        }
    }
}
