using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIChecker : Singleton<UIChecker>
{
    public bool IsOverUI() {
        if (Input.touchSupported)
        {
            if (Input.touchCount > 0)
                return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
        }
        else
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
        return false;
    }
}
