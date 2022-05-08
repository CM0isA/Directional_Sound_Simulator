using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSource: MonoBehaviour
{
    public int id;
    [Range(0,360)]
    public int azimuth = 0;
    public int elevation;

}
