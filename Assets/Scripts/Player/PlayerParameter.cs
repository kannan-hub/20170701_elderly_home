using Interface.Character;
using TMPro;

namespace Player
{
    /// <summary>
    /// 敵キャラのパラメータ
    /// </summary>
    public class PlayerParameter : IParameter
    {
        public float BaseSpeed { get; private set; }
        public float RunMultiplier { get; private set; }
        public int Hp { get; set; }

        public bool IsMortal
        {
            get { return true; } //Playerは必ず死ぬ
        }

        public PlayerParameter(float baseSpeed, float runMultiplier, int hp)
        {
            BaseSpeed = baseSpeed;
            RunMultiplier = runMultiplier;
            Hp = hp;
        }
    }
}