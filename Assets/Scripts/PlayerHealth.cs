using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    
    
    public CinemachineCamera cam;
    
    
    private Rigidbody2D _rb;
    private Animator _animator;
    private CapsuleCollider2D _collider;
    private PlayerController _playerController;
    private Transform respawnPoint;
    
        


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<CapsuleCollider2D>();
        _playerController = GetComponent<PlayerController>();
        respawnPoint = GameObject.Find("Respawn Point").transform;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            SaveManager.instance.Die();
            GameManager.instance.deaths++; 
            _playerController.canMove = false;
            _animator.SetBool("isFalling", true);
            _rb.linearVelocity = new Vector2(0, _playerController.jumpForce);
            _collider.enabled = false;
            cam.Follow = null;
            cam.Lens.OrthographicSize = 14;
            //gameOverPanel.SetActive(true);
            //can be used in teleport point = transform.position = respawnPoint.position;
            StartCoroutine(RespawnCo());
        }
        
        else if (other.CompareTag("Fall"))
        {
            SaveManager.instance.Die();
            GameManager.instance.deaths++;
            _playerController.canMove = false;
            _animator.SetBool("isFalling", true);
            _collider.enabled = false;
            cam.Follow = null;
            cam.Lens.OrthographicSize = 14;
            UIManager.instance.ShowGameOver();
            
        }
        else if (other.CompareTag("Saw"))
        {
            SaveManager.instance.Die();
            GameManager.instance.deaths++;
            _playerController.canMove = false;
            _animator.SetBool("isFalling", true);
            _collider.enabled = false;
            cam.Follow = null;
            cam.Lens.OrthographicSize = 14;
            UIManager.instance.ShowGameOver();
            
        }
    }
    
    
    //Coroutines
    private IEnumerator RespawnCo() 
    {
        yield return new WaitForSeconds(3f);
        transform.position = respawnPoint.position;
        _playerController.canMove = true;
        _rb.linearVelocity = new Vector2(0, 0);
        _collider.enabled = true;
        cam.Follow = transform;
        cam.Lens.OrthographicSize = 7;
      
    }
    
    
    
}





