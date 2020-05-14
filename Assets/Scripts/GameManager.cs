using System;
using UnityEngine;

public class GameManager : SingletonUnity<GameManager>
{
    void Start()
    {
        Init();
    }

    // 初始化
    private void Init()
    {
        UIManager.Instance.Init();          // UI管理器初始化
        DontDestroyOnLoad(gameObject);      // 永不销毁

        PlayerManager.Instance.Init();

        // AudioManager
        SimpleLoader.InstantiateGameObject("Prefabs/Manager/AudioManager");
        AudioManager.Instance.BGMEnable = true;

        // CursorManager
        SimpleLoader.InstantiateGameObject("Prefabs/Manager/CursorManager");

        UIManager.Instance.Show<MainMenuPanel>();
    }
}
