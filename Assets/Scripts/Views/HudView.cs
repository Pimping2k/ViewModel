using System;
using System.Collections.Generic;
using Additions;
using UnityEngine;

namespace Views
{
    public class HudView : BaseView<HudModel>
    {
        [SerializeField] private List<HudSubView> _subViews;

        private readonly Dictionary<Type, HudSubView> _subViewsMap = new();

        private void Awake()
        {
            foreach (var subView in _subViews)
            {
                _subViewsMap[subView.ModelType] = subView;
            }
        }

        protected override void OnShown()
        {
            foreach (var subModel in Model.SubModels)
            {
                var modelType = subModel.GetType();

                if (_subViewsMap.TryGetValue(modelType, out var subView))
                {
                    subView.Initialize(subModel);
                }

                subModel.Changed += OnAnyModelChanged;
            }
        }

        protected override void OnHidden()
        {
            foreach (var subModel in Model.SubModels)
            {
                subModel.Changed -= OnAnyModelChanged;
            
                var modelType = subModel.GetType();
                if (_subViewsMap.TryGetValue(modelType, out var subView))
                {
                    subView.DeInitialize();
                }
            }
        }

        private void OnAnyModelChanged() => Refresh();
        public override void Refresh() { }   
    }
}