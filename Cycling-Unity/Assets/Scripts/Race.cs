using System.Collections.Generic;

namespace Cycling.Game
{
    public class Race
    {
        private RaceSettings _settings;
        private List<Cyclist> Cyclists => _settings.Cyclists;

        public Race(RaceSettings settings)
        {
            _settings = settings;
        }

        public void Init()
        {
            MoveCyclistsToStartingLine();
        }

        private void MoveCyclistsToStartingLine()
        {
            _settings.Cyclists.ForEach(c => c.MoveToStartingLine());
        }
        
        public void Tick()
        {
            Cyclists.ForEach(c => c.Tick());
        }
    }
}