using System;

namespace Treinamento
{
    class Carro
    {
        public string Nome { get; set;}
        public int Ano { get; set; }
        public decimal Valor { get; set; }
        public bool ArCondicionado { get; set; }
                
         public Carro (string nome, int ano, decimal valor, bool arCondicionado)
        {
            Nome = nome;
            Ano = ano;
            Valor = valor;
            ArCondicionado = arCondicionado;
        }
        public Carro (string nome, int ano) : this(nome, ano, 0, false) { }
        public string GetDadosCarro()
        {
            var possuiAr = ArCondicionado? "sim" : "não";
            return $"Nome: {Nome} Ano: {Ano} Valor: {Valor} Ar-Condicionado: {possuiAr}";
        }
       
    }
}