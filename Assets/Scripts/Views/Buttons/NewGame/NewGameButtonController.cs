﻿using Zenject;

namespace Arkham.Views
{
    public class NewGameButtonController : IInitializable
    {
        [Inject(Id = "NewGameButton")] private readonly IClickable newGameButton;
        [Inject(Id = "NewGameModal")] private readonly IPanelView newGameModal;

        /*******************************************************************/
        void IInitializable.Initialize() => newGameButton.AddAction(() => newGameModal.Activate(true));
    }
}
