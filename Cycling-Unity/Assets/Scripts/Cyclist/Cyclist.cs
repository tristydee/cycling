using System.Collections.Generic;

namespace Cycling.Game
{
    public class Cyclist
    {
        public Speed Speed = new Speed();
        public Position Position = new Position();
        public Endurance Endurance = new Endurance();

        private readonly RaceCourse _course;
        private readonly List<Cyclist> _cyclists;



        public Cyclist(RaceSettings raceSettings)
        {
            _course = raceSettings.Course;
            _cyclists = raceSettings.Cyclists;
            
            Speed.Init(raceSettings,this);
            Position.Init(raceSettings, this);
            Endurance.Init(raceSettings,this);
            
        }

        public void MoveToStartingLine()
        {
            //todo: this should be in position.init
            //todo: need to take into account other cyclists. There should be a test for this.
            
        }

        public void Tick()
        {
            Speed.Tick();
            Endurance.Tick();
            Position.Tick();
            
        }
        
    }
}