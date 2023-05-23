using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    private PlayerController playerControllerScript;
    private BlackFarmerMan bfm;
    private BrownFarmerWoman bfw;
    private WhiteBusinessMan wbm;
    private WhiteWaitressWoman www;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (MainManager.Instance.gameOver == false)
        {
            if (MainManager.Instance.doubleSpeed)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed * 2);
            }

            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);

            }
        }
        

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
