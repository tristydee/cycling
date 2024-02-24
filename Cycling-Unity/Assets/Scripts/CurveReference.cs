using UnityEngine;

namespace Cycling.Game
{
    [CreateAssetMenu(menuName = "Cycling/CurveReference")]
    public class CurveReference : ScriptableObject
    {
        public AnimationCurve Curve;
    }
}