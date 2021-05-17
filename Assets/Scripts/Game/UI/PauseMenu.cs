using DG.Tweening;
using System;
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

    public event Action PauseAudio;
    public event Action PlayAudio;

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
    private void OnDestroy()
    {
        _inputSystem.Disable();
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
            //StartCoroutine(OpenPanel(this.gameObject));
            _isEnable = true;
            PauseAudio();
            Time.timeScale = 0;
        }
    }

    private void Recume()
    {

        //sStartCoroutine(ClosePanel(this.gameObject));

        PlayAudio();
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        _isEnable = false;

    }

    private void ExitMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void ExitGame()
    {
        Time.timeScale = 1;
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
