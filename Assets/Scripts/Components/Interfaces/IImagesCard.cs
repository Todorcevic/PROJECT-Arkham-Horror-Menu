﻿using Arkham.Controllers;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Components
{
    public interface IImagesCard
    {
        bool ExistThisSprite(string id);
        Sprite GetSprite(string id);
    }
}
