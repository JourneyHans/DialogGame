using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BranchNode : DialogBaseNode
{
    [TextArea(1, 10)]
    public string[] DisplaySelects;

    private int _selectIndex = -1;

    public void Select(int index)
    {
        _selectIndex = index;
        DialogCore.Instance.Continue();
    }

    public override void MoveNext()
    {
        // Debug.Log($"Select: {_selectIndex}");
        DialogNodeGraph dialogNodeGraph = graph as DialogNodeGraph;
        if (dialogNodeGraph.Current != this)
        {
            Debug.LogError("Node isn't active");
            return;
        }

        NodePort outputPort = GetOutputPort("Output");
        if (!outputPort.IsConnected)
        {
            Debug.LogError("This is last node");
            return;
        }

        // Debug.Log($"output connection count: {outputPort.ConnectionCount}");
        DialogBaseNode selectedNode = outputPort.GetConnection(_selectIndex).node as DialogBaseNode;
        selectedNode.OnEnter();
    }
}
