using Base.Character;
using Interface.Character;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// Playerのダメージ
    /// </summary>
    public class PlayerDamage : DamageBase
    {
        /// <summary>
        /// 受ける側のパラメータ
        /// </summary>
        [SerializeField]
        private PlayerParameter playerParameter;

        public override IParameter Parameter
        {
            get { return playerParameter; }
        }

        /// <summary>
        /// 自分へのダメージ処理
        /// </summary>
        /// <param name="damage"></param>
        public override void ApplyDamage(float damage)
        {
            Parameter.Dmage((int) (damage * 0.1f));
        }
    }
}