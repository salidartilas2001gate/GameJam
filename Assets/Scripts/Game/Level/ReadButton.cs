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

    private void OnEnable()
    {
        _inputSystem.Enable();
        _inputSystem.Player.F.performed += context => SSS("�");
        _inputSystem.Player.Comma.performed += context => SSS("�");
        _inputSystem.Player.D.performed += context => SSS("�");
        _inputSystem.Player.U.performed += context => SSS("�");
        _inputSystem.Player.L.performed += context => SSS("�");
        _inputSystem.Player.T.performed += context => SSS("�");
        _inputSystem.Player.Semicolon.performed += context => SSS("�");
        _inputSystem.Player.P.performed += context => SSS("�");
        _inputSystem.Player.B.performed += context => SSS("�");
        _inputSystem.Player.Q.performed += context => SSS("�");
        _inputSystem.Player.R.performed += context => SSS("�");
        _inputSystem.Player.K.performed += context => SSS("�");
        _inputSystem.Player.V.performed += context => SSS("�");
        _inputSystem.Player.Y.performed += context => SSS("�");
        _inputSystem.Player.J.performed += context => SSS("�");
        _inputSystem.Player.G.performed += context => SSS("�");
        _inputSystem.Player.H.performed += context => SSS("�");
        _inputSystem.Player.C.performed += context => SSS("�");
        _inputSystem.Player.N.performed += context => SSS("�");
        _inputSystem.Player.E.performed += context => SSS("�");
        _inputSystem.Player.A.performed += context => SSS("�");
        _inputSystem.Player.OpeningParenthesis.performed += context => SSS("�");
        _inputSystem.Player.W.performed += context => SSS("�");
        _inputSystem.Player.X.performed += context => SSS("�");
        _inputSystem.Player.I.performed += context => SSS("�");
        _inputSystem.Player.O.performed += context => SSS("�");
        _inputSystem.Player.ClosingParenthesis1.performed += context => SSS("�");
        _inputSystem.Player.S.performed += context => SSS("�");
        _inputSystem.Player.Quotation.performed += context => SSS("�");
        _inputSystem.Player.Point.performed += context => SSS("�");
        _inputSystem.Player.Z.performed += context => SSS("�");
    }
    
    private void SSS(string stringer)
    {
        GetComponent<DangerGame>().KeyPress(stringer);
    }
}
