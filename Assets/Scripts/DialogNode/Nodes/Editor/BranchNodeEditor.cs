using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using XNodeEditor;

[CustomNodeEditor(typeof(BranchNode))]
public class BranchNodeEditor : NodeEditor
{
    public override Color GetTint()
    {
        return new Color32(152, 77, 30, 255);
    }
}