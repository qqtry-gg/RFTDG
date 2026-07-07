using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public void ButtonsPressed()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonPressed);
    }
}
