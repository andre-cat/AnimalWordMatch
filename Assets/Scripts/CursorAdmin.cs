using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAdmin : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
    }
}
