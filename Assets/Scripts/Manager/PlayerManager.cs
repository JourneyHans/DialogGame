using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public Action MoneyChangeCallback;
    public Action StaminaChangeCallback;

    private int _money;
    public int Money
    {
        set
        {
            _money = value;
            MoneyChangeCallback?.Invoke();
        }
        get => _money;
    }

    private int _stamina;
    public int Stamina
    {
        set
        {
            _stamina = value;
            if (_stamina >= MaxStamina)
            {
                _stamina = MaxStamina;
            }
            StaminaChangeCallback?.Invoke();

        }
        get => _stamina;
    }
    public int MaxStamina { set; get; }

    public void Init()
    {
        Money = 4000;
        MaxStamina = 80;
        Stamina = 80;
    }
}
