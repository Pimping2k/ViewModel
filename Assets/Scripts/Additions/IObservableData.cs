using System;

namespace Additions
{
    public interface IObservableData
    {
        public event Action Changed;
    }
}