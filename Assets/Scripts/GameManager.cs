using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // persistent singleton (to store data)
    public static GameManager instance;

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
    public int apples;
    public int deaths;
}
