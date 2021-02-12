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
        void Init(ICampaignView campaignView);
        void Click();
        void HoverOn();
        void HoverOff();
    }
}
