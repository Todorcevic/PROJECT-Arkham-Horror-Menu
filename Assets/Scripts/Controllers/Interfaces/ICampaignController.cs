﻿using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Controllers
{
    public interface ICampaignController
    {
        void Click(CampaignView campaignView);
        void HoverOn(CampaignView campaignView);
        void HoverOff(CampaignView campaignView);
    }
}
