﻿using Zenject;

namespace Arkham.Interactors
{
    public class ClickableCardsInteractor : IClickableCards
    {
        [Inject] private readonly ICurrentInvestigatorInteractor currentInvestigator;

        /*******************************************************************/
        public bool IsClickable(string cardId)
        {
            if (IsMandatoryCard(cardId)) return false;
            return true;
        }

        private bool IsMandatoryCard(string cardId) => currentInvestigator.MandatoryCards.Contains(cardId);
    }
}
