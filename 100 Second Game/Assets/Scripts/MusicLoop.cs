using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public AudioSource music;
    public AudioSource winSound;
    // Start is called before the first frame update
    //void Awake()
    //{
    //    GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");
    //    if (obj.Length > 1)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //    else
    //    {
    //        DontDestroyOnLoad(this.gameObject);
    //    }
    //}

    private void Update()
    {
        if (winSound.isPlaying && winSound != null)
        {
            music.mute = true;
        }
        if (winSound.isPlaying == false && winSound != null)
        {
            music.mute = false;
        }
        if (winSound == null)
        {
            music.mute = false;
        }
    }
}
