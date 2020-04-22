using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentence
{
    public string Content = string.Empty;
    public float NormalInterval = 0.1f;
    public int TriggerCount = -1;
    public Action TriggerCallback = null;
}
