using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SentenceItem : MonoBehaviour
{
    private TMP_Text _sentenceTxt;
    private Coroutine _displayCoroutine;

    public Sentence Sentence { set; get; }

    void Awake()
    {
        _sentenceTxt = GetComponent<TMP_Text>();
    }

    public bool IsFinished()
    {
        return _displayCoroutine == null;
    }

    public void DisplayNormally()
    {
        _sentenceTxt.text = Sentence.Content;
        _displayCoroutine = StartCoroutine(DisplayCoroutine());
    }

    private IEnumerator DisplayCoroutine()
    {
        _sentenceTxt.ForceMeshUpdate();
        TMP_TextInfo sentenceInfo = _sentenceTxt.textInfo;
        int totalCharacters = sentenceInfo.characterCount;
        int currentVisibleCount = 0;
        while (currentVisibleCount <= totalCharacters)
        {
            _sentenceTxt.maxVisibleCharacters = currentVisibleCount;
            if (currentVisibleCount == Sentence.TriggerCount)
            {
                Sentence.TriggerCallback?.Invoke();
            }
            currentVisibleCount++;
            yield return new WaitForSeconds(Sentence.NormalInterval);
        }

        if (_displayCoroutine != null)
        {
            ResetCoroutine();
        }
    }

    public void DisplayImmediately()
    {
        ResetCoroutine();
        _sentenceTxt.maxVisibleCharacters = _sentenceTxt.textInfo.characterCount;
        if (Sentence.TriggerCount != -1)
        {
            Sentence.TriggerCallback?.Invoke();
        }
    }

    private void ResetCoroutine()
    {
        StopCoroutine(_displayCoroutine);
        _displayCoroutine = null;
    }
}
