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

        UIManager.Instance.Show<LoadingPanel>(UIManager.OpenType.Add, UIManager.SortOrderLayer.Zero);
        Messenger<float>.Invoke("UpdateResource", 1.0f);
    }

    public void EnterHomeScene()
    {

    }

    public void EnterUITestScene()
    {
        UIManager.Instance.Show<HomePanel>();
    }
}
