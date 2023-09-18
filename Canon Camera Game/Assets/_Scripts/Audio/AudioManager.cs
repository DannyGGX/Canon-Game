using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public SoundSO[] Sounds;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);


    }

}
