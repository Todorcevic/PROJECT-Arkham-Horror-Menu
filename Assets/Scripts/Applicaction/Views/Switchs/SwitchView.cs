﻿using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class SwitchView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private event Action ClickAction;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio interactableAudio;
        [SerializeField, Required] private Transform positionOn;
        [SerializeField, Required] private Transform positionOff;
        [SerializeField, Required] private Image button;
        [SerializeField, Required] private Image background;
        [SerializeField, Required] private Image border;
        [SerializeField, Required] private TextMeshProUGUI title;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeMoveAnimation;
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float hoverScale;
        [SerializeField] private Color colorOn;
        [SerializeField] private Color colorOff;

        public bool IsOn { get; private set; }

        /*******************************************************************/
        public void AddClickAction(Action action) => ClickAction += action;

        public void SwitchAnimation()
        {
            interactableAudio.ClickSound();
            SwitchAnimation(!IsOn);
        }

        public void SwitchAnimation(bool isOn)
        {
            button.transform.DOMove(isOn ? positionOn.position : positionOff.position, timeMoveAnimation);
            button.DOColor(isOn ? colorOff : colorOn, timeMoveAnimation);
            border.DOColor(isOn ? colorOff : colorOn, timeMoveAnimation);
            background.DOColor(isOn ? colorOn : colorOff, timeMoveAnimation);
            IsOn = isOn;
        }

        private void SwitchHoverOn()
        {
            interactableAudio.HoverOnSound();
            title.fontStyle = FontStyles.Bold;
            button.transform.DOScale(hoverScale, timeHoverAnimation);
        }

        private void SwitchHoverOff()
        {
            interactableAudio.HoverOffSound();
            title.fontStyle = FontStyles.Normal;
            button.transform.DOScale(1f, timeHoverAnimation);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            SwitchAnimation();
            ClickAction?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => SwitchHoverOn();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => SwitchHoverOff();
    }
}
