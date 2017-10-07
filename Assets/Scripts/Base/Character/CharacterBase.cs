using Interface.Character;
using UnityEngine;

namespace Base.Character
{
    public abstract class CharacterBase : MonoBehaviour, ICharacter
    {
        public abstract bool isEnemy { get; }
        public abstract IParameter Parameter { get; }
        public abstract IAttack Attack { get; }
        public abstract IDamage Damage { get; }
    }
}