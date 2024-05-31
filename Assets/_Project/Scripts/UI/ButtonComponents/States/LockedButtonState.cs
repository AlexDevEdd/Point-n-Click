using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class LockedButtonState : BaseButtonState
    {
        public LockedButtonState(Button button, Image buttonBackground, Sprite backgroundSprite) 
            : base(button, buttonBackground, backgroundSprite) {}
        
        public override void SetState()
        {
            Button.interactable = false;
            ButtonBackground.sprite = BackgroundSprite;
        }
    }
}