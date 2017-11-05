using System.Collections.Generic;
using System.Linq;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorTask
{
    public class WithInSight : Conditional
    {
        [SerializeField]
        private float _fieldOfViewAngle;

        [SerializeField]
        private string _targetTag;

        [SerializeField]
        private SharedGameObject _targetGameObject;

        private readonly List<Transform> possibleTargets = new List<Transform>();

        public override void OnAwake()
        {
            var targets = GameObject.FindGameObjectsWithTag(_targetTag);
            possibleTargets.AddRange(targets.Select(x => x.transform));
        }

        public override TaskStatus OnUpdate()
        {
            var inSight = possibleTargets.FirstOrDefault(x => CheckWithInSight(x, _fieldOfViewAngle));
            if (inSight == null) return TaskStatus.Running;

            _targetGameObject.Value = inSight.gameObject;
            return TaskStatus.Success;
        }

        public bool CheckWithInSight(Transform target, float fieldOfViewAngle)
        {
            var direction = target.position - transform.position;
            return Vector3.Angle(direction, transform.forward) < fieldOfViewAngle;
        }
    }
}