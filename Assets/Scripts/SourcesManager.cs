using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourcesManager : MonoBehaviour
{

    #region Singleton
    [Range(0,5)]
    [SerializeField]
    private int sourcesNumber = 0;
    public List<GameObject> audioSources;
    [SerializeField]
    private GameObject sourcePrefab;

    private void Awake()
    {
        audioSources.Clear();
        sourcesNumber = 0;
    }

    #endregion

    private void Update()
    {
        //if(Input.GetKeyDown("+"))
        //{
        //    sourcesNumber++;
        //}
        //if(Input.GetKeyDown("-"))
        //{
        //    sourcesNumber--;
        //}


        if (audioSources.Count == sourcesNumber)
            return;

        if(audioSources.Count < sourcesNumber)
        {
            AddAudioSource(audioSources.Count + 1);
        }

        if(audioSources.Count> sourcesNumber)
        {
            DeleteAudioSource(audioSources[audioSources.Count - 1]);
        }
    }

    public void AddAudioSource(int index)
    {
        AudioSource audioSource = sourcePrefab.GetComponent<AudioSource>();
        audioSource.id = index;
        audioSources.Add(sourcePrefab);
        Instantiate(sourcePrefab);
    }

    public void DeleteAudioSource(GameObject audioSource)
    {
        audioSources.Remove(audioSource);
        Destroy(audioSource);
    }
}
