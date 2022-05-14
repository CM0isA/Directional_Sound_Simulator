using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SourcesManager : MonoBehaviour
{

    #region Singleton
    [Range(0, 5)]
    [SerializeField]
    private int sourcesNumber = 0;
    public List<GameObject> audioSources;
    [SerializeField]
    private GameObject sourcePrefab;
    public static SourcesManager instance;
    public int activeId = 0;
    public List<GameObject> panels;

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
            if (sourcesNumber < 5) sourcesNumber++;

        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            if (sourcesNumber > 0) sourcesNumber--;
        }


        if (audioSources.Count == sourcesNumber)
            return;

        if (audioSources.Count < sourcesNumber)
        {
            AddAudioSource(audioSources.Count + 1);
            activeId = sourcesNumber;
            panels[sourcesNumber - 1].SetActive(true);
        }

        if (audioSources.Count > sourcesNumber)
        {
            panels[audioSources.Count - 1].SetActive(false);
            DeleteAudioSource(audioSources[audioSources.Count - 1]);
            activeId = sourcesNumber;

        }
    }


    private void LateUpdate()
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            Text text = panels[i].GetComponentInChildren<Text>();
            AudioSource source = audioSources[i].GetComponent<AudioSource>();


            text.text = "ID: " + source.id + " \nAzimuth: " + source.azimuth + " \nElevation: " + source.elevation;
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
