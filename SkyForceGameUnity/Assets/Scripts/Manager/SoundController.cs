using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip soundSwitchButton;
    public AudioClip soundClickButton;
    public AudioClip soundBackButton;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void PlaySoundPress()
    {
        audioSource.clip = soundClickButton;
        audioSource.Play();
    }
    public void PlaySoundSwith()
    {
        audioSource.clip = soundClickButton;
        audioSource.Play();
    }
    public void PlaySoundBack()
    {
        audioSource.clip = soundBackButton;
        audioSource.Play();
    }

}
