using UnityEngine;

public class Apple : MonoBehaviour
{
    public int id;

    private void Start()
    {
        if (AppleManager.instance.isCollected(id))
        {
            Destroy(gameObject);
        }
    }
}
