using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HermesTurn : MonoBehaviour
{
    [Range(0, 3)]
    public int rotationint;
    public float rotationMultiplyer;

    Vector3 desiredRotaiton;

    bool startLerping;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 90) * rotationint;
    }

    // Update is called once per frame
    void Update()
    {
        if (startLerping)
        {
            float t = new float();
            t += Time.deltaTime * rotationMultiplyer;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, desiredRotaiton, t);

            if(Vector3.Distance(transform.eulerAngles, desiredRotaiton) < .8)
            {
                transform.eulerAngles = desiredRotaiton;
                startLerping = false;
                t = 0;
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !startLerping)
        {
            desiredRotaiton = transform.eulerAngles + new Vector3(0, 0, 90);
            startLerping = true;
            if(rotationint >= 4)
            {
                rotationint = 1;
            }
            else
            {
                rotationint++;
            }
        }
    }
}
