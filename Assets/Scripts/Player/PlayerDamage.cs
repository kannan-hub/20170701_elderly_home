using Interface.Character;

namespace Player
{
    /// <summary>
    /// Playerのダメージ
    /// </summary>
    public class PlayerDmage : IDamage
    {
        /// <summary>
        /// 受ける側のパラメータ
        /// </summary>
        public IParameter DamageParameter { get; private set; }

        /// <summary>
        /// 実際のダメージ処理
        /// </summary>
        /// <param name="damage"></param>
        public void ApplyDamage(float damage)
        {
            DamageParameter.Hp -= (int)(damage * 0.1f);
        }

        public PlayerDmage(IParameter damageParameter)
        {
            DamageParameter = damageParameter;
        }
    }
}