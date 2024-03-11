using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorImage;

    void Start()
    {
        Vector2 centerPoint = new Vector2(cursorImage.width / 2, cursorImage.height / 2);
        Cursor.SetCursor(cursorImage, centerPoint, CursorMode.Auto);
    }

    void Update()
    {
        
    }
}
