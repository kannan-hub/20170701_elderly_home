namespace Interface.Character
{
    /// <summary>
    /// 登場するキャラクターのパラメータ
    /// </summary>
    public interface IParameter
    {
        /// <summary>
        /// 基礎スピード、ここから前後左右や走る際のスピードが決まる
        /// </summary>
        float BaseSpeed { get; }

        /// <summary>
        /// 走り状態の時の倍率 Baseに直接かかる
        /// </summary>
        float RunMultiplier { get; }

        /// <summary>
        /// HitPoint 体力です
        /// </summary>
        int Hp { get; }

        /// <summary>
        /// 死ぬかどうか
        /// </summary>
        bool IsMortal { get; }
    }
}
