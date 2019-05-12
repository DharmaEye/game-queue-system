using System.Collections.Generic;
using QueueSystem.Domain.Battlegrounds;
using QueueSystem.Domain.Characters;
using QueueSystem.Finders.Attributes;

namespace QueueSystem.Finders
{
    public static class BattlegroundFinder
    {
        private static HashSet<string> _queuedCharacters;
        private static Queue<Character> _characters;
        private static List<Battleground> _battlegrounds;

        private const int MinimumPlayerCount = 10;

        static BattlegroundFinder()
        {
            _queuedCharacters = new HashSet<string>();
            _characters = new Queue<Character>();
            _battlegrounds = new List<Battleground>();
        }

        public static void Que(Character character)
        {
            if (_queuedCharacters.TryGetValue(character.Id, out var id))
            {
                character.Inform("You are already in que");
                return;
            }

            _queuedCharacters.Add(character.Id);
            _characters.Enqueue(character);
        }

        [CallEvery(1, TimeIntervalType.Minutes)]
        public static void BeginBattleground()
        {
            while (_characters.Count > MinimumPlayerCount)
            {
                var characters = new List<Character>();
                for (var i = 0; i < MinimumPlayerCount; i++)
                {
                    var character = _characters.Dequeue();
                    characters.Add(character);
                }
                _battlegrounds.Add(new Battleground(characters));
            }
        }
    }
}