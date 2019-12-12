using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TitanScript : MonoBehaviour
{
    bool IsembarkTitan;
    private CharacterController m_CharacterController;
    private FirstPersonController fps;
    private float m_OriginalHeight;
    int dashMeter;
    private float nextActionTime = 0.0f;
    public float period = 5.0f;
    private int health = 400;
    public int coreAbilityMeter = 0;
    public bool coreAbilityActive = false;
    GameObject titan;
    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        fps = GetComponent<FirstPersonController>();
        m_OriginalHeight = m_CharacterController.height;
        dashMeter = 3;
    }

    // Update is called once per frame
    void Update()
    {

        activateIonCoreAbility();
        if (!coreAbilityActive)
        {
            increaseCoreAbilityMeter(1);
            //increase coreAbility based on the enemies you shoot and call increaseCoreAbilityMeter(int points)
        }
        dashMeter = fps.dashMeter;
        if (dashMeter < 1)
        {
            fps.disallowDash();
        }
        else
        {
            fps.allowDash();
        }
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            if (dashMeter < 3)
            {
                increaseDashMeter();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!IsembarkTitan)
            {
              gameObject.tag = "Titan";
              embarkTitan();
            }
            else
            {
                gameObject.tag = "Pilot";
                disembarkTitan();
            }
        }
    }
        public void embarkTitan()
    {
        GetComponent<Crouch>().enabled = false;
        GetComponent<pilotScript>().enabled = false;
        IsembarkTitan = true;
        float m_OriginalHeight = m_CharacterController.height;
        m_CharacterController.height = 12.0f;
        m_CharacterController.center = Vector3.down * (m_OriginalHeight - m_CharacterController.height) / 2.0f;
        float newCamPos = fps.m_OriginalCameraPosition.y + 300.0f;
        Vector3 newPos = new Vector3(fps.m_Camera.transform.localPosition.x, newCamPos, fps.m_Camera.transform.localPosition.z);
        fps.m_Camera.transform.localPosition = Vector3.Lerp(fps.m_Camera.transform.localPosition, newPos, Time.deltaTime);
        GameObject go = GameObject.Find("TitanFall");
        GameObject ion = GameObject.Find("Iontitan(Clone)");
        //if the tree exist then destroy it
        if (go)
        {
            Destroy(go.gameObject);
        }
        if (ion)
        {
            Destroy(ion.gameObject);
        }
    }
    public void disembarkTitan()
    {
        titan = (GameObject)Instantiate(Resources.Load("IonTitan"));
        titan.transform.position = transform.position;
        titan.transform.position = new Vector3(titan.transform.position.x,0,titan.transform.position.z + 15.0f);
        IsembarkTitan = false;
        m_CharacterController.height = m_OriginalHeight;
        m_CharacterController.center = Vector3.down * (m_OriginalHeight - m_CharacterController.height) / 2.0f;
        float newCamPos = fps.m_Camera.transform.localPosition.y;
        Vector3 newPos = new Vector3(fps.m_Camera.transform.localPosition.x, newCamPos, fps.m_Camera.transform.localPosition.z);
        fps.m_Camera.transform.localPosition = Vector3.Lerp(fps.m_Camera.transform.localPosition, newPos, Time.deltaTime);
        fps.UpdateCamera();
        GetComponent<Crouch>().enabled = true;
        GetComponent<pilotScript>().enabled = true;
    }
    private void increaseDashMeter()
    {
        if (dashMeter < 3)
        {
            dashMeter += 1;
            fps.dashMeter += 1;
        }
    }
    private void increaseCoreAbilityMeter(int points)
    {
        if (coreAbilityMeter < 100)
        {
            this.coreAbilityMeter += points;

        }
        else
        {
            coreAbilityMeter = 100;
        }
    }
    private void activateIonCoreAbility()
    {
        if (coreAbilityMeter == 100)
        {
            GetComponentInChildren<LaserScript>().canCoreAbility = true;
            coreAbilityActive = true;
        }
    }
}
