using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WallRun : MonoBehaviour
{
    private bool isWallR = false;
    private bool isWallL = false;
    private RaycastHit hitR;
    private RaycastHit hitL;
    private int jumpCount = 0;
    private FirstPersonController cc;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<FirstPersonController>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!cc.getJumping())
        {
            jumpCount = 0;  
        }
        if (Input.GetKeyDown(KeyCode.Space)&&jumpCount<=1&&cc.tag=="Pilot")
        {
            if (Physics.Raycast(transform.position,transform.right,out hitR, 1))
            {
                if (hitR.transform.tag == "Wall")
                {
                    cc.setGravity(0.1f);
                    isWallR = true;
                    isWallL = false;
                    jumpCount += 1;
                   // rb.useGravity = false;
                }
            }
            else
            {
                cc.goDownSlowly();
            }
            if (Physics.Raycast(transform.position, -transform.right, out hitL, 1))
            {
                if (hitL.transform.tag == "Wall")
                {
                    cc.setGravity(0.1f);
                    isWallL = true;
                    isWallR = false;
                    jumpCount += 1;
                   // rb.useGravity = false;
                }
            }
            else
            {
                cc.goDownSlowly();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            cc.setGravity(2);
        }
       
    }

}
