using System;
using System.Collections.Generic;

namespace Treinamento
{
    class Pessoa
    {
        // Atributos
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        private List<Carro> _carro { get; set; }
        private List<Pessoa> _pessoa { get; set; }

        // Construtores
        public Pessoa()
        {
            _pessoa = new List<Pessoa>();
            _carro = new List<Carro>();
        }
        public Pessoa(string nome, string sobreNome, int idade)
        {
            Nome = nome;
            Sobrenome = sobreNome;
            Idade = idade;
            _carro = null;
        }
        // Metodos
        public string GetDadosCadastrados()
        {
            string dadosPessoais = "";
            string dadosCarro = "";
            if (_carro == null)
            {
                dadosCarro = "";
            }
            else
            {
                foreach (var item in _carro)
                {
                    dadosCarro += $"{item.GetDadosCarro()} \n";
                }
            }


            dadosPessoais += $"Nome: {Nome} {Sobrenome} Idade: {Idade}";
            
            

            //dadosPessoais = $"Nome: {Nome} {Sobrenome} Idade: {Idade}";
            return $"Dados Pessoais:\n {dadosPessoais} \n Dados Carro:\n {dadosCarro}";

        }

        public int GetDataNascimento()
        {
            int ano = DateTime.Now.Year;
            return (ano - Idade);
        }
        public bool EhMaiorDeIdade()
        {
            return (Idade > 17);
        }
        public void RecebeCarro(List<Carro> carro)
        {
            _carro = carro;
        }
        public void RecebePessoa(List<Pessoa> pessoa)
        {
            _pessoa = pessoa;
        }
        public void LimpaListaCarros(){
            _carro.Clear();
        }
    }
}