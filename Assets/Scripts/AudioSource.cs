using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSource: MonoBehaviour
{
    public int id;
    [Range(0,360)]
    public float azimuth = 0;
    public float elevation;


    private void Update()
    {
        float radiansAzimuth = Mathf.Atan2(transform.position.z, transform.position.x);
        azimuth = (float)Math.Truncate((180 / Mathf.PI) * radiansAzimuth);
        if (azimuth < 0)
            azimuth += 360;

        elevation = (float)Math.Truncate(100 * transform.position.y) / 100;

    }

}
