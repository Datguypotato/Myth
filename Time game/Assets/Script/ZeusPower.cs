using System.Collections;
using System.Collections.Generic;
using DigitalRuby.LightningBolt;
using UnityEngine;

/* summary
 * This handles everything of the power of zeus
 * the lightning is a linerenderer and has a sphere trigger on the ground
 * timebetweenlightning is basicaly like a cooldown
*/
public class ZeusPower : MonoBehaviour
{

    public GameObject thunderPrefab;
    public GameObject thunderHit;
    
    public float timeBetweenLightning;

    float lightningCooldown;

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && lightningCooldown < Time.time)
        {
            Ray ray = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            lightningCooldown = Time.time + timeBetweenLightning;

            if (Physics.Raycast(ray, out RaycastHit hit, 20f))
            {
                if (hit.collider != null)
                {
                    Vector3 offset = new Vector3(0, 1, 0);

                    GameObject temp = Instantiate(thunderPrefab, hit.point + offset, new Quaternion(0, 0, 0, 0));
                    GameObject hitTemp = Instantiate(thunderHit, hit.point + offset, new Quaternion(0, 0, 0, 0));

                    hitTemp.transform.eulerAngles = new Vector3(90, 0, 0);

                    Destroy(temp, .2f);
                    Destroy(hitTemp, 1f);
                    LightningBoltScript lightningbolt = temp.GetComponent<LightningBoltScript>();
                    
                }
            }
        }
#endif

        //if(Input.GetTouch(0) > 1)

#if UNITY_IOS
        
#endif
    }
}
