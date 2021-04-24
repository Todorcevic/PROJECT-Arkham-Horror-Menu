﻿using Arkham.EventData;
using Arkham.Interactors;
using UnityEngine;
using Zenject;

namespace Arkham.View
{
    public class ContinueButtonPresenter : IInitializable
    {
        [Inject] private readonly IScenarioEvent changeCampaignEventData;
        [Inject] private readonly IContinueGame continueGame;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            changeCampaignEventData.AddAction(DesactiveButton);
            continueButton.Desactive(!continueGame.CanContinue());
        }

        /*******************************************************************/
        private void DesactiveButton(string scenario) => continueButton.Desactive(scenario == null);


    }
}
