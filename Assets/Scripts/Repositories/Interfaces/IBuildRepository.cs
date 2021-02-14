﻿using Arkham.Models;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IBuildRepository
    {
        string CurrentScenario { set; }
        List<CardInfo> CardInfoList { set; }
        List<string> InvestigatorsSelectedList { set; }
        List<InvestigatorInfo> InvestigatorsList { set; }
        List<CampaignInfo> CampaignsList { set; }
    }
}
