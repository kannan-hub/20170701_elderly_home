using Interface.Character;
using UnityEngine;

namespace Base.Character
{
    public abstract class DamageBase : MonoBehaviour, IDamage
    {
        public abstract IParameter Parameter { get; }
        public abstract void ApplyDamage(float damage);

        public virtual void Death()
        {
            Parameter.Death();
        }
    }
}