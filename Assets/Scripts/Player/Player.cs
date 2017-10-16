using System.Collections.Generic;
using Base.Character;
using Base.Item;
using Enemy;
using Interface.Character;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Utility;
using TimeSpan = System.TimeSpan;

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

        public List<string> HavingItems { get; private set; }

        private ItemBase CurrentTakingItem;

        private void Awake()
        {
            HavingItems = new List<string>();

            controller = GetComponent<RigidbodyFirstPersonController>();
            controller.movementSettings = new RigidbodyFirstPersonController.MovementSettings
            {
                ForwardSpeed = playerParameter.BaseSpeed,
                BackwardSpeed = playerParameter.BaseSpeed / 2,
                StrafeSpeed = playerParameter.BaseSpeed / 2,
                RunMultiplier = playerParameter.RunMultiplier
            };
        }

        //ToDo: PlayerAction としてクラス分けすべきかな

        public IObservable<Tuple<bool, Collider>> HitInteractItem()
        {
            RaycastHit hit = new RaycastHit();
            var center = new Vector3(Screen.width / 2f, Screen.height / 2f);

            return this.UpdateAsObservable()
                .Select(_ =>
                {
                    var ray = Camera.main.ScreenPointToRay(center);
                    return Physics.SphereCast(ray, 0.05f, out hit, 1);
                })
                .DistinctUntilChanged()
                .Select(x => new Tuple<bool, Collider>(x, hit.collider))
                .Publish()
                .RefCount();
        }

        public IObservable<bool> OnTaking()
        {
            return this.UpdateAsObservable()
                .Select(_ => Input.GetMouseButton(0))
                .DistinctUntilChanged()
                .CombineLatest(HitInteractItem(),
                    (b, tuple) => b && tuple.Item1 && tuple.Item2.GetComponent<ItemBase>() != null);
        }

        /// <summary>
        /// 獲得したアイテムを追加する
        /// </summary>
        /// <param name="item"></param>
        public void AddHavingItem(string item)
        {
            HavingItems.Add(item);
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

            //ToDo:後ほどもっとちゃんとした実装にする
            collisionTrigger.OnCollisionEnterAsObservable()
                .Where(other => other.collider.CompareTag("Item"))
                .Subscribe(other =>
                {
                    HavingItems.Add(other.gameObject.name);
                    Destroy(other.gameObject);
                }).AddTo(this);
        }
    }
}