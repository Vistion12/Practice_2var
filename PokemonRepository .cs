using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practice_2var
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly string _filePath = "pokemons.txt";

        public void Create(Pokemon pokemon)
        {
            var pokemons = ReadAll().ToList();
            pokemons.Add(pokemon);
            SaveToFile(pokemons);
        }

        public Pokemon Read(int id)
        {
            return ReadAll().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pokemon> ReadAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Pokemon>();
            }

            var lines = File.ReadAllLines(_filePath);
            return lines.Select(line => ParsePokemon(line)).ToList();
        }

        public void Update(Pokemon pokemon)
        {
            var pokemons = ReadAll().ToList();
            var existingPokemon = pokemons.FirstOrDefault(p => p.Id == pokemon.Id);
            if (existingPokemon != null)
            {
                existingPokemon.Name = pokemon.Name;
                existingPokemon.Type = pokemon.Type;
                existingPokemon.Level = pokemon.Level;
                SaveToFile(pokemons);
            }
        }

        public void Delete(int id)
        {
            var pokemons = ReadAll().ToList();
            var pokemonToDelete = pokemons.FirstOrDefault(p => p.Id == id);
            if (pokemonToDelete != null)
            {
                pokemons.Remove(pokemonToDelete);
                SaveToFile(pokemons);
            }
        }

        private void SaveToFile(IEnumerable<Pokemon> pokemons)
        {
            var lines = pokemons.Select(p => $"{p.Id},{p.Name},{p.Type},{p.Level}");
            File.WriteAllLines(_filePath, lines);
        }

        private Pokemon ParsePokemon(string line)
        {
            var parts = line.Split(',');
            return new Pokemon
            {
                Id = int.Parse(parts[0]),
                Name = parts[1],
                Type = parts[2],
                Level = int.Parse(parts[3])
            };
        }
    }
}
