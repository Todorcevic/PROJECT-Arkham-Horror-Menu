﻿using Arkham.Presenters;
using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkham.Managers
{
    public class InvestigatorSelectorsManager : MonoBehaviour, IInvestigatorSelectorsManager
    {
        [Title("RESOURCES")]
        [SerializeField, Required, SceneObjectsOnly] private Transform placeHoldersZone;
        [SerializeField, Required, SceneObjectsOnly] private List<InvestigatorSelectorView> selectors;

        public Transform PlaceHolderZone => placeHoldersZone;
        public List<IInvestigatorSelector> Selectors => selectors.OfType<IInvestigatorSelector>().ToList();
        public IInvestigatorSelector GetLeadSelector => selectors.Find(i => i.IsLeader);

        /*******************************************************************/
        public IInvestigatorSelector GetEmptySelector() => Selectors.Find(selector => selector.Id == null);

        public IInvestigatorSelector GetSelectorById(string cardId) =>
            Selectors.Find(selector => selector.Id == cardId);

        public void ArrangeSelectorsAndSetThisLead(string leadInvestigatorId)
        {
            foreach (var selector in Selectors)
            {
                selector.SetTransform(selector.IsEmpty ? transform : placeHoldersZone);
                selector.ArrangeTo();
            }
            SetLeadSelector(leadInvestigatorId);
        }

        public void SetLeadSelector(string leadInvestigatorId)
        {
            if (leadInvestigatorId == GetLeadSelector.Id || leadInvestigatorId == null) return;
            GetLeadSelector.ActivateLeaderIcon(false);
            GetSelectorById(leadInvestigatorId).ActivateLeaderIcon(true);
        }
    }
}
