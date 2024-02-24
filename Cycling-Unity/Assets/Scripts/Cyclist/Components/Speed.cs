using UnityEngine;

namespace Cycling.Game
{
    public class Speed : Component<float>
    {
        private float maxSpeed;
        private AnimationCurve SpeedEnduranceCurve;
        
        public override void Init(RaceSettings raceSettings, Cyclist cyclist)
        {
        }

        public override void Tick()
        {
            maxSpeed = SpeedEnduranceCurve.Evaluate(cyclist.Endurance.Value / cyclist.Endurance.StartingValue);
            Value = maxSpeed;
            //speed is determined by AI...
        }
        
    }
}