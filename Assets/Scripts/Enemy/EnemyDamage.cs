using Interface.Character;

namespace Enemy
{
    /// <summary>
    /// 敵のダメージ処理
    /// </summary>
    public class EnemyDamage : IDamage
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
            DamageParameter.Hp -= (int)damage;
        }

        public EnemyDamage(IParameter damageParameter)
        {
            DamageParameter = damageParameter;
        }
    }
}