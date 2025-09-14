using UnityEngine;

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


    private void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        SetMusicVolume(0.05f);
        musicSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp01(volume);

    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);

    }
    
    public void collideSFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip,  0.1f);
        
    }
    


}
