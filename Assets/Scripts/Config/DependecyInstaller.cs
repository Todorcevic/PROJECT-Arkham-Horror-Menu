﻿using Zenject;
using Arkham.Adapters;
using Arkham.Repositories;
using Arkham.Services;
using Arkham.Scenarios;
using Arkham.Factories;
using Arkham.Controllers;
using Arkham.Presenters;
using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Models;

namespace Arkham.Config
{
    public class DependecyInstaller : Installer<DependecyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFiles>().AsSingle();
            Container.BindInterfacesAndSelfTo<Repository>().AsSingle();

            /** Services **/
            Container.Bind<IFileAdapter>().To<FileAdapter>().AsSingle();
            Container.Bind<IScreenResolutionAdapter>().To<ScreenResolutionAdapter>().AsSingle();
            Container.Bind<IInstantiatorAdapter>().To<NameConventionInstantiator>().AsSingle();
            Container.Bind<ISerializer>().To<JsonNewtonsoftAdapter>().AsSingle();
            Container.Bind<IDoubleClickDetector>().To<DoubleClickDetector>().AsSingle();
            Container.Bind<IResolutionSet>().To<ScreenResolutionAutoDetect>().AsSingle();
            Container.Bind<IScenarioLoader>().To<ScenarioLoader>().AsSingle();
            Container.Bind<IDataPersistence>().To<DataPersistence>().AsSingle();

            /** Controllers **/
            Container.BindInterfacesTo<CampaignController>().AsSingle();
            Container.BindInterfacesTo<InvestigatorSelectorController>().AsSingle();
            Container.BindInterfacesTo<InvestigatorCardController>().AsSingle();
            Container.BindInterfacesTo<DeckCardController>().AsSingle();

            /** Presenters **/
            Container.BindInterfacesTo<CampaignPresenter>().AsSingle();
            Container.BindInterfacesTo<InvestigatorSelectorPresenter>().AsSingle();
            Container.BindInterfacesTo<CardSelectorPresenter>().AsSingle();
            Container.BindInterfacesTo<InvestigatorCardPresenter>().AsSingle();
            Container.BindInterfacesTo<InvestigatorAvatarPresenter>().AsSingle();

            /** Interactors **/
            Container.BindInterfacesTo<CampaignInteractor>().AsSingle();
            Container.BindInterfacesTo<InvestigatorSelectorInteractor>().AsSingle();
            Container.BindInterfacesTo<DeckBuilderInteractor>().AsSingle();
            Container.BindInterfacesTo<CardInfoInteractor>().AsSingle();

            /** Factories **/
            Container.Bind<ICampaignFactory>().To<CampaignFactory>().AsSingle();
            Container.Bind<IInvestigatorSelectorFactory>().To<InvestigatorSelectorFactory>().AsSingle();
            Container.Bind<ICardSelectorFactory>().To<CardSelectorFactory>().AsSingle();
            Container.Bind<ICardFactory>().To<CardFactory>().AsSingle();
        }
    }
}
