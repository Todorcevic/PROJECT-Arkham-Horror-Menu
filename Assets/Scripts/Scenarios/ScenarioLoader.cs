﻿using Arkham.Config;
using Arkham.Services;
using Zenject;

namespace Arkham.Scenarios
{
    public class ScenarioLoader : IScenarioLoader
    {
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly ISerializer serializer;
        [Inject] private readonly IInstantiatorAdapter instanceAdapter;

        /*******************************************************************/
        public Scenario LoadScenario(string scenarioId)
        {
            Scenario scenario = LoadScenarioData(scenarioId);
            scenario.ScenarioLogic = instanceAdapter.CreateInstance<ScenarioLogic>(scenarioId);
            return scenario;
        }

        private Scenario LoadScenarioData(string scenarioId)
        {
            string scenarioPath = gameFiles.JSON_ROOT_DIRECTORY + gameFiles.CAMPAIGNS_DIRECTORY + scenarioId + "/" + gameFiles.SCENARIO_DATA_FILE;
            return serializer.CreateDataFromResources<Scenario>(scenarioPath);
        }
    }
}
