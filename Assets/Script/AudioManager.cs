using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> clipList = new List<AudioClip>();

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }



}
