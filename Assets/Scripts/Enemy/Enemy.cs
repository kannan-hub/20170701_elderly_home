using System;
using Base.Character;
using Interface.Character;
using Player;
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
    public class Enemy : CharacterBase
    {
        /// <summary>
        /// 敵かどうか
        /// </summary>
        public override bool isEnemy
        {
            get { return true; }
        }

        /// <summary>
        /// パラメータ
        /// </summary>
        [SerializeField]
        private EnemyParameter enemyParameter;

        public override IParameter Parameter
        {
            get { return enemyParameter; }
        }

        /// <summary>
        /// 攻撃
        /// </summary>
        [SerializeField]
        private EnemyAttack enemyAttack;

        public override IAttack Attack
        {
            get { return enemyAttack; }
        }

        /// <summary>
        /// ダメージ処理
        /// </summary>
        [SerializeField]
        private EnemyDamage enemyDamage;

        public override IDamage Damage
        {
            get { return enemyDamage; }
        }

        [SerializeField]
        private ObservableCollisionTrigger collisionTrigger;

        [HideInInspector]
        private NavMeshAgent agent;

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed = enemyParameter.BaseSpeed;
        }

        private void Start()
        {
            //接触時処理
            collisionTrigger.OnCollisionEnterAsObservable()
                .Where(other => other.collider.CompareTag("Player"))
                .ThrottleFirst(TimeSpan.FromSeconds(3))
                .Subscribe(other =>
                {
                    var damage = other.gameObject.GetComponent<PlayerDamage>();
                    if (damage != null) damage.ApplyDamage(enemyAttack.CalcDamage());
                }).AddTo(this);
        }
    }
}