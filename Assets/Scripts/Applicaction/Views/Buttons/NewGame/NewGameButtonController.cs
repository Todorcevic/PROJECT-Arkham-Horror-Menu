﻿using Zenject;

namespace Arkham.Application
{
    public class NewGameButtonController : IInitializable
    {
        [Inject(Id = "NewGameButton")] private readonly ButtonView newGameButton;
        [Inject(Id = "NewGameModal")] private readonly PanelView newGameModal;

        /*******************************************************************/
        void IInitializable.Initialize() => newGameButton.AddClickAction(() => newGameModal.Activate(true));
    }
}
