using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XNode;

public class DialogPanel : UIBase
{
    private ChatItem _chatItem;

    void Awake()
    {
        _chatItem = transform.Find<ChatItem>("ContentPanel/ChatItem");
        transform.Find<SimpleClick>("ClickMask").ClickCallback = OnClickMaskCall;

        DialogCore.Instance.Init();
        DialogCore.Instance.ContinueToChatNodeCallback += OnContinueToChatNode;
    }

    void OnDestroy()
    {
        DialogCore.Instance.ContinueToChatNodeCallback -= OnContinueToChatNode;
    }

    void Start()
    {
        // 初始化
        _chatItem.ChatNode = DialogCore.Instance.CurrentGraph.Current as ChatNode;
        _chatItem.DisplayNormally();
    }

    private void OnClickMaskCall()
    {
        if (_chatItem.IsFinished())
        {
            DialogCore.Instance.Continue();
        }
        else
        {
            _chatItem.DisplayImmediately();
        }
    }

    private void OnContinueToChatNode(ChatNode chatNode)
    {
        _chatItem.ChatNode = chatNode;
        _chatItem.DisplayNormally();
    }
}
