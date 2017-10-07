using Base.Character;
using Interface.Character;
using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// 敵のダメージ処理
    /// </summary>
    public class EnemyDamage : DamageBase
    {
        /// <summary>
        /// 受ける側のパラメータ
        /// </summary>
        [SerializeField]
        private EnemyParameter enemyParameter;

        public override IParameter Parameter
        {
            get { return enemyParameter; }
        }

        /// <summary>
        /// 自分へのダメージ処理
        /// </summary>
        /// <param name="damage"></param>
        public override void ApplyDamage(float damage)
        {
            Parameter.Dmage((int) damage);
        }
    }
}