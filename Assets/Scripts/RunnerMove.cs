using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;

    private bool isGround = false;
    private bool isJumping = false;
    private float jumpTimer;
    Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);
        animator.SetBool("isJumpinging", !isGround);
        if(isGround && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
            audioSource.pitch = UnityEngine.Random.Range(0.9f,1.1f);
            audioSource.Play();
        }

        if(isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
                
            } 
            else
            {
                isJumping = false;
                
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
            
        }
    }

    private void FixedUpdate()
    {
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    
}
