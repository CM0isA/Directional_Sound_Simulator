using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceMovement : MonoBehaviour
{
    int sourceId;
    public GameObject head;
    Transform source;
    SourcesManager sources;
    float distance;
    
    void Start()
    {
        sources = SourcesManager.instance;

    }

    // Update is called once per frame
    void Update()
    {
        if (sources.activeId != 0)
        {
            source = sources.audioSources[sources.activeId-1].transform;
            distance = (source.position - head.transform.position).magnitude;

            if (Input.GetKey(KeyCode.D))
            {
                source.RotateAround(head.transform.position, Vector3.up, 50 * Time.deltaTime);
                source.localRotation = new Quaternion(0, 0, 0, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                source.RotateAround(head.transform.position, Vector3.up, -50 * Time.deltaTime);
                source.localRotation = new Quaternion(0, 0, 0, 0);
            }

            if (Input.GetKey(KeyCode.W))
            {
                source.RotateAround(head.transform.position, Vector3.forward, 50 * Time.deltaTime);
                source.localRotation = new Quaternion(0, 0, 0, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                source.RotateAround(head.transform.position, Vector3.forward, -50 * Time.deltaTime);
                source.localRotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }
}
