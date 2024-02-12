using UnityEngine;

namespace Cycling.Game
{
    public class StartGame : MonoBehaviour
    {
        private Race _race;
        private void Start()
        {
            var raceSettings = new RaceSettings();
            _race = new Race(raceSettings);
        }

        private void Update()
        {
            _race.Tick();
        }
    }
}