using TMPro;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public GameObject appleParticlePrefab; 
    private int _appleCount = 0;
    public AudioClip appleSound;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Apple"))
        {
            
            var appleGO = Instantiate(appleParticlePrefab, other.transform.position, Quaternion.identity);
            var appleParticle = appleGO.GetComponent<ParticleSystem>();
            appleParticle.Play();
            Destroy(appleGO, appleParticle.main.duration);
            AudioManager.instance.PlaySfx(appleSound);
            
            GameManager.instance.apples++;
            _appleCount++;
            UIManager.instance.SetAppleCount(_appleCount);
            Destroy(other.gameObject);
        }
        
    }
    
    
    
}
