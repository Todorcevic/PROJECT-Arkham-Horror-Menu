﻿using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class DeckCardController : IDeckCardController
    {
        [Inject] private readonly AddCardEventDomain addCardEvent;

        /*******************************************************************/
        public void Clicked(string cardId) => addCardEvent.AddCard(cardId);
    }
}
