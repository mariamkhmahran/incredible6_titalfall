using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titanDropScript : MonoBehaviour
{
    Animator anim;
    Transform parent;
  
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        parent = GetComponentInParent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if(parent.position.y > -2.0f)
        {
            parent.position = new Vector3(parent.position.x, parent.position.y - 0.2f, parent.position.z);
        }
        else{
            anim.SetTrigger("isFalling");
        }
       
    }
   
}
