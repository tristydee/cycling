using System.Collections.Generic;

namespace Cycling.Game
{
    public class Cyclist
    {
        public Speed Speed = new Speed();
        public Position Position = new Position();
        public Endurance Endurance = new Endurance();

        private RaceCourse _course;
        private List<Cyclist> _cyclists;
        private RaceSettings _raceSettings;

        public void Init(RaceSettings raceSettings)
        {
            _course = raceSettings.Course;
            _cyclists = raceSettings.Cyclists;
            _raceSettings = raceSettings;
            Speed.Init(_raceSettings,this);
            Position.Init(_raceSettings, this);
            Endurance.Init(_raceSettings,this);
            
        }

        public void Tick()
        {
            Speed.Tick();
            Endurance.Tick();
            Position.Tick();
            
        }
        
    }
}