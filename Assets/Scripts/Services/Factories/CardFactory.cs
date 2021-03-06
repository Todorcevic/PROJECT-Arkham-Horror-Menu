﻿using Arkham.Model;
using Arkham.Application;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Arkham.Services
{
    public class CardFactory : MonoBehaviour, ICardFactory
    {
        [Inject] private readonly DiContainer diContainer;
        [Inject] private readonly ICardImage imageCards;
        [Inject] private readonly CardRepository cardCollection;
        [Inject] private readonly CardsManager cardsManager;
        [SerializeField, Required, AssetsOnly] private DeckCardView cardPrefab;
        [SerializeField, Required, AssetsOnly] private InvestigatorCardView investigatorPrefab;
        [SerializeField, Required, SceneObjectsOnly] private Transform cardZone;
        [SerializeField, Required, SceneObjectsOnly] private Transform investigatorZone;

        private IEnumerable<string> DeckCards => cardCollection.FindAll(c => (c.Type_code == "asset"
               || c.Type_code == "event"
               || c.Type_code == "skill")
               && (c.Subtype_code != "basicweakness"
               && c.Subtype_code != "weakness")
               && imageCards.ExistThisSprite(c.Id)).OrderBy(c => c.Faction_code).ThenBy(c => c.Id).Select(c => c.Id);

        private IEnumerable<string> InvestigatorCards => cardCollection
                .FindAll(c => c.Type_code == "investigator" && imageCards.ExistThisSprite(c.Id))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Id).Select(c => c.Id);

        /*******************************************************************/
        public void BuildDeckCards()
        {
            foreach (string cardId in DeckCards)
            {
                object[] args = new object[] { cardId, imageCards.GetSprite(cardId) };
                DeckCardView cardView = diContainer.InstantiatePrefabForComponent<DeckCardView>(cardPrefab, cardZone, args);
                cardsManager.AddCard(cardId, cardView);
            }
        }

        public void BuildInvestigatorCards()
        {
            foreach (string investigatorId in InvestigatorCards)
            {
                object[] args = new object[] { investigatorId, imageCards.GetSprite(investigatorId) };
                InvestigatorCardView cardView = diContainer.InstantiatePrefabForComponent<InvestigatorCardView>(investigatorPrefab, investigatorZone, args);
                cardsManager.AddCard(investigatorId, cardView);
            }
        }
    }
}