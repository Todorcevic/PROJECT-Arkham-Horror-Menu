﻿using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.Views;

namespace Arkham.SettingObjects
{
    public abstract class CampaignState : ScriptableObject
    {
        [SerializeField, Required] protected bool isOpen;
        public string Id => name;
        public bool IsOpen => isOpen;

        /*******************************************************************/
        public abstract void ExecuteState(CampaignView campaignView);
    }
}
