using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : UIBase
{
    private Button _btnStart;
    void Awake()
    {
        _btnStart = transform.Find<Button>("ScrollView/Viewport/Content/StartBtn");
        _btnStart.onClick.AddListener(OnStartButtonCall);
    }

    private void OnStartButtonCall()
    {
        SceneMgr.Instance.LoadScene("Dialog", () =>
        {
            UIManager.Instance.Show<DialogPanel>();
            // UIManager.Instance.Show<UIHeadPanel>().gameObject.SetActive(false);
            // 设置BG
            DialogCore.Instance.BGSpriteRenderer = GameObject.Find("BG").GetComponent<SpriteRenderer>();
            // DialogCore.Instance.BGSpriteRenderer.gameObject.SetActive(false);

            AudioManager.Instance.SetBGM("bgm_1");

            Close();
        });
    }
}
