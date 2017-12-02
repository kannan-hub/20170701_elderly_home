using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace BehaviorTask
{
    public class MoveTowardsUseAgent : Action
    {
        private NavMeshAgent agent;
        private ThirdPersonCharacter character;

        [SerializeField]
        private SharedGameObject target;

        [SerializeField]
        private float _speed;

        public override void OnStart()
        {
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            agent.speed = _speed;
            agent.updateRotation = false;
            agent.updatePosition = true;
        }

        public override TaskStatus OnUpdate()
        {
            if (target == null) return TaskStatus.Failure;

            agent.SetDestination(target.Value.transform.position);

            if (agent.remainingDistance < agent.stoppingDistance)
            {
                character.Move(Vector3.zero, false, false);
                return TaskStatus.Success;
            }

            character.Move(agent.desiredVelocity, false, false);
            return TaskStatus.Running;
        }
    }
}