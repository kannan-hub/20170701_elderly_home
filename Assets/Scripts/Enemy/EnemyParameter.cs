using Base.Character;
using UniRx;
using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// 敵キャラのパラメータ
    /// </summary>
    public class EnemyParameter : ParameterBase
    {
        [SerializeField, Range(0, 100)]
        private int maxHp;

        [SerializeField, Range(0f, 10f)]
        private float baseSpeed;

        [SerializeField, Range(0f, 10f)]
        private float runMultiplier;

        [SerializeField, Range(0f, 100f)]
        private float attack;

        [SerializeField]
        private bool motal = true;

        public override float BaseSpeed
        {
            get { return baseSpeed; }
        }

        public override float RunMultiplier
        {
            get { return runMultiplier; }
        }

        public override float Attack
        {
            get { return attack; }
        }

        public override IObservable<int> remainHp
        {
            get { return hp; }
        }

        private ReactiveProperty<int> hp;

        public override bool IsMortal
        {
            get { return motal; }
        }

        public override void Dmage(int damage)
        {
            hp.Value -= damage;
            if(hp.Value <= 0) Death();
        }

        private void Awake()
        {
            hp = new ReactiveProperty<int>(maxHp);
        }
    }
}