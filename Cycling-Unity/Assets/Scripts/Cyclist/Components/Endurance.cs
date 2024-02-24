using UnityEngine;


namespace Cycling.Game
{
    public class Endurance : Component<float>
    {
        public float StartingValue { get; private set; } = 100f;
        private AnimationCurve FatigueCurve;

        public override void Init(RaceSettings raceSettings, Cyclist cyclist)
        {
            base.Init(raceSettings, cyclist);
            Value = StartingValue;
            //todo: why can't I fucking reference addressables here.
            // FatigueCurve = UnityEngine.Addressables.
        }


        public override void Tick()
        {
            Value -= .1f;
            // Value -= FatigueCurve.Evaluate(cyclist.Speed.Value);
        }
    }
}