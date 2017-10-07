using System;
using Base.Character;
using Enemy;
using Interface.Character;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Player
{
    /// <summary>
    /// プレイヤーモデル
    /// </summary>
    public class Player : CharacterBase
    {
        /// <summary>
        /// 敵かどうか
        /// </summary>
        public override bool isEnemy
        {
            get { return false; }
        }

        /// <summary>
        /// パラメータ
        /// </summary>
        [SerializeField]
        private PlayerParameter playerParameter;

        public override IParameter Parameter
        {
            get { return playerParameter; }
        }

        /// <summary>
        /// 攻撃
        /// </summary>
        [SerializeField]
        private PlayerAttack playerAttack;

        public override IAttack Attack
        {
            get { return playerAttack; }
        }

        /// <summary>
        /// ダメージ処理
        /// </summary>
        [SerializeField]
        private PlayerDamage playerDamage;

        public override IDamage Damage
        {
            get { return playerDamage; }
        }
        
        [SerializeField]
        private ObservableCollisionTrigger collisionTrigger;

        [HideInInspector]
        private RigidbodyFirstPersonController controller;

        private void Awake()
        {
            controller = GetComponent<RigidbodyFirstPersonController>();
            controller.movementSettings = new RigidbodyFirstPersonController.MovementSettings
            {
                ForwardSpeed = playerParameter.BaseSpeed,
                BackwardSpeed = playerParameter.BaseSpeed/2,
                StrafeSpeed = playerParameter.BaseSpeed/2,
                RunMultiplier = playerParameter.RunMultiplier
            };
        }
        
        private void Start()
        {
            //接触時処理
            collisionTrigger.OnCollisionEnterAsObservable()
                .Where(other => other.collider.CompareTag("Enemy"))
                .ThrottleFirst(TimeSpan.FromSeconds(3))
                .Subscribe(other =>
                {
                    var damage = other.gameObject.GetComponent<EnemyDamage>();
                    if (damage != null) damage.ApplyDamage(playerAttack.CalcDamage());
                }).AddTo(this);
        }
    }
}