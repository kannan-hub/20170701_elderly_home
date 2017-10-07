using Interface.Character;

namespace Player
{
    /// <summary>
    /// プレイヤーの攻撃クラス
    /// </summary>
    public class PlayerAttack : IAttack
    {
        /// <summary>
        /// 最終攻撃力
        /// </summary>
        public float AttackPower { get; private set; }

        public PlayerAttack(float attackPower)
        {
            AttackPower = attackPower;
        }
    }
}