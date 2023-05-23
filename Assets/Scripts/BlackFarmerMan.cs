using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackFarmerMan : Character
{


    public override void Dash()
    {
        if (Input.GetKey(KeyCode.D) && !gameOver)
        {
            doubleSpeed = true;
            MainManager.Instance.doubleSpeed = doubleSpeed;
            playerAnim.SetFloat("Speed_Multiplier", 2.5f);
            score += 2.5f;
        }
    }
}
