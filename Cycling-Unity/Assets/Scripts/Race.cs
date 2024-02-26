using System.Collections.Generic;

namespace Cycling.Game
{
    public class Race
    {
        private RaceSettings _settings;
        public List<Cyclist> Cyclists => _settings.Cyclists;

        public Race(RaceSettings settings)
        {
            _settings = settings;
        }

        public void Init()
        {
            InitCyclists();
        }

        private void InitCyclists()
        {
            _settings.Cyclists.ForEach(c => c.Init(_settings));
        }
        
        public void Tick()
        {
            Cyclists.ForEach(c => c.Tick());
        }
    }
}