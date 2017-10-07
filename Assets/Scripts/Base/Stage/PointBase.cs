using Interface.Stage;
using UnityEngine;

namespace Base.Stage
{
    public abstract class PointBase: MonoBehaviour, IPoint
    {
        public abstract void OnEnterPlayer();
    }
}