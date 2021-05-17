using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadButton : MonoBehaviour
{
    private InputSystem _inputSystem;

    private void Awake()
    {
        _inputSystem = new InputSystem();
    }

    private void Start()
    {
        _inputSystem = new InputSystem();
        _inputSystem.Enable();
        _inputSystem.Player.F.performed += context => PressButton("�");
        _inputSystem.Player.Comma.performed += context => PressButton("�");
        _inputSystem.Player.D.performed += context => PressButton("�");
        _inputSystem.Player.U.performed += context => PressButton("�");
        _inputSystem.Player.L.performed += context => PressButton("�");
        _inputSystem.Player.T.performed += context => PressButton("�");
        _inputSystem.Player.Semicolon.performed += context => PressButton("�");
        _inputSystem.Player.P.performed += context => PressButton("�");
        _inputSystem.Player.B.performed += context => PressButton("�");
        _inputSystem.Player.Q.performed += context => PressButton("�");
        _inputSystem.Player.R.performed += context => PressButton("�");
        _inputSystem.Player.K.performed += context => PressButton("�");
        _inputSystem.Player.V.performed += context => PressButton("�");
        _inputSystem.Player.Y.performed += context => PressButton("�");
        _inputSystem.Player.J.performed += context => PressButton("�");
        _inputSystem.Player.G.performed += context => PressButton("�");
        _inputSystem.Player.H.performed += context => PressButton("�");
        _inputSystem.Player.C.performed += context => PressButton("�");
        _inputSystem.Player.N.performed += context => PressButton("�");
        _inputSystem.Player.E.performed += context => PressButton("�");
        _inputSystem.Player.A.performed += context => PressButton("�");
        _inputSystem.Player.OpeningParenthesis.performed += context => PressButton("�");
        _inputSystem.Player.W.performed += context => PressButton("�");
        _inputSystem.Player.X.performed += context => PressButton("�");
        _inputSystem.Player.I.performed += context => PressButton("�");
        _inputSystem.Player.O.performed += context => PressButton("�");
        _inputSystem.Player.ClosingParenthesis1.performed += context => PressButton("�");
        _inputSystem.Player.S.performed += context => PressButton("�");
        _inputSystem.Player.Quotation.performed += context => PressButton("�");
        _inputSystem.Player.Point.performed += context => PressButton("�");
        _inputSystem.Player.Z.performed += context => PressButton("�");
    }
    
    private void PressButton(string stringer)
    {
        GetComponent<DangerGame>().KeyPress(stringer);
    }
}
