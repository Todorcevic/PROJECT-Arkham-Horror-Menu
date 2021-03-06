﻿using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PanelView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGroup;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeFadeAnimation;

        private bool IsCanvasVisible => canvasGroup.alpha == 1;
        private string ButtonName => IsCanvasVisible ? "Desactivate Alpha" : "Activate Alpha";
        private Color ButtonColor => IsCanvasVisible ? Color.red : Color.green;

        /*******************************************************************/
        public void Activate(bool toActivate)
        {
            canvasGroup.blocksRaycasts = toActivate;
            canvasGroup.interactable = toActivate;
            canvasGroup.DOFade(toActivate ? 1 : 0, timeFadeAnimation);
        }

        [Button("$ButtonName", ButtonSizes.Gigantic), GUIColor("$ButtonColor")]
        private void ToogleCanvasAlpha()
        {
            canvasGroup.alpha = IsCanvasVisible ? 0 : 1;
            canvasGroup.blocksRaycasts = IsCanvasVisible;
            canvasGroup.interactable = IsCanvasVisible;
        }
    }
}
