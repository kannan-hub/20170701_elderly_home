using UniRx;

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
        /// 攻撃力
        /// </summary>
        float Attack { get; }

        /// <summary>
        /// HitPoint 体力です
        /// </summary>
        IObservable<int> remainHp { get;}

        /// <summary>
        /// 死ぬかどうか
        /// </summary>
        bool IsMortal { get; }

        /// <summary>
        /// ダメージ処理
        /// </summary>
        /// <param name="damage"></param>
        void Dmage(int damage);

        /// <summary>
        /// 死亡処理
        /// </summary>
        void Death();
    }
}
