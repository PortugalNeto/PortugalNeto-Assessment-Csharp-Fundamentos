using System;
using System.Collections.Generic;
using Gerenciador.Aniversario.Entity;
using Gerenciador.Aniversario.Repository;
using Newtonsoft.Json;

namespace ConsoleGerenciador
{
    class Program
    {
        private static IAmigoRepository Repository = new AmigoRepository();

        static void Main(string[] args)
        {
            
            Console.WriteLine("=====================================================");
            Console.WriteLine("=========== Calendário de aniversariantes ===========");
            Console.WriteLine("=====================================================");
            Console.WriteLine();

            var running = true;

            MostrarAniversariantes();

            while (running)
            {
                MenuDeOpcoes();
                var tecla = Console.ReadLine();

                switch (tecla)
                {
                    case "1":
                        CadastrarAmigo();
                        break;
                    case "2":
                        EditarAmigo();
                        break;
                    case "3":
                        ExcluirAmigo();
                        break;
                    case "4":
                        MostrarAmigo();
                        break;
                    case "5":
                        ListarTodosAmigos();
                        break;
                    case "6":
                        MostrarAniversariantes();
                        break;
                    case "s":
                        Console.WriteLine("Até Logo =D");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida!");
                        break;
                }

            }
        }

        private static void MostrarAniversariantes()
        {
            List<Amigo> amigos = Repository.GetAll();
            List<Amigo> aniversariantes = new List<Amigo>();

            foreach (var amigo in amigos)
            {
                if (amigo.Aniversario.Day == DateTime.Now.Day
                    && amigo.Aniversario.Month == DateTime.Now.Month)
                {
                    aniversariantes.Add(amigo);
                }
            }
            foreach (var amigo in aniversariantes)
            {
                if (aniversariantes != null)
                {
                    Console.WriteLine($"Hoje é aniversário de {amigo.Nome} {amigo.Sobrenome}!");
                    Console.WriteLine($"Não esqueça de dar os parabéns!!!");
                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine("Não há aniversariantes hoje!");
                }
            }
                
        }
        
            private static void MenuDeOpcoes()
        {
            Console.WriteLine("Para administrar seu calendário, tecle:");
            Console.WriteLine("1 - Para adicionar um Amigo à lista");
            Console.WriteLine("2 - Para atualizar dados de um Amigo");
            Console.WriteLine("3 - Para excluir um amigo da lista");
            Console.WriteLine("4 - Para obter dados de um Amigo");
            Console.WriteLine("5 - Para exibir todos os Amigos");
            Console.WriteLine("6 - Aniversariantes de HOJE!!");
            Console.WriteLine("s - Para sair");
            Console.WriteLine("");
        }

        private static void ListarTodosAmigos()
        {
            Console.WriteLine("Exibindo Todos os Amigos!");
            Console.WriteLine("-------------------------");
            var amigos = Repository.GetAll();
            Console.WriteLine(JsonConvert.SerializeObject(amigos, Formatting.Indented));
            Console.WriteLine("");
        }

        private static void MostrarAmigo()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o ID do Amigo");

            var id = Convert.ToInt32(Console.ReadLine());
            var amigo = Repository.GetAmigoById(id);

            Console.WriteLine("");
            Console.WriteLine($"Exibindo Amigo com o identificador {id}");
            Console.WriteLine("");
            Console.WriteLine(JsonConvert.SerializeObject(amigo, Formatting.Indented));
            Console.WriteLine("");
        }

        private static void ExcluirAmigo()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificador do Amigo para realizar a exclusão");

            var id = Convert.ToInt32(Console.ReadLine());

            var amigo = Repository.GetAmigoById(id);

            if (amigo == null)
                Console.WriteLine("Esse amigo é imaginário =p");
            else
            {
                Repository.DeleteAmigo(id);
                Console.WriteLine("Amigo excluido com sucesso");
            }
        }

        private static void CadastrarAmigo()
        {
            var amigo = new Amigo();

            Console.WriteLine("Informe o nome do Amigo:");
            amigo.Nome = Console.ReadLine();

            Console.WriteLine("Informe o Sobrenome do Amigo:");
            amigo.Sobrenome = Console.ReadLine();

            Console.WriteLine("Informe a data de aniversário:");
            amigo.Aniversario = Convert.ToDateTime(Console.ReadLine());

            Repository.InsertAmigo(amigo);

            Console.WriteLine("Amigo Adicionado à lista!");
            Console.WriteLine("");
        }
        private static void EditarAmigo()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificador do Amigo");

            
            var id = (Console.ReadLine().Equals(typeof(int)) ) ? Convert.ToInt32(Console.ReadLine()) : 0;
            var amigo = Repository.GetAmigoById(id);

            if (amigo != null)
            {
                Console.WriteLine("Informe o nome do Amigo:");
                amigo.Nome = Console.ReadLine();

                Console.WriteLine("Informe o Sobrenome do Amigo:");
                amigo.Sobrenome = Console.ReadLine();

                Console.WriteLine("Informe a data de aniversário:");
                amigo.Aniversario = Convert.ToDateTime(Console.ReadLine());

                Repository.UpdateAmigo(amigo, id);

                Console.WriteLine("Amigo atualizado!");
                Console.WriteLine("Amigo não encontrado");
                Console.WriteLine("");
            }

            else
            {
                Console.WriteLine("Amigo não encontrado");
                Console.WriteLine("");
            }
        }
    }
}

