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
            var apple = other.GetComponent<Apple>();
            AppleManager.instance.CollectApple(apple.id);
            var appleParticleGO = Instantiate(appleParticlePrefab, other.transform.position, Quaternion.identity);
            var appleParticle = appleParticleGO.GetComponent<ParticleSystem>();
            appleParticle.Play();
            Destroy(appleParticleGO, appleParticle.main.duration);
            AudioManager.instance.PlaySfx(appleSound);
            
            GameManager.instance.apples++;
            _appleCount++;
            UIManager.instance.SetAppleCount(_appleCount);
            Destroy(other.gameObject);
        }
        
    }
    
    
    
}
