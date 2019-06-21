using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arthur : MiniGame
{
    public float progress;
    public Transform focusPoint;
    public Camera cam;

    [Space(10)]

    public GameObject winAnimation;
    public GameObject[] arhur;

    float addProgress = 0.08f;

    [Header("Sound")]
    AudioSource soundEffect;
    public AudioClip tadaa, drawSword, Grunt;


    Rigidbody rb;
    Animator animCam;
    Animator animArthur;

    // Start is called before the first frame update
    void Start()
    {
        //GetGm();
        Invoke("Lose", timeTillEnd);

        rb = cam.GetComponent<Rigidbody>();
        animCam = cam.GetComponent<Animator>();
        animArthur = GetComponent<Animator>();
        soundEffect = GameObject.FindObjectOfType<AudioSource>();
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


            animArthur.SetFloat("AnimProgress", progress);
            animCam.SetFloat("AnimationTime", progress);
        }
        else if (gameDone && playerWin == false)
        {
            //look at arthur
            cam.transform.LookAt(focusPoint);

            animCam.enabled = false;
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

            animCam.SetFloat("AnimationTime", progress);
        }
        else if(gameDone && playerWin == false)
        {
            //look at arthur
            Debug.Log("0");
            cam.transform.LookAt(focusPoint);

            animCam.enabled = false;
            rb.useGravity = true;

        }


        if (progress > 1)
        {
            Win();
            CancelInvoke();
            int chance = Random.Range(0, 1);
            if(chance == 1 || chance == 0)
            {
                for (int i = 0; i < arhur.Length; i++)
                {
                    arhur[i].SetActive(false);
                }
                winAnimation.SetActive(true);
            }

            soundEffect.PlayOneShot(tadaa);
            soundEffect.PlayOneShot(drawSword);
        }

    }

    
}
