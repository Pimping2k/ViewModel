using System;
using UnityEngine;

namespace Additions
{
    public abstract class BaseHudSubView : MonoBehaviour
    {
        public abstract Type ModelType { get; }

        public virtual void Initialize(IObservableData model){}
        public virtual void DeInitialize(){}
    }
}