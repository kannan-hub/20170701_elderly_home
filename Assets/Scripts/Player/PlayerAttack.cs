using Base.Character;
using Interface.Character;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// プレイヤーの攻撃クラス
    /// </summary>
    public class PlayerAttack : AttackBase
    {
        [SerializeField]
        private PlayerParameter playerParameter;

        public override IParameter Parameter
        {
            get { return playerParameter; }
        }

        public override int CalcDamage()
        {
            //ひとまずそのまま返す
            return (int)Parameter.Attack;
        }
    }
}