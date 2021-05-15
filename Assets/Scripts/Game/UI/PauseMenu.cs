using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _recume;
    [SerializeField] private Button _exitMainMenu;
    [SerializeField] private Button _exitGame;

    private InputSystem _inputSystem;

    private bool _isEnable;

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
        _inputSystem.Player.Pause.performed += contex => Pause();
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Pause()
    {
        if (_isEnable)
        {
        }
        else
        {
            this.gameObject.SetActive(true);
            StartCoroutine(OpenPanel(this.gameObject));
            _isEnable = true;
        }
    }

    private void Recume()
    {

        StartCoroutine(ClosePanel(this.gameObject));
    }

    private void ExitMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator OpenPanel(GameObject gameObject)
    {
        gameObject.transform.DOMoveY(0, 1).From(260);
        yield return new WaitForSeconds(1);
    }

    IEnumerator ClosePanel(GameObject gameObject)
    {
        gameObject.transform.DOMoveY(-260, 1).From(0);
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
        _isEnable = false;

    }
}
