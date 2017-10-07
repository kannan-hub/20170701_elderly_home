namespace Interface.Stage
{
    /// <summary>
    /// ステージ中のポイント
    /// </summary>
    public interface IPoint
    {
        /// <summary>
        /// プレイヤーがこのPointに入ったときの処理
        /// </summary>
        void OnEnterPlayer();
    }
}