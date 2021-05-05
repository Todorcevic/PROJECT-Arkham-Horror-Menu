﻿using Zenject;
using Arkham.UseCases;

namespace Arkham.Views
{
    public class CampaignController
    {
        [Inject(Id = "MainPanelsManager")] private readonly PanelsManagerComponent panelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView panelToShow;
        [Inject] private readonly SelectScenarioUseCase scenarioEvent;

        /*******************************************************************/
        public void Clicked(string campaignId)
        {
            scenarioEvent.SelectCampaign(campaignId);
            panelsManager.SelectPanel(panelToShow);
        }
    }
}
