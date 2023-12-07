using System;
using UnityEngine;
using UnityEngine.Video;
using XNode;

public class NarrativeSequence : MonoBehaviour
{
    public static NarrativeSequence instance;
    public NarrativeGraph narrativeGraph;

    public Canvas currentCanvas;
    public Canvas nextCanvas;
    [SerializeField] private VideoPlayer BGVideo;
    
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }
    
    public void Start()
    {
        narrativeGraph.Start();
    }

    public void GetCurrentCanvas(string currentCanvasName)
    {
        currentCanvas = GameObject.Find(currentCanvasName).GetComponent<Canvas>();
    }
    public void LoadNextCanvas( string nextCanvasName)
    {
        nextCanvas = GameObject.Find(nextCanvasName).GetComponent<Canvas>();

        currentCanvas.enabled = false;
        nextCanvas.enabled = true;
    }

    public void GraphContinue(int index)
    {
        narrativeGraph.Continue(index);
        var currentVideoPlayer = currentCanvas.GetComponentInChildren<VideoPlayer>();
        if(currentVideoPlayer == null || currentVideoPlayer.clip == null)
        {
            BGVideo.Pause();
        }
        else
        {
            currentVideoPlayer.Stop();
        }

        var nextVideoPlayer = nextCanvas.GetComponentInChildren<VideoPlayer>();
        if (nextVideoPlayer == null || nextVideoPlayer.clip == null)
        {
            BGVideo.Play();
        }
        else
        {
            nextVideoPlayer.Play();
        }
    }
}
