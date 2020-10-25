using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundName
{
    Swoosh,
    Ambient,
    Bubble
}

[System.Serializable]
public class AudioContainer
{
    public SoundName name;
    public AudioClip clip;
}
