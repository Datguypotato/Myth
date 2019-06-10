using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arthur : MiniGame
{
    public float progress;

    //float desiredProgress;
    //bool startLerp;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        GetGm();
        Invoke("Lose", timeTillEnd);


        anim = Camera.main.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (!gameDone && Input.GetKeyDown(KeyCode.Space))
        {
            progress += 0.05f;
        }
        anim.SetFloat("AnimationTime", progress);
        Mathf.Clamp(progress, 0, 1);

#endif

//#if UNITY_IOS
        //if(Input.GetTouch())
//#endif

        progress -= Time.deltaTime / 10;
        
        if(progress > 1)
        {
            Debug.Log("You won");
            gameDone = true;
        }
    }

    //called by start
    void Lose()
    {
        Debug.Log("You lost");
    }
}
