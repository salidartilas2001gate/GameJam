using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler
{
    public event Action OnTabButton;
    public void OnPointerDown(PointerEventData eventData)
    {
        OnTabButton();
    }
}
