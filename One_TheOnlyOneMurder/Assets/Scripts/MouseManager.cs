using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    RaycastHit hitInfo;

    public Texture2D eye, ear;


    private void Update()
    {
        SetCursorTexture(); 

    }


    void SetCursorTexture()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))//out是返回值 为 hitInfo
        {
            //切换鼠标贴图
            switch (hitInfo.collider.gameObject.tag)
            {
                case "See":
                    Cursor.SetCursor(eye, new Vector2(20, 20), CursorMode.Auto);//new Vecor2是指cursor的偏移（原来的点是左上角
                    break;

                case "Hear":
                    Cursor.SetCursor(ear, new Vector2(20, 20), CursorMode.Auto);

                    break;

                
            }
        }

    }


}
