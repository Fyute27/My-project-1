using Unity.VisualScripting;
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
    public GameObject sfxSourcePrefab;

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = false;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip, float volume = 0.2f)
    {
        var sfxSourceObject = Instantiate(sfxSourcePrefab, transform);
        var sfxSource = sfxSourceObject.GetComponent<AudioSource>();
        sfxSource.volume = volume;
        //sfxSource.clip = clip;
        //sfxSource.loop = false;
        //sfxSource.Play();
        //or
        sfxSource.PlayOneShot(clip);
        Destroy(sfxSourceObject, clip.length);
    }
    
    
    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void ResumeMusic()
    {
        musicSource.Play();
    }
    
}
