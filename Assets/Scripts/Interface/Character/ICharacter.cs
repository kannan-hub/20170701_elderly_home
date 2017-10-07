namespace Interface.Character
{
    /// <summary>
    /// ゲーム中に登場するキャラが共通して持つInterface
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// 敵かどうか
        /// </summary>
        bool isEnemy { get; }

        /// <summary>
        /// パラメータ
        /// </summary>
        IParameter Parameter { get; }

        /// <summary>
        /// 攻撃
        /// </summary>
        IAttack Attack { get; }

        /// <summary>
        /// ダメージ
        /// </summary>
        IDamage Damage { get; }
    }
}