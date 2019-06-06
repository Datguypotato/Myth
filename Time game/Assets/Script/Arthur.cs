using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arthur : MiniGame
{
    public float progress;

    // Start is called before the first frame update
    void Start()
    {
        GetGm();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            progress += .10f;
        }
        
    }
}
