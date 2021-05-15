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
        _isEnable = false;
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
        gameObject.transform.DOMoveY(500f, 1).From(1000);
        yield return new WaitForSeconds(1);
    }

    IEnumerator ClosePanel(GameObject gameObject)
    {
        gameObject.transform.DOMoveY(-1000, 1).From(500);
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}
