using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    /// <summary>
    /// 敵キャラの表示に関すること
    /// パラメーターなど
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField, Range(0f, 10f)]
        private float walkingSpeed;

        //未実装だよ、敵の要素実装時に決めるよ
//        [SerializeField]
//        private float runningSpeed;
        
        [HideInInspector]
        private NavMeshAgent agent;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed = walkingSpeed;
        }
    }
}