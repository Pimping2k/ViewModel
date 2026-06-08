using System;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [SerializeField] private List<BaseView> _views;
    private ViewContainer _viewContainer;

    private void Awake()
    {
        _viewContainer = new ViewContainer();
        
        foreach (var view in _views)
        {
            _viewContainer.Register(view);
            view.Hide();
        }
    }

    public void ShowView<TView, TModel>(TModel model) where TView : BaseView<TModel> where TModel : class
    {
        var view = _viewContainer.Get<TView>();
        view.Show(model);
    }

    public void HideView<TView>() where TView : BaseView
    {
        var view = _viewContainer.Get<TView>();
        view.Hide();
    }
}