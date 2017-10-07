using Interface.Character;
using UnityEngine;

namespace Base.Character
{
    public abstract class AttackBase : MonoBehaviour, IAttack
    {
        public abstract IParameter Parameter { get;}
        public abstract int CalcDamage();
    }
}