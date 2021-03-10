﻿using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class ImageConfigurator : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvas;
        [SerializeField] private Image image;
        [SerializeField] private Color disableColor;
        public Sprite GetSprite => image.sprite;

        /*******************************************************************/
        public void Activate(bool isEnable)
        {
            image.color = isEnable ? Color.white : disableColor;
            canvas.interactable = canvas.blocksRaycasts = isEnable;
        }

        public void ChangeImage(Sprite sprite)
        {
            canvas.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
        }

        public void Show(bool isShow) => canvas.gameObject.SetActive(isShow);
    }
}
