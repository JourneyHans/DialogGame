using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

/// <summary>
/// 对话系统基础父节点，抽象类确保不会显示在对话图中
/// </summary>
public abstract class DialogBaseNode : Node
{
    [Input] public EmptyPort Input;
    [Output] public EmptyPort Output;

    protected override void Init()
    {
        base.Init();
    }

    public virtual void MoveNext()
    {
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

        DialogBaseNode nextNode = outputPort.Connection.node as DialogBaseNode;
        nextNode.OnEnter();
    }

    public void OnEnter()
    {
        DialogNodeGraph dialogNodeGraph = graph as DialogNodeGraph;
        dialogNodeGraph.Current = this;
    }

    [Serializable]
    public class EmptyPort { }
}