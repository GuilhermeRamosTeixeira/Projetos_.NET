using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAlunos
{
    public class Estudante
    {

        public string Nome { get; set; }
        public string email { get; set; }
        public int Idade { get; set; }
        public string telefone { get; set; }
        public string Serie { get; set; }
        public char Sexo { get; set; }

        public static List<Estudante> lista_Estudantes = new List<Estudante>();

       public static  string[] series = new string[]
        {
             "1º Série"
            ,"2º Série"
            ,"3º Série"
            ,"4º Série"
            ,"5º Série"
            ,"6º Série"
            ,"7º Série"
            ,"8º Série"
            ,"9º Série"
        };

        public Estudante(string nome, int idade ,string serie , char sexo ,string email, string telefone)
        {
            this.Nome = nome;
            this.Sexo = sexo;
            this.Idade = idade;
            this.Serie = serie;
            this.email = email;
            this.telefone = telefone;
        }


    }
}
