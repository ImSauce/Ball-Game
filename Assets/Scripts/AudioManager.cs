



using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("-------------[ Audio Source ]-------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("-------------[ Audio Clip ]-------------")]
    public AudioClip background;
    public AudioClip collect;
    public AudioClip win;
    public AudioClip collide;
    public AudioClip lose;

    [Header("-------------[ Sliders ]-------------")]
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    private void Start()
    {
        // Set background music
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();

        // Set default slider values
        if (musicSlider != null)
        {
            musicSlider.value = musicSource.volume;
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = sfxSource.volume;
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp01(volume);
        Debug.Log(volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp01(volume);
    }


    public void mute()
    {
        SetMusicVolume(0);
    }

    public void unmute()
    {
        SetMusicVolume(1);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void collideSFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip, 0.1f);
    }
}