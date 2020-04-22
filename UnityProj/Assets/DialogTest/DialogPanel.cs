using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : UIBase
{
    private TMP_Text _sentenceTxt;
    private int _currentIndex = 0;
    private Coroutine _showSentenceCoroutine;

    private Sentence _currentSentence;

    void Awake()
    {
        DialogCore.Instance.Init();
        _sentenceTxt = transform.Find<TMP_Text>("ContentPanel/SentenceTxt");
    }

    void Start()
    {
        ShowSentence();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowSentence();
        }
    }

    private void ShowSentence()
    {
        if (_showSentenceCoroutine != null)
        {
            ResetCoroutine();
            _sentenceTxt.maxVisibleCharacters = _sentenceTxt.textInfo.characterCount;
            if (_currentSentence.TriggerCount != -1)
            {
                _currentSentence.TriggerCallback?.Invoke();
            }
            return;
        }

        _currentSentence = DialogCore.Instance.GetSentenceByIndex(_currentIndex++ % DialogCore.Instance.GetSentenceCount());
        _sentenceTxt.text = _currentSentence.Content;
        _showSentenceCoroutine = StartCoroutine(ShowSentenceCoroutine());
    }

    private IEnumerator ShowSentenceCoroutine()
    {
        _sentenceTxt.ForceMeshUpdate();
        TMP_TextInfo sentenceInfo = _sentenceTxt.textInfo;
        int totalCharacters = sentenceInfo.characterCount;
        int currentVisibleCount = 0;
        while (currentVisibleCount <= totalCharacters)
        {
            _sentenceTxt.maxVisibleCharacters = currentVisibleCount;
            if (currentVisibleCount == _currentSentence.TriggerCount)
            {
                _currentSentence.TriggerCallback?.Invoke();
            }
            currentVisibleCount++;
            yield return new WaitForSeconds(_currentSentence.NormalInterval);
        }

        if (_showSentenceCoroutine != null)
        {
            ResetCoroutine();
        }
    }

    private void ResetCoroutine()
    {
        StopCoroutine(_showSentenceCoroutine);
        _showSentenceCoroutine = null;
    }
}
