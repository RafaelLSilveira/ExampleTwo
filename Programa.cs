using System;
using System.Collections.Generic;
using System.IO;

namespace Treinamento
{
    class Programa : Menu
    {
        private List<Pessoa> _listPessoa = new List<Pessoa>();

        public void Executar()
        {
            int opcao = -1;
            do
            {
                LimparTela();
                Escrever(" Digite a Opção Desejada:");
                Escrever(" 1-Listar Pessoas \n 2-Cadastrar Pessoas \n 3-Exportar Informações \n 4-Editar Dados da Pessoa \n 5-Remover Pessoa \n 6-Sair");
                string valor = Ler();
                opcao = Convert.ToInt16(valor);


                switch (opcao)
                {
                    case 1:
                        ListarPessoas();
                        SegurarTela();
                        break;
                    case 2:
                        CadastrarPessoas();
                        break;
                    case 3:
                        ExportarPessoas();
                        break;
                    case 4:
                        EditarDados();
                        break;
                    case 5:
                        RemoverDados();
                        break;
                    case 6:
                        opcao = -1;
                        break;
                    default:
                        Escrever("Opção inválida.");
                        break;
                }
            } while (opcao != -1);
        }

        private void RemoverDados()
        {
            string nome = "";

            Escrever("Qual o nome da pessoa para excluir:");
            nome = Ler();
            foreach (var item in _listPessoa)
            {
                if (nome == item.Nome)
                {
                    _listPessoa.Remove(item);
                    break;
                }
            }           
            
        }

        public void ListarPessoas()
        {
            foreach (var item in _listPessoa)
            {
                Escrever(item.GetDadosCadastrados());
            }
        }

        public void CadastrarPessoas()
        {
            var pessoa = new Pessoa();

            Escrever("Digite seu primeiro nome: ");
            pessoa.Nome = Ler();

            Escrever("Digite seu Sobrenome: ");
            pessoa.Sobrenome = Ler();

            Escrever("Digite sua Idade: ");
            pessoa.Idade = int.Parse(Ler());
            if (pessoa.Idade > 17)
            {
                Escrever("Você tem Carro? (s/n)");
                if (Ler().Equals("s"))
                {
                    _cadastrarCarro(pessoa);
                }
            }
            _listPessoa.Add(pessoa);
        }

        public void ExportarPessoas()
        {
            TextWriter tw = new StreamWriter("SavedList.txt");
            foreach (var item in _listPessoa)
            {
                tw.WriteLine(item.GetDadosCadastrados());
            }

            tw.Close();

        }

        private void _cadastrarCarro(Pessoa pessoa)
        {
            Carro carro;
            List<Carro> listCarro = listCarro = new List<Carro>();
            int numCarros = 0;

            Escrever("\nVocê tem quantos carros?");
            numCarros = int.Parse(Ler());

            while (numCarros > 0)
            {
                carro = new Carro(null, 0, 0, false);

                Escrever("\nDigite o Nome:");
                carro.Nome = Ler();

                Escrever("Digite o Ano:");
                carro.Ano = int.Parse(Ler());

                Escrever("Digite o Valor:");
                carro.Valor = int.Parse(Ler());

                Escrever("Tem Ar-Condicionado? (s/n)");
                if (Ler().Equals("s"))
                {
                    carro.ArCondicionado = true;
                }
                else
                {
                    carro.ArCondicionado = false;
                }

                numCarros--;
                listCarro.Add(carro);
            }
            pessoa.RecebeCarro(listCarro);
        }
        public void EditarDados()
        {
            string nome = "";
            Escrever("Qual o nome da pessoa para alterar o cadastro:");
            nome = Ler();
            foreach (Pessoa pessoa in _listPessoa)
            {

                if (pessoa.Nome.Equals(nome))
                {
                    AlterarPessoa(pessoa);
                    return;
                }
            }

            Escrever("Pessoa nao encontrada!!");
        }

        public void AlterarPessoa(Pessoa pessoa)
        {
            Escrever("Digite novamente o primeiro nome: ");
            pessoa.Nome = Ler();

            Escrever("Digite novamenteo o Sobrenome: ");
            pessoa.Sobrenome = Ler();

            Escrever("Digite novamente a sua Idade: ");
            pessoa.Idade = int.Parse(Ler());
            if (pessoa.Idade > 17)
            {
                Escrever("Você tem Carro? (s/n)");
                if (Console.ReadKey().Key.Equals(ConsoleKey.S))
                {
                    _cadastrarCarro(pessoa);
                }
            }
            else
            {
                pessoa.LimpaListaCarros();
            }

        }

    }
}