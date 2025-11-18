using System;
using System.Collections;
using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
   private Rigidbody2D _rb;

   public float speed;
   public float  jumpForce;
   public Transform groundCheck;
   public LayerMask groundLayer;
   public bool canMove = true;
   public bool isGrounded;
   public AudioClip jumpSound;
   public AudioClip landingSound;
   
   
   private Animator _animator;
   private float _moveX;
   private CapsuleCollider2D _collider;
   
   
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      _rb = GetComponent<Rigidbody2D>();
      _animator = GetComponent<Animator>();
      _collider = GetComponent<CapsuleCollider2D>();
    }
    
    void Update()
    {
      if (canMove)
      {
        HandleMovement();
        HandleAnimation();
        FlipSprite();
      }
      
    }

    private void HandleMovement()
    {
      var G = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
      
      if (!isGrounded && G)
      {
        //landing frame
        
        AudioManager.instance.PlaySfx(landingSound);
      }
      isGrounded = G;

     
      _moveX  = Input.GetAxis("Horizontal"); // if A or left arrow -1, if D or right arrow +1, if nothing 0.
      _rb.linearVelocity = new Vector2(_moveX * speed, _rb.linearVelocity.y);

      if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
      {
        AudioManager.instance.PlaySfx(jumpSound);
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
      }
    }

    private void HandleAnimation()
    {
      _animator.SetBool("isRunning", _moveX !=0); // if player is moving true.
      _animator.SetBool("isRising", _rb.linearVelocity.y >0 && !isGrounded); // if player is jumping.
      _animator.SetBool("isFalling", _rb.linearVelocity.y <0 && !isGrounded); // if player is falling. 
    }

    private void FlipSprite()
    {
      if (_moveX < 0)
      {
        transform.localScale = new Vector3(-2, transform.localScale.y, transform.localScale.z);
      }
      
      else if (_moveX > 0)
      {
        transform.localScale = new Vector3(2, transform.localScale.y, transform.localScale.z);
      }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Finish"))
      {
        UIManager.instance.Win();
        canMove = false;
        _animator.SetBool("isRunning", false);
      }
      
      
    }
    
    //GITHUBTEST
  
    
}
