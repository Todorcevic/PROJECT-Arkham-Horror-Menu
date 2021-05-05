﻿using Arkham.UseCases;
using Arkham.Services;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public const string HOVEROFF = "HoverOff";
        [Inject] private readonly IDoubleClickDetector clickDetector;
        [Inject] private readonly RemoveInvestigatorUseCase investigatorSelector;
        [Inject] private readonly SelectInvestigatorUseCase investigatorSelectEvent;
        [Title("RESOURCES")]
        [SerializeField, Required] private Transform card;
        [SerializeField, Required] private InteractableAudio audioInteractable;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;

        public string Id { private get; set; }

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.IsDoubleClick(eventData.clickTime, eventData.pointerPress))
            {
                DoubleClickEffect();
                investigatorSelector.Remove(Id);
                investigatorSelectEvent.SelectLead();
            }
            else
            {
                ClickEffect();
                investigatorSelectEvent.Select(Id);
            }
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging || DOTween.IsTweening(InvestigatorSelectorView.REMOVE_ANIMATION)) return;
            HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging || DOTween.IsTweening(InvestigatorSelectorView.REMOVE_ANIMATION)) return;
            HoverOffEffect();
        }

        private void ClickEffect() => audioInteractable.ClickSound();

        private void DoubleClickEffect() => audioInteractable.ClickSound();

        private void HoverOnEffect()
        {
            audioInteractable.HoverOnSound();
            card.DOScale(scaleHoverEffect, timeHoverAnimation);
        }

        private void HoverOffEffect()
        {
            audioInteractable.HoverOffSound();
            card.DOScale(1f, timeHoverAnimation).SetId(HOVEROFF);
        }
    }
}
