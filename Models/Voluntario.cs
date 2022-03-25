using System;

namespace Meadote.Models
{
    public class Voluntario
    {
        //objetivo: representar os atributos da classe, considerando o tipo de variável
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Email {get; set;}
        public string Telefone {get; set;}
        public DateTime DataNascimento {get; set;}
        public string Sexo {get; set;}
    }
}
