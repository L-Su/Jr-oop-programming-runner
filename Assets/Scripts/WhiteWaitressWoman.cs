using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteWaitressWoman : Character
{
    public override void run()
    {
        if (doubleSpeed && !gameOver)
        {
            doubleSpeed = false;
            MainManager.Instance.doubleSpeed = doubleSpeed;
            playerAnim.SetFloat("Speed_Multiplier", 0.8f);
            score += 0.8f;
        }
    }
}
