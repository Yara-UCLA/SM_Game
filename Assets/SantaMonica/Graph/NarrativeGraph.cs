using UnityEngine;
using XNode;

[CreateAssetMenu]
public class NarrativeGraph : NodeGraph
{
	public NextCanvasNode start;
	public NextCanvasNode current;
	
	public void Start()
	{
		current = start;
	}
	public void Continue(int index) {
		current.MoveNext(index);
	}
	
}