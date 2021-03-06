﻿using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorsButtonController : IInitializable
    {
        [Inject(Id = "InvestigatorsButton")] private readonly ButtonView investigatorsButton;
        [Inject(Id = "MidPanelsManager")] private readonly PanelsMediator panelsManager;
        [Inject(Id = "InvestigatorsPanel")] private readonly PanelView investigatorsPanel;
        [Inject(Id = "InvestigatorsPanel")] private readonly RectTransform panelToScroll;
        [Inject(Id = "MidZone")] private readonly ScrollRect scroll;

        /*******************************************************************/
        void IInitializable.Initialize() => investigatorsButton.AddClickAction(Clicked);

        /*******************************************************************/
        private void Clicked()
        {
            panelsManager.SelectPanel(investigatorsPanel);
            scroll.content = panelToScroll;
        }
    }
}
