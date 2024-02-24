using System.Numerics;

namespace Cycling.Game
{
    public class Position : Component<Vector2>
    {
        private int _currentNodeIndex = 0;

        public override void Init(RaceSettings raceSettings, Cyclist cyclist)
        {
            base.Init(raceSettings, cyclist);
            //todo: need to chane position based off of whether there are other cyclists there already
            Value = Settings.Course.Lanes[0][0];
        }

        public override void Tick()
        {
            var nextNode = Settings.Course.Lanes[0][_currentNodeIndex + 1] ;
            var direction = nextNode - Value;
            Value += direction * cyclist.Speed.Value;
        }
    }
}