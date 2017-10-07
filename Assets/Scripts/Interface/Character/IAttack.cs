namespace Interface.Character
{
    /// <summary>
    /// 攻撃できるキャラクターが持つInteface
    /// </summary>
    public interface IAttack
    {
        /// <summary>
        /// 攻撃者の最終的攻撃値（装備などで変化する想定）
        /// </summary>
        float AttackPower { get; }
    }
}