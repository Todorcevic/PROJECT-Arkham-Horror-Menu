﻿using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorAvatarPresenter : IInitializable
    {
        [Inject] private readonly InvestigatorAvatarView investigatorAvatar;
        [Inject] private readonly ICardsManager investigatorCardsManager;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;

        /*******************************************************************/
        void IInitializable.Initialize() => selectInvestigatorEvent.AddSelectedAction(ShowInvetigator);

        /*******************************************************************/
        private void ShowInvetigator(string investigatorId)
        {
            UnityEngine.Sprite imageCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            investigatorAvatar.ChangeImage(imageCard);
        }
    }
}
