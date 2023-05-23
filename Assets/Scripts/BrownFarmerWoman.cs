using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownFarmerWoman : Character
{
    public override void run()
    {
        if (doubleSpeed && !gameOver)
        {
            doubleSpeed = false;
            MainManager.Instance.doubleSpeed = doubleSpeed;
            playerAnim.SetFloat("Speed_Multiplier", 1.5f);
            score += 1.5f;
        }
    }
}
