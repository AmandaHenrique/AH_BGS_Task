using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    [SerializeField] Texture2D normalCursor;
    [SerializeField] Texture2D pointer;

    private void Start()
    {
        SetCursor(CursorType.Normal);
    }

    public void SetCursor(CursorType cursorType)
    {
        switch (cursorType)
        {
            case CursorType.Pointer:
                Cursor.SetCursor(pointer, Vector2.zero, CursorMode.ForceSoftware);
                break;
            default:
                Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);
                break;
        }
    }
}
