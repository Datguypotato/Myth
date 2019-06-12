using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    //public GameManager gm;
    public bool gameDone;
    public bool playerWin;

    [Tooltip("This is in seconds")]
    public float timeTillEnd;

    protected void Win()
    {
        gameDone = true;
        playerWin = true;
        Debug.Log("You won");
    }

    protected void Lose()
    {
        gameDone = true;
        playerWin = false;
        Debug.Log("You lost");
    }
}
