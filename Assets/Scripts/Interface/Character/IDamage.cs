namespace Interface.Character
{
    /// <summary>
    /// 攻撃されたときにダメージを受ける
    /// </summary>
    public interface IDamage
    {
        /// <summary>
        /// 攻撃された側のパラメータ
        /// </summary>
        IParameter Parameter { get; }

        /// <summary>
        /// ダメージの適応処理
        /// </summary>
        /// <param name="damage"></param>
        void ApplyDamage(float damage);

        /// <summary>
        /// 自分を死亡させる
        /// </summary>
        void Death();
    }
}