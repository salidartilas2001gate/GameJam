using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DevilHead : MonoBehaviour, IPointerDownHandler
{
    private Image _image;
    private float opacity = 1;
    private float timeLife = 10;

    private void Start()
    {
        _image = this.GetComponent<Image>();
        StartCoroutine(Move(_image));
    }
    private IEnumerator Move(Image image)
    {

        float timeTick = 0.01f;
        float timeLifeMax = timeLife;
        while (true)
        {
            while (timeLife > 0)
            {
                yield return new WaitForSeconds(timeTick);

                timeLife -= timeTick;
                opacity = timeLife / timeLifeMax;
                image.color = new Color(image.color.r,  opacity,  opacity, opacity);
                float scaleImage = 0.01f * (opacity-opacity/1.2f);
                image.gameObject.transform.localScale = new Vector3(image.gameObject.transform.localScale.x - scaleImage, image.gameObject.transform.localScale.y - scaleImage, 1);
            }
            while (timeLife < 10)
            {
                yield return new WaitForSeconds(timeTick);

                timeLife += timeTick;
                opacity = timeLife / timeLifeMax;
                image.color = new Color(image.color.r, opacity, opacity, opacity);
                float scaleImage = 0.01f * (opacity - opacity / 1.2f);
                image.gameObject.transform.localScale = new Vector3(image.gameObject.transform.localScale.x + scaleImage, image.gameObject.transform.localScale.y + scaleImage, 1);
            }
        }
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Global._Complexity = 1;
        SceneManager.LoadScene(1);
    }
}
