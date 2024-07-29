using Microsoft.Extensions.DependencyInjection;
using System;

namespace Practice_2var
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPokemonRepository, PokemonRepository>()
                .AddTransient<PokemonController>()
                .BuildServiceProvider();// Настройка DI контейнера

            
            var pokemonController = serviceProvider.GetService<PokemonController>();// Получение через DI контейнер

            
            bool running = true;
            while (running)
            {
                Console.WriteLine("Testing some operations");
                Console.WriteLine("=========================");
                Console.WriteLine("1. Create Pokemon");
                Console.WriteLine("2. Read Pokemon");
                Console.WriteLine("3. Update Pokemon");
                Console.WriteLine("4. Delete Pokemon");
                Console.WriteLine("5. List All Pokemons");
                Console.WriteLine("6. Exit");
                Console.WriteLine("=========================");
                Console.Write("Choose pls: ");

                string choice = Console.ReadLine();
                Console.WriteLine("=========================");
                switch (choice)
                {
                    case "1":
                        CreatePokemon(pokemonController);
                        Console.WriteLine("====================================================");
                        break;
                    case "2":
                        ReadPokemon(pokemonController);
                        Console.WriteLine("====================================================");
                        break;
                    case "3":
                        UpdatePokemon(pokemonController);
                        Console.WriteLine("====================================================");
                        break;
                    case "4":
                        DeletePokemon(pokemonController);
                        Console.WriteLine("====================================================");
                        break;
                    case "5":
                        ListAllPokemons(pokemonController);
                        Console.WriteLine("====================================================");
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("eroror.");
                        break;
                }
            }
        }

        static void CreatePokemon(PokemonController pokemonController)
        {
            Console.WriteLine("Enter Pokemon ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Pokemon Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Pokemon Type: ");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Pokemon Level: ");
            int level = int.Parse(Console.ReadLine());

            var newPokemon = new Pokemon { Id = id, Name = name, Type = type, Level = level };
            pokemonController.CreatePokemon(newPokemon);
            Console.WriteLine("successful!");
        }

        static void ReadPokemon(PokemonController pokemonController)
        {
            Console.WriteLine("Enter Pokemon ID: ");
            int id = int.Parse(Console.ReadLine());
            var pokemon = pokemonController.GetPokemon(id);
            if (pokemon != null)
            {
                Console.WriteLine($"Pokemon is: {pokemon.Name}, {pokemon.Type}, {pokemon.Level}");
            }
            else
            {
                Console.WriteLine("Pokemon not found.");
            }
        }

        static void UpdatePokemon(PokemonController pokemonController)
        {
            Console.WriteLine("Enter Pokemon ID: ");
            int id = int.Parse(Console.ReadLine());
            var pokemon = pokemonController.GetPokemon(id);
            if (pokemon != null)
            {
                Console.WriteLine("Enter new Pokemon Name: ");
                pokemon.Name = Console.ReadLine();
                Console.WriteLine("Enter new Pokemon Type: ");
                pokemon.Type = Console.ReadLine();
                Console.WriteLine("Enter new Pokemon Level: ");
                pokemon.Level = int.Parse(Console.ReadLine());

                pokemonController.UpdatePokemon(pokemon);
                Console.WriteLine("successful!");
            }
            else
            {
                Console.WriteLine("Pokemon not found.");
            }
        }

        static void DeletePokemon(PokemonController pokemonController)
        {
            Console.WriteLine("Enter Pokemon ID: ");
            int id = int.Parse(Console.ReadLine());
            pokemonController.DeletePokemon(id);
            Console.WriteLine("success!");
        }

        static void ListAllPokemons(PokemonController pokemonController)
        {
            var allPokemons = pokemonController.GetPokemons();
            if (allPokemons != null)
            {
                foreach (var p in allPokemons)
                {
                    Console.WriteLine($"{p.Id}: {p.Name}, {p.Type}, {p.Level}");
                }
            }
            else
            {
                Console.WriteLine("No Pokemons found.");
            }
        }
    }
}
