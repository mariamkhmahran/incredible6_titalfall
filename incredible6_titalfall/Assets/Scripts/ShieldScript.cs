using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private int bulletCount;
    public bool shieldActive = false;
    private float nextActionTime = 0.0f;
    public float period = 5.0f;
    private bool stopAddition = false;
    void Start()
    {
        
        bulletCount = 0;
    }

    void Update()
    {
      
        if (shieldActive)
        {
            if (!stopAddition)
            {
                nextActionTime = Time.time + period;
                stopAddition = true;
            }

        }
        if(Time.time > nextActionTime)
        {
            gameObject.SetActive(false);
            shieldActive = false;
            stopAddition = false;
        }
        
    }
    public void increaseBulletCount()
    {
        bulletCount += 1;
    }
   
}
