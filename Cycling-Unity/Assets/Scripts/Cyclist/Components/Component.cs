using UnityEditor;

namespace Cycling.Game
{
    public abstract class Component<T>
    {
        public T Value;
        
        protected RaceSettings Settings;
        protected Cyclist cyclist;

        public virtual void Init(RaceSettings raceSettings, Cyclist cyclist)
        {
            this.cyclist = cyclist;
            Settings = raceSettings;
        }

        public abstract void Tick();
    }
}