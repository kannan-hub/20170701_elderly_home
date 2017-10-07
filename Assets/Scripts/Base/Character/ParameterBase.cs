using Interface.Character;
using UniRx;
using UnityEngine;

namespace Base.Character
{
    public abstract class ParameterBase : MonoBehaviour, IParameter
    {
        public abstract float BaseSpeed { get; }
        public abstract float RunMultiplier { get; }
        public abstract float Attack { get; }
        public abstract IObservable<int> remainHp { get; }
        public abstract bool IsMortal { get; }
        public abstract void Dmage(int damage);

        public virtual void Death()
        {
            Destroy(gameObject);
        }
    }
}