﻿using UnityEngine;
using UnityEngine.EventSystems;
using Arkham.Managers;
using Sirenix.OdinInspector;

namespace Arkham.UI
{
    public class TabButton : ButtonComponent, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Title("MANAGER"), PropertyOrder(-1)]
        [SerializeField, SceneObjectsOnly] private TabManager tabManager;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (tabManager.IsCurrentTab(this)) return;
            tabManager.SelectTab(this);
            PlaySound(clickSound);
            clickAction?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (tabManager.IsCurrentTab(this)) return;
            PlaySound(hoverEnterSound);
            HoverActivate();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (tabManager.IsCurrentTab(this)) return;
            PlaySound(hoverExitSound);
            HoverDesactivate();
        }
    }
}