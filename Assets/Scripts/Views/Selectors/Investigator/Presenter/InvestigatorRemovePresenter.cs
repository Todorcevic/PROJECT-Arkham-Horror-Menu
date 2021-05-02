﻿using System.Threading.Tasks;
using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class InvestigatorRemovePresenter : IInitializable
    {
        [Inject] private readonly RemoveInvestigatorEventDomain investigatorRemovedEvent;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly IInvestigatorLeadPresenter selectorLead;

        /*******************************************************************/
        public void Initialize() => investigatorRemovedEvent.Subscribe(RemoveInvestigator);

        /*******************************************************************/
        private async void RemoveInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetSelectorById(investigatorId);
            selector.SetTransform();
            selectorLead.SetLeadSelector();
            await Animation(selector);
            selector.EmptySelector();
        }

        private async Task Animation(InvestigatorSelectorView selector)
        {
            investigatorSelectorsManager.RebuildPlaceHolders();
            investigatorSelectorsManager.ArrangeAllSelectors();
            await selector.RemoveAnimation();
        }
    }
}
