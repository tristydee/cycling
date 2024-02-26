using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Cycling.Game
{
    public class Speed : Component<float>
    {
        private float maxSpeed;
        private AnimationCurve SpeedEnduranceCurve;
        
        public override void Init(RaceSettings raceSettings, Cyclist cyclist)
        {
            base.Init(raceSettings,cyclist);
            SpeedEnduranceCurve = Addressables.LoadAssetAsync<CurveReference>($"SpeedEnduranceCurve_{GetSettingsSuffix()}").WaitForCompletion().Curve;
        }

        public override void Tick()
        {
            maxSpeed = SpeedEnduranceCurve.Evaluate(cyclist.Endurance.Value / cyclist.Endurance.StartingValue);
            Value = maxSpeed;
        }
        
    }
}