using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseView : MonoBehaviour, IView, IDisposable
{
    [SerializeField] private bool _closeWithBackButton;
    
    protected ViewManager ViewManager;
    protected InputSystem_Actions InputSystem;
    
    private void Awake()
    {
        if (_closeWithBackButton)
        {
            InputSystem = new InputSystem_Actions();
            InputSystem.Enable();
            InputSystem.UI.Cancel.performed += OnCancelClicked;
        }
    }

    private void OnDestroy()
    {
        if (_closeWithBackButton)
        {
            InputSystem.UI.Cancel.performed -= OnCancelClicked;
        }
    }

    public virtual void Initialize(ViewManager viewManager)
    {
        ViewManager = viewManager;
        OnInitialized();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
        OnShown();
    }

    public virtual void Hide()
    {
        OnHide();
        gameObject.SetActive(false);
    }

    public void Dispose()
    {
        OnDisposed();
    }

    protected virtual void OnDisposed(){}
    protected virtual void OnInitialized() { }
    protected virtual void OnShown() { }
    protected virtual void OnHide() { }

    private void OnCancelClicked(InputAction.CallbackContext obj)
    {
        ViewManager.HideCurrentView();
    }
}

public abstract class BaseView<TView> : BaseView where TView : BaseView<TView> { }