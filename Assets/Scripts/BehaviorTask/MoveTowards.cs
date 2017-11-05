using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorTask
{
    public class MoveTowards : Action
    {
        [SerializeField]
        private float _speed = 0f;

        [SerializeField]
        private SharedGameObject _targetGameObject;

        public override TaskStatus OnUpdate()
        {
            var targetPos = _targetGameObject.Value.transform.position;
            var distance = Vector3.SqrMagnitude(transform.position - targetPos);

            if (distance < 0.1f)
            {
                return TaskStatus.Success;
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPos, _speed * Time.deltaTime);
            transform.LookAt(_targetGameObject.Value.transform);

            return TaskStatus.Running;
        }
    }
}