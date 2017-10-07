namespace Interface.Stage
{
    /// <summary>
    /// ステージ中の目標のInterface
    /// </summary>
    public interface IObjective
    {
        /// <summary>
        /// 達成済みかどうか
        /// </summary>
        bool Achieved { get; }
    }
}