using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public enum TriggerEvent
{
    None,
    Test,
    ChangeBG,
    ChangeBGM,
}

[Serializable]
public class ChatTrigger
{
    public int TriggerCount = -1;
    public TriggerEvent EventType = TriggerEvent.None;
    public Sprite Res;
    public AudioClip BGM;
}

public class ChatNode : DialogBaseNode
{
    public float Interval = 0.1f;
    [TextArea(1, 10)]
    public string Content = string.Empty;

    public ChatTrigger[] Triggers;
}
