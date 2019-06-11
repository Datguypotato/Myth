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

    //public void GetGm()
    //{
    //    gm = gm = GameObject.FindObjectOfType<GameManager>();
    //    if(gm == null)
    //    {
    //        Debug.Log("There is no game manager in the scene");
    //    }
    //}

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
