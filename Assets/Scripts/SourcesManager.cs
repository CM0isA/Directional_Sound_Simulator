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
    public static SourcesManager instance;
    public int activeId=0;

    private void Awake()
    {
        audioSources.Clear();
        sourcesNumber = 0;
        instance = this;
    }

    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            activeId = 1;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            activeId = 2;
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            activeId = 3;
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            activeId = 4;
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            activeId = 5;
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {

                sourcesNumber++;

        }
        if(Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            sourcesNumber--;
        }


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
        GameObject newSource = Instantiate(sourcePrefab);
        audioSources.Add(newSource);
    }

    public void DeleteAudioSource(GameObject audioSource)
    {
        audioSources.Remove(audioSource);
        Destroy(audioSource);

    }
}
