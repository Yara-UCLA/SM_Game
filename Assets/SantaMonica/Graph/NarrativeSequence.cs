using System;
using UnityEngine;
using XNode;

public class NarrativeSequence : MonoBehaviour
{
    public static NarrativeSequence instance;
    public NarrativeGraph narrativeGraph;

    public Canvas currentCanvas;
    public Canvas nextCanvas;
    
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
    }
}
