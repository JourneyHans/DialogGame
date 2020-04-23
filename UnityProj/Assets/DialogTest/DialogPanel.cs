using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : UIBase
{
    private int _currentIndex = 0;

    private SentenceItem _sentenceItem;

    void Awake()
    {
        DialogCore.Instance.Init();
        _sentenceItem = transform.Find<SentenceItem>("ContentPanel/SentenceTxt");
    }

    void Start()
    {
        DisplaySentence();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DisplaySentence();
        }
    }

    private void DisplaySentence()
    {
        if (!_sentenceItem.IsFinished())
        {
            _sentenceItem.DisplayImmediately();
            return;
        }

        _sentenceItem.Sentence = DialogCore.Instance.GetSentenceByIndex(_currentIndex++ % DialogCore.Instance.GetSentenceCount());
        _sentenceItem.DisplayNormally();
    }
}
