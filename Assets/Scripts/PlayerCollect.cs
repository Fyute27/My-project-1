using TMPro;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private int _appleCount = 0;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Apple"))
        {
            GameManager.instance.apples++;
            _appleCount++;
            UIManager.instance.SetAppleCount(_appleCount);
            Destroy(other.gameObject);
        }
        
    }
    
    
    
}
