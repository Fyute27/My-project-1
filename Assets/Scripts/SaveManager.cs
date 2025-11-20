using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        // for testing
        /*if (PlayerPrefs.HasKey("Deaths"))
        {
            PlayerPrefs.SetInt("Deaths", 0);
        }*/
        var deaths = PlayerPrefs.GetInt("Deaths", 0); 
        PlayerPrefs.SetInt("Deaths", deaths +  1); 
        Debug.Log(PlayerPrefs.GetInt("Deaths", 0));
    } 
}
