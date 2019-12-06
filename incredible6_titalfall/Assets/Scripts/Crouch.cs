using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Crouch : MonoBehaviour
{
    private CharacterController m_CharacterController;
    private bool m_Crouch = false;
    private float m_OriginalHeight;
    private float m_CrouchHeight = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_OriginalHeight = m_CharacterController.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<FirstPersonController>().getWalking())
        {
            m_CharacterController.height = m_OriginalHeight;
            m_Crouch = false;
        }
        if (gameObject.tag == "Pilot")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                m_Crouch = !m_Crouch;
                ToggleCrouch();
            }
        }
            
        
    }
    void ToggleCrouch()
    {
        if (m_Crouch)
        {
            m_CharacterController.height = m_CrouchHeight;
        }
        else
        {
            GetComponent<FirstPersonController>().transform.position = new Vector3(GetComponent<FirstPersonController>().transform.position.x, 8.0f, GetComponent<FirstPersonController>().transform.position.z);
            m_CharacterController.height = m_OriginalHeight;

        }
    }
    
}
