using System;
using UnityEngine;
using UnityEngine.Serialization;
using XNode;

public class NextCanvasNode : Node
{
	[SerializeField]
	private string canvasName;
	[Input(backingValue = ShowBackingValue.Never)]
	public Empty choice;
	[Output(dynamicPortList = true)]
	public Empty[] choices;
	
	public void MoveNext(int index) {
		
		NarrativeSequence.instance.GetCurrentCanvas(canvasName);
		NodePort port = GetPort($"choices {index}");
		var node = port.Connection.node as NextCanvasNode;
		if (node != null) node.OnEnter();
	}

	private void OnEnter() {
		
		NarrativeGraph narrativeGraph = graph as NarrativeGraph;
		narrativeGraph.current = this;
		NarrativeSequence.instance.LoadNextCanvas(canvasName);
		
	}
	
	[Serializable]
	public class Empty { }
}