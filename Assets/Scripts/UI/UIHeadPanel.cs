using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHeadPanel : UIBase
{
    private TMP_Text _txtDate;
    private Image _imgWeekend;
    private TMP_Text _txtTime;
    private Slider _stateProgress;
    private TMP_Text _txtStateProgress;
    private TMP_Text _txtMoney;
    void Awake()
    {
        _txtDate = transform.Find<TMP_Text>("Date");
        _imgWeekend = transform.Find<Image>("Date/Weekend");
        _txtTime = transform.Find<TMP_Text>("Time");
        _stateProgress = transform.Find<Slider>("StateInfo/StateProgress");
        _txtStateProgress = transform.Find<TMP_Text>("StateInfo/StateProgress/Text");
        _txtMoney = transform.Find<TMP_Text>("Money");

        OnRefresh();

        PlayerManager.Instance.MoneyChangeCallback += OnMoneyChange;
        PlayerManager.Instance.StaminaChangeCallback += OnStaminaChange;
    }

    protected override void OnRefresh()
    {
        OnMoneyChange();
        OnStaminaChange();
    }

    void OnDestroy()
    {
        PlayerManager.Instance.MoneyChangeCallback -= OnMoneyChange;
        PlayerManager.Instance.StaminaChangeCallback -= OnStaminaChange;
    }

    private void OnMoneyChange()
    {
        _txtMoney.text = $"所持金     {PlayerManager.Instance.Money}円";
    }

    private void OnStaminaChange()
    {
        _stateProgress.maxValue = PlayerManager.Instance.MaxStamina;
        _stateProgress.value = PlayerManager.Instance.Stamina;
        _txtStateProgress.text = $"{_stateProgress.value}/{_stateProgress.maxValue}";
    }
}
