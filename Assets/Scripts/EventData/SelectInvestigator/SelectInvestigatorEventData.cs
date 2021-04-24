﻿using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class SelectInvestigatorEventData : ISelectInvestigator, ISelectInvestigatorEvent
    {
        [Inject] private readonly Repository repository;
        private event Action<string> InvestigatorSelected;

        /*******************************************************************/
        void ISelectInvestigator.Selecting(string investigatorId)
        {
            repository.CurrentInvestigatorSelected = investigatorId;
            InvestigatorSelected?.Invoke(investigatorId);
        }

        void ISelectInvestigatorEvent.AddSelectedAction(Action<string> action) => InvestigatorSelected += action;
    }
}
