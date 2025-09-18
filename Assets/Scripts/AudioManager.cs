using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private Slider musicSlider;
    private Slider sfxSlider;

    private static AudioManager instance;

    // store last volume before mute
    private float lastMusicVolume = 0.5f;
    private float lastSFXVolume = 0.5f;
    private bool isMusicMuted = false;
    private bool isSFXMuted = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.volume = musicVol;
        sfxSource.volume = sfxVol;
        musicSource.Play();

        lastMusicVolume = musicVol;
        lastSFXVolume = sfxVol;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HookSliders();
    }

    private void HookSliders()
    {
        GameObject musicObj = GameObject.FindWithTag("MusicSlider");
        GameObject sfxObj   = GameObject.FindWithTag("SFXSlider");

        musicSlider = (musicObj != null) ? musicObj.GetComponent<Slider>() : null;
        sfxSlider   = (sfxObj != null) ? sfxObj.GetComponent<Slider>() : null;

        if (musicSlider != null)
        {
            musicSlider.onValueChanged.RemoveAllListeners();
            musicSlider.value = musicSource.volume;
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        if (sfxSlider != null)
        {
            sfxSlider.onValueChanged.RemoveAllListeners();
            sfxSlider.value = sfxSource.volume;
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (!isMusicMuted)
        {
            musicSource.volume = Mathf.Clamp01(volume);
            lastMusicVolume = musicSource.volume;
            PlayerPrefs.SetFloat("MusicVolume", musicSource.volume);
        }

        if (musicSlider != null && !isMusicMuted)
            musicSlider.value = musicSource.volume;
    }

    public void SetSFXVolume(float volume)
    {
        if (!isSFXMuted)
        {
            sfxSource.volume = Mathf.Clamp01(volume);
            lastSFXVolume = sfxSource.volume;
            PlayerPrefs.SetFloat("SFXVolume", sfxSource.volume);
        }

        if (sfxSlider != null && !isSFXMuted)
            sfxSlider.value = sfxSource.volume;
    }

    // ----------------- Mute / Unmute -----------------
    public void MuteMusic()
    {
        if (!isMusicMuted)
        {
            lastMusicVolume = musicSource.volume;
            musicSource.volume = 0f;
            isMusicMuted = true;

            if (musicSlider != null)
                musicSlider.value = 0f;
        }
    }

    public void UnmuteMusic()
    {
        if (isMusicMuted)
        {
            musicSource.volume = lastMusicVolume;
            isMusicMuted = false;

            if (musicSlider != null)
                musicSlider.value = lastMusicVolume;
        }
    }

    public void MuteSFX()
    {
        if (!isSFXMuted)
        {
            lastSFXVolume = sfxSource.volume;
            sfxSource.volume = 0f;
            isSFXMuted = true;

            if (sfxSlider != null)
                sfxSlider.value = 0f;
        }
    }

    public void UnmuteSFX()
    {
        if (isSFXMuted)
        {
            sfxSource.volume = lastSFXVolume;
            isSFXMuted = false;

            if (sfxSlider != null)
                sfxSlider.value = lastSFXVolume;
        }
    }

    // ----------------- Play SFX -----------------
    public void PlaySFX(AudioClip clip)
    {
        if (!isSFXMuted)
            sfxSource.PlayOneShot(clip);
    }

    public void collideSFX(AudioClip clip)
    {
        if (!isSFXMuted)
            sfxSource.PlayOneShot(clip, 0.1f);
    }
}
