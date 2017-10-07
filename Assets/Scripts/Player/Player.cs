using System;
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
    public class Player : MonoBehaviour, ICharacter
    {
        /// <summary>
        /// 敵かどうか
        /// </summary>
        public bool isEnemy
        {
            get { return false; }
        }

        /// <summary>
        /// パラメータ
        /// </summary>
        private PlayerParameter playerParameter;

        public IParameter Parameter
        {
            get { return playerParameter; }
        }

        /// <summary>
        /// 攻撃
        /// </summary>
        private PlayerAttack playerAttack;

        public IAttack Attack
        {
            get { return playerAttack; }
        }

        /// <summary>
        /// ダメージ処理
        /// </summary>
        private PlayerDmage playerDamage;

        public IDamage Damage
        {
            get { return playerDamage; }
        }
        
        [SerializeField, Range(0, 100)]
        private int hp;

        [SerializeField, Range(0f, 10f)]
        private float baseSpeed;

        [SerializeField, Range(0f, 10f)]
        private float runMultiplier;

        [SerializeField]
        private ObservableCollisionTrigger collisionTrigger;

        [HideInInspector]
        private RigidbodyFirstPersonController controller;

        private void Awake()
        {
            playerParameter = new PlayerParameter(baseSpeed, runMultiplier, hp);
            playerAttack = new PlayerAttack(100f); //ToDo: 仮の値計算する
            playerDamage = new PlayerDmage(playerParameter);

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
                .ThrottleFirst(TimeSpan.FromSeconds(3))
                .Subscribe(other =>
                {
                    var damage = other.gameObject.GetComponent<IDamage>();
                    if (damage != null) damage.ApplyDamage(playerAttack.AttackPower);
                }).AddTo(this);
        }
    }
}