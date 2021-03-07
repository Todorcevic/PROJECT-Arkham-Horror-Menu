﻿using Zenject;
using Arkham.Repositories;
using Arkham.Services;
using Arkham.Scenarios;
using Arkham.Factories;
using Arkham.Controllers;
using Arkham.Presenters;
using Arkham.Interactors;
using Arkham.Views;
using Arkham.EventData;

namespace Arkham.Config
{
    public class DependecyInstaller : Installer<DependecyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
            Container.BindInterfacesAndSelfTo<Repository>().AsSingle();

            /*** Services ***/
            Container.BindInterfacesTo<ScreenResolutionAutoDetect>().AsSingle();
            Container.BindInterfacesTo<DataPersistence>().AsSingle();
            Container.Bind<IFileAdapter>().To<FileAdapter>().AsSingle();
            Container.Bind<IScreenResolutionAdapter>().To<ScreenResolutionAdapter>().AsSingle();
            Container.Bind<IInstantiatorAdapter>().To<NameConventionInstantiator>().AsSingle();
            Container.Bind<ISerializer>().To<JsonNewtonsoftAdapter>().AsSingle();
            Container.Bind<IDoubleClickDetector>().To<DoubleClickDetector>().AsSingle();
            Container.Bind<IScenarioLoader>().To<ScenarioLoader>().AsSingle();

            /*** Controllers ***/
            Container.Bind<IController>().To<CampaignController>().AsSingle().WhenInjectedInto<CampaignView>();
            Container.Bind<IController>().To<CardSelectorController>().AsSingle().WhenInjectedInto<CardSelectorView>();
            Container.Bind<IController>().To<InvestigatorSelectorController>().AsSingle().WhenInjectedInto<InvestigatorSelectorView>();
            Container.Bind<IController>().To<DeckCardController>().AsSingle().WhenInjectedInto<DeckCardView>();
            Container.Bind<IController>().To<InvestigatorCardController>().AsSingle().WhenInjectedInto<InvestigatorCardView>();


            //Container.BindInterfacesTo<InvestigatorSelectorController>().AsSingle();
            //Container.BindInterfacesTo<CardSelectorController>().AsSingle();
            //Container.BindInterfacesTo<InvestigatorCardController>().AsSingle();
            //Container.BindInterfacesTo<DeckCardController>().AsSingle();

            /*** Presenters ***/
            Container.BindInterfacesTo<CampaignPresenter>().AsSingle();
            Container.BindInterfacesTo<InvestigatorSelectorPresenter>().AsSingle();
            Container.BindInterfacesTo<CardSelectorPresenter>().AsSingle();
            Container.BindInterfacesTo<InvestigatorCardPresenter>().AsSingle();
            Container.BindInterfacesTo<DeckCardPresenter>().AsSingle();
            Container.BindInterfacesTo<InvestigatorAvatarPresenter>().AsSingle();
            Container.BindInterfacesTo<CardsQuantityPresenter>().AsSingle();

            /*** Interactors ***/
            Container.BindInterfacesTo<CampaignInteractor>().AsSingle();
            Container.BindInterfacesTo<InvestigatorSelectorInteractor>().AsSingle();
            Container.BindInterfacesTo<CardSelectorInteractors>().AsSingle();
            Container.BindInterfacesTo<CardInfoInteractor>().AsSingle();
            Container.BindInterfacesTo<InvestigatorInfoInteractor>().AsSingle();

            Container.BindInterfacesTo<ClickableCards>().AsSingle();
            Container.BindInterfacesTo<CurrentInvestigator>().AsSingle();

            /*** Factories ***/
            Container.BindInterfacesTo<DeckCardFactory>().AsSingle();
            Container.BindInterfacesTo<InvestigatorCardFactory>().AsSingle();

            /*** Event Data ***/
            Container.BindInterfacesTo<AddInvestigatorEventData>().AsSingle();
            Container.BindInterfacesTo<RemoveInvestigatorEventData>().AsSingle();
            Container.BindInterfacesTo<SelectInvestigatorEventData>().AsSingle();
            Container.BindInterfacesTo<CampaignEventData>().AsSingle();
            Container.BindInterfacesTo<AddCardEventData>().AsSingle();
            Container.BindInterfacesTo<RemoveCardEventData>().AsSingle();

            /*** Execution Order ***/
            Container.BindExecutionOrder<ScreenResolutionAutoDetect>(-100);
            Container.BindExecutionOrder<DataPersistence>(-100);
            Container.BindExecutionOrder<CardFactory>(-90);
            Container.BindExecutionOrder<CampaignPresenter>(-80);
            Container.BindExecutionOrder<InvestigatorSelectorPresenter>(-80);
            Container.BindExecutionOrder<CardSelectorPresenter>(-80);
            Container.BindExecutionOrder<InvestigatorCardPresenter>(-80);
            Container.BindExecutionOrder<DeckCardPresenter>(-80);
            Container.BindExecutionOrder<InvestigatorAvatarPresenter>(-80);
            Container.BindExecutionOrder<CardsQuantityPresenter>(-80);
        }
    }
}
