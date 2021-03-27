using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzikKontrol : MonoBehaviour
{
    public static MuzikKontrol instane;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake ()
    {
        Singleton();
        audioSource = GetComponent<AudioSource>();
    }

    void Singleton()
    {
        if (instane != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instane = this;
            DontDestroyOnLoad(instane);
        }
    }

    public void MuzikCal(bool play)
    {
        if (play)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();

            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();

            }

        }
    }
    
}
