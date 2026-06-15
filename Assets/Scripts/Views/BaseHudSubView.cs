using System;
using Additions;

public abstract class BaseHudSubView<TModel> : BaseHudSubView where TModel : class, IObservableData
{
    public override Type ModelType => typeof(TModel);
        
    protected TModel Model { get; private set; }

    public override void Initialize(IObservableData model)
    {
        Model = model as TModel;
            
        if (Model != null)
        {
            Model.Changed += OnModelChanged;
            OnInitialized();
        }
    }

    public override void DeInitialize()
    {
        if (Model != null)
        {
            Model.Changed -= OnModelChanged;
            OnDeInitialized();
        }
    }

    private void OnModelChanged() => RefreshVisual();

    protected abstract void OnInitialized();
    protected virtual void OnDeInitialized() { }
    protected abstract void RefreshVisual();
}