using System.Collections.Generic;

namespace Cycling.Game
{
    public class Cyclist
    {
        public Speed Speed = new Speed();
        public Position Position = new Position();
        
        private readonly RaceCourse _course;
        private readonly List<Cyclist> _cyclists;


        private int _currentNodeIndex = 0;

        public Cyclist(RaceSettings raceSettings)
        {
            _course = raceSettings.Course;
            _cyclists = raceSettings.Cyclists;
        }

        public void MoveToStartingLine()
        {
            //todo: need to take into account other cyclists. There should be a test for this.
            Position.Value = _course.Nodes[0];
        }

        public void Tick()
        {
            var nextNode = _course.Nodes[_currentNodeIndex + 1] ;
            var direction = nextNode - Position.Value;
            Position.Value += direction * Speed.Value;
        }
        
    }
}