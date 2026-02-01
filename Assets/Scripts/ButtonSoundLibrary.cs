using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundLibrary : MonoBehaviour
{
    public AudioClip Click;
    public AudioClip Hover;

    public void PlayClick()
    {
        GetComponent<AudioSource>().PlayOneShot(Click);
    }

    public void PlayHover()
    {
        if (GetComponent<Button>().interactable)
            GetComponent<AudioSource>().PlayOneShot(Hover);
    }
}
