using UnityEngine;
using UnityEngine.AddressableAssets;


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
            FatigueCurve = Addressables.LoadAssetAsync<CurveReference>("FatigueCurve").WaitForCompletion().Curve;
        }


        public override void Tick()
        {
            Value -= FatigueCurve.Evaluate(cyclist.Speed.Value);
        }
    }
}