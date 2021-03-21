using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D cursorArrow;
    public Texture2D radCursorArrow;
    public Texture2D moveCursorArrow;

    void Start()
    {
        ResetCursor();
    }

    public void RadiationButton()
    {
        Cursor.SetCursor(radCursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void Movebutton()
    {
        Cursor.SetCursor(moveCursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void ResetCursor()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
}
