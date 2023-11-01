
public class BackgroundSoundButton : ClickSoundButton
{
    protected override void CheckState()
    {
        _isEnabled = !_soundManager.IsBackgroundMute;
    }

    protected override void MuteSound(bool mute)
    {
        _soundManager.BackgroundASMute(mute);
    }
}
