using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Component at "Resources/Prefabs/UI/BranchPanel.prefab/OpetionsContent/OptionTemplate"
public class BranchOptionItem : MonoBehaviour
{
    private Button _selectBtn;
    private TMP_Text _optionTxt;

    void Awake()
    {
        _optionTxt = transform.Find<TMP_Text>("Text");
        _selectBtn = GetComponent<Button>();
    }

    public void SetText(string text)
    {
        if (_optionTxt.text != text)
        {
            _optionTxt.text = text;
        }

        ForceRebuildLayout();
    }

    private void ForceRebuildLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    public  void SetButtonCallback(UnityAction callback)
    {
        _selectBtn.onClick.AddListener(callback);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
