﻿using Arkham.Config;
using Arkham.Application;
using System.IO;
using Zenject;

namespace Arkham.Application
{
    public class ContinueButtonController : IInitializable
    {
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly StartGameUseCase startGame;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;
        [Inject(Id = "MainPanelsManager")] private readonly PanelsMediator mainPanelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView chooseCardPanel;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            continueButton.AddClickAction(Clicked);
            continueButton.Desactive(!CanContinue());
        }

        /*******************************************************************/
        public void Desactive(bool desactivate) => continueButton.Desactive(desactivate);

        private void Clicked()
        {
            startGame.Init(StartGame.Continue);
            mainPanelsManager.SelectPanel(chooseCardPanel);
        }

        private bool CanContinue() => File.Exists(gameFiles.PlayerProgressFilePath);
    }
}
