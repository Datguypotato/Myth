using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arthur : MiniGame
{
    public float progress;

    Rigidbody rb;
    Camera cam;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //GetGm();
        Invoke("Lose", timeTillEnd);
        cam = GameObject.FindObjectOfType<Camera>();

        rb = cam.GetComponent<Rigidbody>();
        anim = cam.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (!gameDone)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                progress += 0.05f;
            }
            else
            {
                progress -= Time.deltaTime / 10;
            }

            anim.SetFloat("AnimationTime", progress);
            Mathf.Clamp(progress, 0, 1);
        }
        else
        {
            //look at arthur
            cam.transform.LookAt(gameObject.transform);

            anim.enabled = false;
            rb.useGravity = true;
        }

#endif

//#if UNITY_IOS
        //if(Input.GetTouch())
//#endif

        
        
        if(progress > 1)
        {
            Win();
        }
    }

    //called by start

}
