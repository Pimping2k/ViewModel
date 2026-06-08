using System;
using System.Collections.Generic;

public class ViewContainer
{
    private readonly Dictionary<Type, BaseView> _views = new();

    public void Register(BaseView view)
    {
        var type = view.GetType();
        _views.TryAdd(type, view);
    }

    public TView Get<TView>() where TView : BaseView
    {
        var type = typeof(TView);
        if (_views.TryGetValue(type, out var view))
        {
            return view as TView;
        }

        return null;
    }
}