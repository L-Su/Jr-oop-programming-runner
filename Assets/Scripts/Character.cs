using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    protected Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    private AudioSource playerAudio;

    private int remainJump;
    public int jumpCapability = 2;
    public float score = 0;
    public bool doubleSpeed = false;
    public TextMeshProUGUI scoreText; 

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        remainJump = jumpCapability;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Dash();
        if (!gameOver)
        {
            Debug.Log("Score: " + score);
        }
        scoreText.text = "Score: " + score;
    }

    public virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && remainJump > 0 && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            remainJump--;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    public virtual void Dash()
    {
        if (Input.GetKey(KeyCode.D) && !gameOver)
        {
            doubleSpeed = true;
            MainManager.Instance.doubleSpeed = doubleSpeed;
            playerAnim.SetFloat("Speed_Multiplier", 2.0f);
            MainManager.Instance.dashSpeed = 2.0f;
            score += 2;
            Debug.Log(score);
        }
    }

    public virtual void run()
    {
        if (doubleSpeed && !gameOver)
        {
            doubleSpeed = false;
            MainManager.Instance.doubleSpeed = doubleSpeed;
            playerAnim.SetFloat("Speed_Multiplier", 1.0f);
            MainManager.Instance.runSpeed = 1.0f;
            score++;
            Debug.Log(score);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            remainJump = jumpCapability;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            MainManager.Instance.gameOver = gameOver;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    public void UpdateScore()
    {
        
        
    }


}
