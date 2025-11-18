using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // persistent singleton (to store data)
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        //sfxSource.clip = clip;
        //sfxSource.loop = false;
        //sfxSource.Play();
        //or
        sfxSource.PlayOneShot(clip);
    }
    
    
}
