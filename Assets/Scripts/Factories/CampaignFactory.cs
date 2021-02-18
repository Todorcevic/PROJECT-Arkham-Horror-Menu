﻿using Arkham.Controllers;
using Arkham.Iterators;
using Arkham.Managers;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Factories
{
    public class CampaignFactory : ICampaignFactory
    {
        [Inject] private readonly ICampaignsManager campaignsManager;
        [Inject] private readonly ICampaignInteractor campaignInteractor;

        public void BuildCampaigns()
        {
            foreach (ICampaignView campaign in campaignsManager.Campaigns)
                new CampaignController(campaign, campaignInteractor);

            campaignInteractor.InitializeCampaigns();
        }
    }
}
