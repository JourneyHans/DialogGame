using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BranchPanel : UIBase
{
    private RectTransform _optionsContent;
    private BranchOptionItem _optionTemplate;

    private readonly List<BranchOptionItem> _optionList = new List<BranchOptionItem>();
    private BranchNode _currentNode = null;

    void Awake()
    {
        _optionsContent = transform.Find<RectTransform>("OptionsContent");
        _optionTemplate = transform.Find<BranchOptionItem>("OptionsContent/OptionTemplate");

        DialogCore.Instance.ContinueToBranchNodeCallback += OnContinueToBranchNode;
    }

    void OnDestroy()
    {
        DialogCore.Instance.ContinueToBranchNodeCallback -= OnContinueToBranchNode;
    }

    private void OnContinueToBranchNode(BranchNode branchNode)
    {
        _currentNode = branchNode;
        int index;
        for (index = 0; index < branchNode.DisplaySelects.Length; index++)
        {
            BranchOptionItem option;
            if (index >= _optionList.Count)
            {
                // need instantiate
                option = Instantiate(_optionTemplate, _optionsContent);
                _optionList.Add(option);
                int tempIndex = index;
                option.SetButtonCallback(() => { OnSelectOptionCall(tempIndex);});
            }
            else
            {
                option = _optionList[index];
                option.gameObject.SetActive(true);
            }
            option.gameObject.name = $"Option_{index}";
            option.SetText(branchNode.DisplaySelects[index]);
        }

        _optionTemplate.gameObject.SetActive(false);

        // Set option(s) invisible when over range.
        for (int i = index; i < _optionList.Count; i++)
        {
            _optionList[i].gameObject.SetActive(false);
        }

        ForceRebuildLayout();
    }

    private void OnSelectOptionCall(int index)
    {
        _currentNode.Select(index);
    }

    private void ForceRebuildLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_optionsContent);
    }
}
