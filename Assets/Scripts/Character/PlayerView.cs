using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Character
{
    /// <summary>
    /// プレイヤー表示に関すること
    /// </summary>
    public class PlayerView : MonoBehaviour
    {
        [SerializeField, Range(0f, 10f)]
        private float forwardSpeed;

        [SerializeField, Range(0f, 10f)]
        private float backwardSpeed;

        [SerializeField, Range(0f, 10f)]
        private float strafeSpeed;

        [SerializeField, Range(0f, 5f)]
        private float runMultiplier;

        [HideInInspector]
        private RigidbodyFirstPersonController controller;

        private void Awake()
        {
            controller = GetComponent<RigidbodyFirstPersonController>();
            controller.movementSettings = new RigidbodyFirstPersonController.MovementSettings
            {
                ForwardSpeed = forwardSpeed,
                BackwardSpeed = backwardSpeed,
                StrafeSpeed = strafeSpeed,
                RunMultiplier = runMultiplier
            };
        }

        //TODO:パラメーターと動作状態は分割すべきかと

        private readonly ReactiveProperty<bool> exsist = new BoolReactiveProperty(true);

        /// <summary>
        /// 生存しているかどうか
        /// </summary>
        public IObservable<bool> Exsist
        {
            get { return exsist; }
        }

        [SerializeField]
        private ObservableCollisionTrigger collisionTrigger;

        private void Start()
        {
            collisionTrigger.OnCollisionEnterAsObservable().Subscribe(colliion =>
            {
                if (colliion.transform.CompareTag("Enemy"))
                {
                    Debug.Log("DEAD!!!");
                    //Destroy(this);
                }
            }).AddTo(this);
        }
    }
}