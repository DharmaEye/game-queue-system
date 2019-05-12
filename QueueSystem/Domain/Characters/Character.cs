using QueueSystem.Finders;

namespace QueueSystem.Domain.Characters
{
    public class Character : Aggregate
    {
        public string Name { get; private set; }

        public long LastActiveTimestamp { get; private set; }

        public byte HonorLevel { get; private set; }

        public Character(string name)
        {
            Name = name;
        }

        public void JoinBattleground()
        {
            BattlegroundFinder.Que(this);
        }

        public void Inform(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}