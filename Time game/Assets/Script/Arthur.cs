using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arthur : MiniGame
{
    public float progress;
    public Transform focusPoint;
    public Camera cam;

    float addProgress = 0.05f;

    Rigidbody rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //GetGm();
        Invoke("Lose", timeTillEnd);

        rb = cam.GetComponent<Rigidbody>();
        anim = cam.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        progress = Mathf.Clamp(progress, 0.1f, 1);

#if UNITY_EDITOR
        if (!gameDone)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                progress += addProgress;
            }
            else
            {
                progress -= Time.deltaTime / 10;
            }

            anim.SetFloat("AnimationTime", progress);
        }
        else if (gameDone && playerWin == false)
        {
            //look at arthur
            cam.transform.LookAt(focusPoint);

            anim.enabled = false;
            rb.useGravity = true;
        }
#endif


        if (!gameDone)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if(touch.phase == TouchPhase.Ended)
                {
                    progress += addProgress;
                }
                else
                {
                    progress -= Time.deltaTime / 10;
                }
            }
            else
            {
                progress -= Time.deltaTime / 10;
            }

            anim.SetFloat("AnimationTime", progress);
        }
        else if(gameDone && playerWin == false)
        {
            //look at arthur
            Debug.Log("0");
            cam.transform.LookAt(focusPoint);

            anim.enabled = false;
            rb.useGravity = true;

        }


        if (progress > 1)
        {
            Win();
            CancelInvoke();
        }
    }

    //called by start

}
