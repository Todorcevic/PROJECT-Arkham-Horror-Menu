﻿using UnityEngine;

namespace Arkham.Application
{
    public class CardShowerDTO
    {
        public string CardId { get; }
        public Vector2 Position { get; }
        public Vector2 FinalPosition { get; }
        private float AxisYMiddleScreen => Screen.height * 0.5f;
        private float AxisXLeftOffset => Screen.width * -0.22f;
        private float AxisXRightOffset => Screen.width * 0.25f;

        /*******************************************************************/
        public CardShowerDTO(string id, Vector2 position, bool isInLeftSide)
        {
            CardId = id;
            Position = position;
            FinalPosition = new Vector2(position.x + (isInLeftSide ? AxisXLeftOffset : AxisXRightOffset), AxisYMiddleScreen);
        }
    }
}
