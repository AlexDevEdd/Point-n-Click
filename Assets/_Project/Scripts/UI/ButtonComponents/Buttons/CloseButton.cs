namespace UI
{
    public sealed class CloseButton : BaseButton
    {
        protected override void SetUpStates()
        {
            StateController.AddState(ButtonStateType.AVAILABLE,
                new AvailableButtonState(Button, ButtonBackground, AvailableButtonSprite));
            
            StateController.AddState(ButtonStateType.LOCKED,
                new LockedButtonState(Button, ButtonBackground, LockedButtonSprite));
        }
    }
}