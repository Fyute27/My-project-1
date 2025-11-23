using UnityEngine;

public class SFXZone : MonoBehaviour
{
    public AudioClip sfx;

    private bool hasPlayed = false;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasPlayed)
        {
            AudioManager.instance.PlaySfx(sfx);
            hasPlayed = true;
        }
        
    }
}
