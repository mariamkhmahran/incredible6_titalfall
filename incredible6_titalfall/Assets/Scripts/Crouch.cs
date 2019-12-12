using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Crouch : MonoBehaviour
{
    private FirstPersonController fps;
    private CharacterController m_CharacterController;
    public bool m_Crouch = false;
    private float m_OriginalHeight;
    private float m_CrouchHeight = 2.0f;
    private bool doUpdate = false;
    // Start is called before the first frame update
    void Start()
    {
        fps = GetComponent<FirstPersonController>();
        m_CharacterController = GetComponent<CharacterController>();
        m_OriginalHeight = m_CharacterController.height;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag=="Pilot")
        if (!GetComponent<FirstPersonController>().getWalking())
        {
            m_CharacterController.height = m_OriginalHeight;
            m_CharacterController.center = Vector3.down * (m_OriginalHeight - m_CharacterController.height) / 2.0f;
            float newCamPos = fps.m_Camera.transform.localPosition.y;
            Vector3 newPos = new Vector3(fps.m_Camera.transform.localPosition.x, newCamPos, fps.m_Camera.transform.localPosition.z);
            fps.m_Camera.transform.localPosition = Vector3.Lerp(fps.m_Camera.transform.localPosition, newPos, Time.deltaTime);
            fps.UpdateCamera();
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
            m_CharacterController.center = Vector3.down * (m_OriginalHeight- m_CharacterController.height) / 2.0f;
            float newCamPos =fps.m_OriginalCameraPosition.y - 320;
            Vector3 newPos = new Vector3(fps.m_Camera.transform.localPosition.x, newCamPos, fps.m_Camera.transform.localPosition.z);

            fps.m_Camera.transform.localPosition = Vector3.Lerp(fps.m_Camera.transform.localPosition, newPos, Time.deltaTime);
        }
        else
        {
 //           GetComponent<FirstPersonController>().transform.position = new Vector3(GetComponent<FirstPersonController>().transform.position.x, 8.0f, GetComponent<FirstPersonController>().transform.position.z);
            m_CharacterController.height = m_OriginalHeight;
            m_CharacterController.center = Vector3.down * (m_OriginalHeight - m_CharacterController.height) / 2.0f;
            float newCamPos = fps.m_Camera.transform.localPosition.y;
            Vector3 newPos = new Vector3(fps.m_Camera.transform.localPosition.x, newCamPos, fps.m_Camera.transform.localPosition.z);
            fps.m_Camera.transform.localPosition = Vector3.Lerp(fps.m_Camera.transform.localPosition, newPos, Time.deltaTime );
            fps.UpdateCamera();
        }
    }
    

}
