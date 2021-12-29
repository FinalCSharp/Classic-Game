using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public string[] clipName;
    public AudioClip[] clip;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public int getArrayIndex(string name)
    {
        for(int i = 0; i < clipName.Length; i++)
        {
            if (clipName[i].Equals(name))
            {
                return i;
            }
        }
        return -1;
    }
    public void playSoundEffect(string name)
    {
        audio.clip = clip[getArrayIndex(name)];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
