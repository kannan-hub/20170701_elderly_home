using Interface.Character;

namespace Enemy
{
    /// <summary>
    /// 敵の攻撃クラス
    /// </summary>
    public class EnemyAttack : IAttack
    {
        /// <summary>
        /// 最終攻撃力
        /// </summary>
        public float AttackPower { get; private set; }

        public EnemyAttack(float attackPower)
        {
            AttackPower = attackPower;
        }
    }
}