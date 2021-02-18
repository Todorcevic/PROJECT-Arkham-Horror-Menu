﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;
using Arkham.Managers;
using Arkham.Controllers;
using Arkham.Components;

namespace Arkham.UI
{
    public class CardFactoryComponent : MonoBehaviour, ICardFactoryComponents
    {
        [Title("CARD PREFABS")]
        [SerializeField, Required, AssetsOnly] private CardDeckController cardDeckPrefab;
        [SerializeField, Required, AssetsOnly] private CardInvestigatorController cardInvestigatorPrefab;
        [SerializeField, Required, AssetsOnly] private CardRowController cardRow;

        [Title("CARD IMAGES")]
        [SerializeField, AssetsOnly] private List<Sprite> cardImagesEN;
        [SerializeField, AssetsOnly] private List<Sprite> cardImagesES;

        [Title("ZONES")]
        [SerializeField, Required, SceneObjectsOnly] private Transform investigatorsZone;
        [SerializeField, Required, SceneObjectsOnly] private Transform deckZone;

        public CardDeckController CardDeckPrefab => cardDeckPrefab;
        public CardInvestigatorController CardInvestigatorPrefab => cardInvestigatorPrefab;
        public CardRowController CardRow => cardRow;
        public List<Sprite> CardImagesEN => cardImagesEN;
        public List<Sprite> CardImagesES => cardImagesES;
        public Transform InvestigatorsZone => investigatorsZone;
        public Transform DeckZone => deckZone;
    }
}
