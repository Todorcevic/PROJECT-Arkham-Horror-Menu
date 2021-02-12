﻿using Arkham.Models;
using Arkham.Repositories;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public abstract class CardController
    {
        [Inject] protected readonly ICardInfoRepository infoRepository;
        protected CardView cardView;

        /*******************************************************************/
        protected abstract int AmountSelected(string investigatorId);

        public void Init(CardView cardView) => this.cardView = cardView;

        public void HoverOn() => cardView.HoverOnEffect();

        public void HoverOff() => cardView.HoverOffEffect();

        public void SwitchEnable() => cardView.Enable(TotalAmount(cardView.Id) > 0);

        private int TotalAmount(string cardId) =>
            (infoRepository.AllCardsInfo(cardId).Quantity ?? 0) - AmountSelected(cardId);
    }
}
