using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _recume;
    [SerializeField] private Button _exitMainMenu;
    [SerializeField] private Button _exitGame;

    private InputSystem _inputSystem;

    private void Awake()
    {
        _recume.OnTabButton += Recume;
        _exitMainMenu.OnTabButton += ExitMainMenu;
        _exitGame.OnTabButton += ExitGame;

        _inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
        _inputSystem.Player.Pause.started += contex => Pause();
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Pause()
    {
        this.gameObject.SetActive(true);

        StartCoroutine(OpenPanel(this.gameObject));
    }

    private void Recume()
    {

        StartCoroutine(ClosePanel(this.gameObject));
    }

    private void ExitMainMenu()
    {

    }

    private void ExitGame()
    {

    }

    IEnumerator OpenPanel(GameObject gameObject)
    {
        gameObject.transform.DOMoveY(185.5f, 1).From(1000);
        yield return new WaitForSeconds(1);
    }

    IEnumerator ClosePanel(GameObject gameObject)
    {
        gameObject.transform.DOMoveY(-1000, 1).From(181);
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}
