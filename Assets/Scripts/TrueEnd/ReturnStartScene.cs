using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnStartScene : MonoBehaviour
{
    [SerializeField] private Button button;
    private void Awake()
    {
        button.OnTabButton += ExitMainMenu;
    }

    private void ExitMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
