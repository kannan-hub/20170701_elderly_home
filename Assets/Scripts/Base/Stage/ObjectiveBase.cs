using Interface.Stage;
using UnityEngine;

namespace Base.Stage
{
    public abstract class ObjectiveBase : MonoBehaviour, IObjective
    {
        public abstract bool Achieved { get;}
    }
}