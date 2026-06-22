using System;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [SerializeField] private List<BaseView> _views;
        
    private readonly Dictionary<Type, BaseView> _viewMap = new();
    private BaseView _currentView;

    private void Awake()
    {
        foreach (var view in _views)
        {
            if (!view) 
                continue;
                
            _viewMap[view.GetType()] = view;
                
            view.Initialize(this);
            view.Hide();
        }
    }

    public TView ShowView<TView>() where TView : BaseView
    {
        _currentView?.Hide();

        if (_viewMap.TryGetValue(typeof(TView), out var view))
        {
            _currentView = view;
            _currentView.Show();
            return view as TView;
        }

        return null;
    }

    public void HideCurrentView()
    {
        _currentView?.Hide();
        _currentView = null;
    }
}