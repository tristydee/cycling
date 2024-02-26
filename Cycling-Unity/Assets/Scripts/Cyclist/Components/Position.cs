using System.Linq;
using System.Numerics;

namespace Cycling.Game
{
    public class Position : Component<Vector2>
    {
        private int _currentNodeIndex = 0;
        public int LaneIndex { get; private set; }

        public override void Init(RaceSettings raceSettings, Cyclist cyclist)
        {
            base.Init(raceSettings, cyclist);
            LaneIndex = raceSettings.Cyclists.IndexOf(cyclist);
            Value = Settings.Course.Lanes[0][LaneIndex];
        }

        public override void Tick()
        {
            var nextNode = Settings.Course.Lanes[0][_currentNodeIndex + 1];
            var direction = nextNode - Value;
            Value += direction * cyclist.Speed.Value;
        }
    }
}