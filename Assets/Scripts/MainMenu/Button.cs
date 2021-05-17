using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public event Action OnTabButton;
    public event Action PlayAudioClick;

    
    public void OnPointerDown(PointerEventData eventData)
    {
        OnTabButton();
        PlayAudioClick();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(SetScale(0.9f, 0.9f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(SetScale(1, 1));
    }
    IEnumerator SetScale(float x, float y)
    {
        this.gameObject.transform.DOScaleX(x, 0.5f);
        this.gameObject.transform.DOScaleY(y, 0.5f);
        yield return new WaitForSeconds(0.5f);
    }
}
