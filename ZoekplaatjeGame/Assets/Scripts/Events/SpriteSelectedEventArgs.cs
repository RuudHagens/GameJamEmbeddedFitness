using System;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class SpriteSelectedEventArgs : EventArgs
    {
         public Sprite SelectedSprite { get; protected set; }

        public SpriteSelectedEventArgs(Sprite selectedSprite)
        {
            if (!selectedSprite) throw new ArgumentNullException("selectedSprite");
            SelectedSprite = selectedSprite;
        }
    }
}