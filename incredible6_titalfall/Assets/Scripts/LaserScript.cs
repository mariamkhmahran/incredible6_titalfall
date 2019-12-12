using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    LineRenderer line;
    private float nextActionTime = 0.0f;
    private float period = 3.0f;
    public bool canCoreAbility;
    private bool stopAddition = false;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        canCoreAbility = false;
    }

    void Update()
    {

        
            if(canCoreAbility&&GetComponentInParent<TitanScript>().gameObject.tag=="Titan")
            if (Input.GetKey(KeyCode.V))
            {
                if (!stopAddition)
                {
                    nextActionTime = Time.time + period;
                    stopAddition = true;
                }
            
                if (Time.time < nextActionTime)
                {
                    StopCoroutine("FireLaser");
                    StartCoroutine("FireLaser");
                }
                
                
          
            }
           



    }

    IEnumerator FireLaser()
    {
        line.enabled = true;
       
        while (canCoreAbility)
        {
            line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            line.SetPosition(0, ray.origin);
            if(Physics.Raycast(ray,out hit, 100))
            {
                line.SetPosition(1, hit.point);
            }
            else
            {
                line.SetPosition(1, ray.GetPoint(100));
            }
            if (Time.time >= nextActionTime)
            {
                canCoreAbility = false;
                stopAddition = false;
                GetComponentInParent<TitanScript>().coreAbilityMeter = 0;
                GetComponentInParent<TitanScript>().coreAbilityActive = false;
            }
            yield return null;
        }
        line.enabled = false;
    }
}
