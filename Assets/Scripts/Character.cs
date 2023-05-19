using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody playerRb;
    public int jumpForce;
    public Animator playerAnim;
    public float dashSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //allow overriding
    public virtual void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public virtual void Dash()
    {
        playerAnim.SetFloat("Speed_Multiplier", dashSpeed);
    }



}
