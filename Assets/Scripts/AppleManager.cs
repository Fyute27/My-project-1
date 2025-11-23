using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    // persistent singleton (to store data)
    public static AppleManager instance;

    public HashSet<int> collectedApples = new HashSet<int>();
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

    public void CollectApple(int id)
    {
        collectedApples.Add(id);
    }

    public bool isCollected(int id)
    {
        return collectedApples.Contains(id);

    }

}
