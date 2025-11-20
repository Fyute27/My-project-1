using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI totalApplesText;
    public TextMeshProUGUI totalDeathstext;
    public GameObject victoryPanel;
    public static UIManager instance;
    public TextMeshProUGUI applesinLevel1Text;
    public GameObject gameOverPanel;
    
    
    private void Awake()
    {
        instance = this;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // active current scene and then find buildindex
    }
    
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1); // active next scence with +1 and then find buildindex
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Win()
    {
        victoryPanel.SetActive(true);
        totalApplesText.text = GameManager.instance.apples.ToString();
        totalDeathstext.text = GameManager.instance.deaths.ToString();
    }

    public void ShowGameOver()
    { 
        gameOverPanel.SetActive(true);
    }

    public void SetAppleCount(int count)
    {
        applesinLevel1Text.text = count.ToString();
    }
    
}
