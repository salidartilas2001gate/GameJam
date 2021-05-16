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
        _inputSystem.Player.F.performed += context => SSS("À");
        _inputSystem.Player.Comma.performed += context => SSS("Á");
        _inputSystem.Player.D.performed += context => SSS("Â");
        _inputSystem.Player.U.performed += context => SSS("Ã");
        _inputSystem.Player.L.performed += context => SSS("Ä");
        _inputSystem.Player.T.performed += context => SSS("Å");
        _inputSystem.Player.Semicolon.performed += context => SSS("Æ");
        _inputSystem.Player.P.performed += context => SSS("Ç");
        _inputSystem.Player.B.performed += context => SSS("È");
        _inputSystem.Player.Q.performed += context => SSS("É");
        _inputSystem.Player.R.performed += context => SSS("Ê");
        _inputSystem.Player.K.performed += context => SSS("Ë");
        _inputSystem.Player.V.performed += context => SSS("Ì");
        _inputSystem.Player.Y.performed += context => SSS("Í");
        _inputSystem.Player.J.performed += context => SSS("Î");
        _inputSystem.Player.G.performed += context => SSS("Ï");
        _inputSystem.Player.H.performed += context => SSS("Ð");
        _inputSystem.Player.C.performed += context => SSS("Ñ");
        _inputSystem.Player.N.performed += context => SSS("Ò");
        _inputSystem.Player.E.performed += context => SSS("Ó");
        _inputSystem.Player.A.performed += context => SSS("Ô");
        _inputSystem.Player.OpeningParenthesis.performed += context => SSS("Õ");
        _inputSystem.Player.W.performed += context => SSS("Ö");
        _inputSystem.Player.X.performed += context => SSS("×");
        _inputSystem.Player.I.performed += context => SSS("Ø");
        _inputSystem.Player.O.performed += context => SSS("Ù");
        _inputSystem.Player.ClosingParenthesis1.performed += context => SSS("Ú");
        _inputSystem.Player.S.performed += context => SSS("Û");
        _inputSystem.Player.Quotation.performed += context => SSS("Ý");
        _inputSystem.Player.Point.performed += context => SSS("Þ");
        _inputSystem.Player.Z.performed += context => SSS("ß");
    }
    
    private void SSS(string stringer)
    {
        GetComponent<DangerGame>().KeyPress(stringer);
    }
}
