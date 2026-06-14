using UnityEngine;

public abstract class BaseView : MonoBehaviour
{
    public virtual void Hide() => gameObject.SetActive(false);
}

public abstract class BaseView<TModel> : BaseView where TModel : class
{
    protected TModel Model { get; private set; }

    public void Show(TModel model)
    {
        Model = model;
        gameObject.SetActive(true);

        OnShown();
        Refresh();
    }

    public override void Hide()
    {
        if(Model == null)
            return;
        
        OnHidden();
        Model = null;
        base.Hide();
        gameObject.SetActive(false);
    }

    protected abstract void OnShown();
    protected abstract void OnHidden();
    public abstract void Refresh();
}