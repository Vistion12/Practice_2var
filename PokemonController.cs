using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2var
{
    public class PokemonController
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public void CreatePokemon(Pokemon pokemon)
        {
            _pokemonRepository.Create(pokemon);
        }

        public Pokemon GetPokemon(int id)
        {
            return _pokemonRepository.Read(id);
        }

        public void DeletePokemon(int id)
        {
            _pokemonRepository.Delete(id);
        }

        public void UpdatePokemon(Pokemon pokemon)
        {
            _pokemonRepository.Update(pokemon);
        }

        public IEnumerable<Pokemon> GetPokemons()
        {
            return _pokemonRepository.ReadAll();
        }
    }
}
