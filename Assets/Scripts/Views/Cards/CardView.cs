﻿using Arkham.Presenters;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class CardView : MonoBehaviour, ICardVisualizable, IShowable
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] protected CardEffects effects;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageController imageConfigurator;

        public string Id { get; private set; }
        public Sprite GetCardImage => imageConfigurator.GetSprite;
        public Transform Transform => transform;
        public bool IsInactive { get; set; }

        string IShowable.CardId => Id;
        Color IShowable.ImageColor => IsInactive ? Color.gray : Color.white;
        Vector2 IShowable.Position => Transform.position;

        /*******************************************************************/
        [Inject]
        private void Init(string id, Sprite sprite)
        {
            name = Id = id;
            imageConfigurator.ChangeImage(sprite);
        }

        /*******************************************************************/
        public void ClickEffect()
        {
            if (IsInactive) return;
            effects.ClickEffect();
        }

        public void HoverOnEffect() => effects.HoverOnEffect();

        public void HoverOffEffect() => effects.HoverOffEffect();

        public void Activate(bool isEnable)
        {
            IsInactive = !isEnable;
            imageConfigurator.ChangeColor(isEnable ? Color.white : Color.gray);
            effects.SetEnableColor(IsInactive);
        }

        public void Show(bool isEnable) => gameObject.SetActive(isEnable);
    }
}
