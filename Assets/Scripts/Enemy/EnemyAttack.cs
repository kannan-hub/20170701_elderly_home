using Base.Character;
using Interface.Character;
using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// 敵の攻撃クラス
    /// </summary>
    public class EnemyAttack : AttackBase
    {
        [SerializeField]
        private EnemyParameter enemyParameter;

        public override IParameter Parameter
        {
            get { return enemyParameter; }
        }

        public override int CalcDamage()
        {
            //ひとまずそのまま返す
            return (int)Parameter.Attack;
        }
    }
}