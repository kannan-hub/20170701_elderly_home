using System;
using Interface.Character;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    /// <summary>
    /// 敵キャラモデル
    /// パラメーターなど
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour, ICharacter
    {
        /// <summary>
        /// 敵かどうか
        /// </summary>
        public bool isEnemy
        {
            get { return true; }
        }

        /// <summary>
        /// パラメータ
        /// </summary>
        private EnemyParameter enemyParameter;

        public IParameter Parameter
        {
            get { return enemyParameter; }
        }

        /// <summary>
        /// 攻撃
        /// </summary>
        private EnemyAttack enemyAttack;

        public IAttack Attack
        {
            get { return enemyAttack; }
        }

        /// <summary>
        /// ダメージ処理
        /// </summary>
        private EnemyDamage enemyDamage;

        public IDamage Damage
        {
            get { return enemyDamage; }
        }

        [SerializeField, Range(0, 100)]
        private int hp;

        [SerializeField]
        private bool motal = true;

        [SerializeField, Range(0f, 10f)]
        private float baseSpeed;

        [SerializeField, Range(0f, 10f)]
        private float runMultiplier;

        [SerializeField]
        private ObservableCollisionTrigger collisionTrigger;

        [HideInInspector]
        private NavMeshAgent agent;

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Awake()
        {
            enemyParameter = new EnemyParameter(baseSpeed, runMultiplier, hp, motal);
            enemyAttack = new EnemyAttack(100f); //ToDo: 仮の値計算する
            enemyDamage = new EnemyDamage(enemyParameter);

            agent = GetComponent<NavMeshAgent>();
            agent.speed = enemyParameter.BaseSpeed;
        }

        private void Start()
        {
            //接触時処理
            collisionTrigger.OnCollisionEnterAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(3))
                .Subscribe(other =>
                {
                    var damage = other.gameObject.GetComponent<IDamage>();
                    if (damage != null) damage.ApplyDamage(enemyAttack.AttackPower);
                }).AddTo(this);
        }
    }
}