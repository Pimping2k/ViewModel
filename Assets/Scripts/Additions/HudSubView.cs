using System;
using UnityEngine;

namespace Additions
{
    public abstract class HudSubView : MonoBehaviour
    {
        public abstract Type ModelType { get; }

        public virtual void Initialize(IObservableData model){}
        public virtual void DeInitialize(){}
    }
}