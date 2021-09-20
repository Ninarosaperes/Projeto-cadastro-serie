using System;
namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        private string Titulo {get; set;}
        private Genero Genero {get; set;}
        private int Ano { get; set; }
        private Premio Premio { get; set; }
        private string Descricao { get; set; }
        private bool Excluido { get; set;}


        public Serie(int id, string titulo, Genero genero, int ano, Premio premio, string descricao)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Genero = genero;
            this.Ano = ano;
            this.Premio = premio;
            this.Descricao = descricao;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Prêmio: " + this.Premio + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido; 
            return retorno;

        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

         public int retornaId()
        {
            return this.Id;
        }

        public Premio retornaPremio()
        {
            return this.Premio;
        }

        public Genero retornaGenero()
        {
            return this.Genero;
        }

         public int retornaAno()
        {
            return this.Ano;
        }

        public string retornaDescricao()
        {
            return this.Descricao;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}