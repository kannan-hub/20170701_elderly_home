using Interface.Character;

namespace Enemy
{
    /// <summary>
    /// 敵キャラのパラメータ
    /// </summary>
    public class EnemyParameter : IParameter
    {
        public float BaseSpeed { get; private set; }
        public float RunMultiplier { get; private set; }
        public int Hp { get; private set; }
        public bool IsMortal { get; private set; }

        public EnemyParameter(float baseSpeed, float runMultiplier, int hp, bool isMortal)
        {
            BaseSpeed = baseSpeed;
            RunMultiplier = runMultiplier;
            Hp = hp;
            IsMortal = isMortal;
        }
    }
}