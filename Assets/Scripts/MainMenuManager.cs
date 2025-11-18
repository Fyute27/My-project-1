using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioClip mainMenuMusic;
    public AudioClip uiClickedSfx;

    private void Start()
    {
        AudioManager.instance.PlayMusic(mainMenuMusic);
    }
    
    
    
    
    public void Playbutton()
    {
        //play sfx
        AudioManager.instance.PlaySfx(uiClickedSfx, 0.4f);
        //load level1
        SceneManager.LoadScene("Level1");

    }
    
    public void Options()
    {
        //

    }
    
    public void Quit()
    {

        
    }
    
   
    
    
}

