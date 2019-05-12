using System.Collections.Generic;
using QueueSystem.Domain.Characters;

namespace QueueSystem.Domain.Battlegrounds
{
    public class Battleground
    {
        private ICollection<Character> Characters { get; }

        public Battleground(ICollection<Character> characters)
        {
            Characters = characters;
        }

        public void Kick(Character who)
        {
            Characters.Remove(who);
        }

        public void Joined(Character who)
        {
            Characters.Add(who);
        }
    }
}