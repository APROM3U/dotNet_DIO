using System;

namespace cad_series {
    public class Serie : EntidadeBase
    {
        #region Atributos

        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int AnoLcto {get; set;}

        // Flag Baixa corresponde a exclusão
        private bool Baixa {get; set;}

        #endregion

        #region Método Construtor

        public Serie(int codigo, Genero genero, string titulo, string descricao, int ano){
            this.id = codigo;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.AnoLcto = ano;
        }

        #endregion

        #region Override

        public override string ToString()
        {
            string retorno = "";
            retorno += $"Genero: {this.Genero} " + Environment.NewLine; // Environment.NewLine -> inseri nova linha 
            retorno += $"Título: {this.Titulo} " + Environment.NewLine;
            retorno += $"Descrição: {this.Descricao} " + Environment.NewLine;
            retorno += $"Ano de Lançamento: {this.AnoLcto} " + Environment.NewLine;
            retorno += $"Excluído: {this.Baixa} " + Environment.NewLine;
            return retorno;
        }

        #endregion

        #region Retornos
        public int retId(){
            return this.id;
        }

        public string retTitulo(){
            return this.Titulo;
        }

        public void Excluir() {
            this.Baixa = true;
        }

        public bool retornBaixado(){
            return this.Baixa;
        }

        #endregion

    } 
}