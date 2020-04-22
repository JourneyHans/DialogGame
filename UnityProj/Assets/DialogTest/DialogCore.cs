using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCore : Singleton<DialogCore>
{
    private List<Sentence> _sentenceList = new List<Sentence>();
    public void Init()
    {
        _sentenceList = new List<Sentence>
        {
            new Sentence {Content = "这是第一句话，没有什么特别的，点击显示下一句。"},
            new Sentence
            {
                Content = "这是第二句话，X会触发一个事件",
                NormalInterval = 0.5f,
                TriggerCount = 8,
                TriggerCallback = () => { Debug.Log("X"); }
            },
            new Sentence {Content = "This is 3rd sentence..."},
            new Sentence {Content = "This is 4th sentence..."},
            new Sentence {Content = "This is 5th sentence..."},
            new Sentence {Content = "This is 6th sentence..."},
        };
    }

    public Sentence GetSentenceByIndex(int index)
    {
        return _sentenceList[index];
    }

    public int GetSentenceCount()
    {
        return _sentenceList.Count;
    }
}
