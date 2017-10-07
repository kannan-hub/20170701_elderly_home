namespace Interface.Character
{
    /// <summary>
    /// 攻撃できるキャラクターが持つInteface
    /// </summary>
    public interface IAttack
    {
        IParameter Parameter { get; }
        int CalcDamage();
    }
}