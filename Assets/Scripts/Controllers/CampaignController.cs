﻿using Arkham.Repositories;
using Arkham.UI;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class CampaignController : ICampaignController
    {
        [Inject] private readonly ICampaignRepository repository;
        private ICampaignView campaignView;

        /*******************************************************************/
        public void Init(ICampaignView campaignView)
        {
            this.campaignView = campaignView;
        }

        public void Click()
        {
            if (!campaignView.IsOpen) return;
            campaignView.ClickEffect();
            repository.CurrentScenario = campaignView.FirstScenarioId;
        }

        public void HoverOn() =>
            campaignView.HoverOnEffect();

        public void HoverOff() =>
            campaignView.HoverOffEffect();
    }
}
