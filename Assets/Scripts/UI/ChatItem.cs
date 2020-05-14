using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatItem : MonoBehaviour
{
    private TMP_Text _displayTxt;
    private Coroutine _displayCoroutine;

    public ChatNode ChatNode { set; get; }

    void Awake()
    {
        _displayTxt = GetComponent<TMP_Text>();
    }

    public bool IsFinished()
    {
        return _displayCoroutine == null;
    }

    public void DisplayNormally()
    {
        _displayTxt.text = ChatNode.Content;
        _displayCoroutine = StartCoroutine(DisplayCoroutine());
    }

    private IEnumerator DisplayCoroutine()
    {
        _displayTxt.ForceMeshUpdate();
        TMP_TextInfo txtInfo = _displayTxt.textInfo;
        int totalCharacters = txtInfo.characterCount;
        int currentVisibleCount = 0;
        while (currentVisibleCount <= totalCharacters)
        {
            _displayTxt.maxVisibleCharacters = currentVisibleCount;
//            if (currentVisibleCount == ChatNode.Trigger.TriggerCount)
//            {
//                DialogCore.Instance.HandleEvent(ChatNode.Trigger.EventType);
//            }
            foreach (ChatTrigger chatTrigger in ChatNode.Triggers)
            {
                if (currentVisibleCount == chatTrigger.TriggerCount)
                {
                    DialogCore.Instance.HandleEvent(chatTrigger);
                }
            }

            currentVisibleCount++;
            yield return new WaitForSeconds(ChatNode.Interval);
        }

        if (_displayCoroutine != null)
        {
            ResetCoroutine();
        }
    }

    public void DisplayImmediately()
    {
        ResetCoroutine();
        _displayTxt.maxVisibleCharacters = _displayTxt.textInfo.characterCount;

        foreach (ChatTrigger chatTrigger in ChatNode.Triggers)
        {
            if (chatTrigger.TriggerCount != -1)
            {
                DialogCore.Instance.HandleEvent(chatTrigger);
            }
        }
//        if (ChatNode.Trigger.TriggerCount != -1)
//        {
//            DialogCore.Instance.HandleEvent(ChatNode.Trigger.EventType);
//        }
    }

    private void ResetCoroutine()
    {
        StopCoroutine(_displayCoroutine);
        _displayCoroutine = null;
    }
}
