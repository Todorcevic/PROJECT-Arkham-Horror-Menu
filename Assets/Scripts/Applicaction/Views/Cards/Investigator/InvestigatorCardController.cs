﻿using Zenject;
using UnityEngine;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;

namespace Arkham.Application
{
    public class InvestigatorCardController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField, Required] private CardView cardView;
        [Inject] private readonly CardShowerPresenter cardShowerPresenter;
        [Inject] private readonly AddInvestigatorUseCase investigatorAddEvent;
        [Inject] private readonly SelectInvestigatorUseCase investigatorSelectEvent;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging || cardView.IsInactive) return;
            cardView.ClickEffect();
            investigatorAddEvent.Add(cardView.Id);
            investigatorSelectEvent.Select(cardView.Id);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            cardView.HoverOnEffect();
            cardShowerPresenter.HoveredOn(new CardShowerDTO(cardView.Id, transform.position, isInLeftSide: true));
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            cardView.HoverOffEffect();
            cardShowerPresenter.HoveredOff();
        }
    }
}
