using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    public GameManager gm;
    public bool gameDone;
    [Tooltip("This is in seconds")]
    public float timeTillEnd;

    public void GetGm()
    {
        gm = gm = GameObject.FindObjectOfType<GameManager>();
        if(gm == null)
        {
            Debug.Log("There is no game manager in the scene");
        }
    }

    
}
