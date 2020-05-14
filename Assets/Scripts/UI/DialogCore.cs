using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogCore : Singleton<DialogCore>
{
    public DialogNodeGraph CurrentGraph = null;
    public SpriteRenderer BGSpriteRenderer = null;
    public BranchPanel BranchPanel = null;

    public Action<ChatNode> ContinueToChatNodeCallback = null;
    public Action<BranchNode> ContinueToBranchNodeCallback = null;

    public void Init()
    {
        CurrentGraph = SimpleLoader.Load<DialogNodeGraph>("Data/DialogGraph");
        CurrentGraph.Current = CurrentGraph.nodes[0] as DialogBaseNode;
    }

    public void HandleEvent(ChatTrigger trigger)
    {
        TriggerEvent eventType = trigger.EventType;
        if (eventType == TriggerEvent.None)
        {
            return;
        }

        switch (eventType)
        {
            case TriggerEvent.Test:
                Debug.Log("触发一个事件");
                break;
            case TriggerEvent.ChangeBG:
                HandleChangeBGEvent(trigger);
                break;
            case TriggerEvent.ChangeBGM:
                HandleChangeBGMEvent(trigger);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null);
        }
    }

    public void Continue()
    {
        CurrentGraph.Current.MoveNext();

        switch (CurrentGraph.Current)
        {
            case ChatNode chatNode:
                ContinueToChatNodeCallback?.Invoke(chatNode);
                break;
            case BranchNode brachNode:
                if (BranchPanel == null)
                {
                    BranchPanel = UIManager.Instance.Show<BranchPanel>();
                }
                ContinueToBranchNodeCallback?.Invoke(brachNode);
                break;
        }
    }

    private void HandleChangeBGEvent(ChatTrigger trigger)
    {
        BGSpriteRenderer.sprite = trigger.Res;
    }

    private void HandleChangeBGMEvent(ChatTrigger trigger)
    {
        AudioManager.Instance.SetBGM(trigger.BGM);
    }
}
