using UnityEngine;

public class volume : MonoBehaviour
{

  
    private AudioSource audioSrc;

  
    private float musicVolume = 1f;

   
    void Start()
    {

       
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {

       
        audioSrc.volume = musicVolume;
    }

   
    public void SetVolume1(float vol)
    {
        musicVolume = vol;
    }
}