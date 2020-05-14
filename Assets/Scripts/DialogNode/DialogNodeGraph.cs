using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateAssetMenu(fileName = "DialogGraph", menuName = "xNode/DialogGraph")]
public class DialogNodeGraph : NodeGraph
{
    public DialogBaseNode Current;

    // public void Continue()
    // {
    //     Current.MoveNext();
    // }
}
