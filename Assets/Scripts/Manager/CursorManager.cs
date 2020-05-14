using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : SingletonUnity<CursorManager>
{
    private string _cursorRootPath = "Art/Cursor/";
    private readonly Dictionary<string, Texture2D> _nameToTextureDic = new Dictionary<string, Texture2D>();
    private string _cursorName = "";

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        Cursor.visible = true;
        SetCursor("normal");
    }

    void Update()
    {
        
    }

    public void SetCursor(string fileName)
    {
        if (_cursorName == fileName)
        {
            // lazy return;
            return;
        }
        _cursorName = fileName;
        if (!_nameToTextureDic.TryGetValue(fileName, out Texture2D texture))
        {
            texture = SimpleLoader.Load<Texture2D>(_cursorRootPath + fileName);
            _nameToTextureDic[fileName] = texture;
        }

        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
    }
}
