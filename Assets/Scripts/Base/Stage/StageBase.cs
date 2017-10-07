using System.Collections.Generic;
using Interface.Character;
using Interface.Stage;
using UnityEngine;

namespace Base.Stage
{
    public abstract class StageBase : MonoBehaviour, IStage
    {
        public abstract List<IObjective> Objectives { get;}
        public abstract List<IPoint> Points { get;}
        public abstract List<ICharacter> Characters { get;}
    }
}