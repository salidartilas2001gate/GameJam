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
        _inputSystem.Player.F.performed += context => PressButton("À");
        _inputSystem.Player.Comma.performed += context => PressButton("Á");
        _inputSystem.Player.D.performed += context => PressButton("Â");
        _inputSystem.Player.U.performed += context => PressButton("Ã");
        _inputSystem.Player.L.performed += context => PressButton("Ä");
        _inputSystem.Player.T.performed += context => PressButton("Å");
        _inputSystem.Player.Semicolon.performed += context => PressButton("Æ");
        _inputSystem.Player.P.performed += context => PressButton("Ç");
        _inputSystem.Player.B.performed += context => PressButton("È");
        _inputSystem.Player.Q.performed += context => PressButton("É");
        _inputSystem.Player.R.performed += context => PressButton("Ê");
        _inputSystem.Player.K.performed += context => PressButton("Ë");
        _inputSystem.Player.V.performed += context => PressButton("Ì");
        _inputSystem.Player.Y.performed += context => PressButton("Í");
        _inputSystem.Player.J.performed += context => PressButton("Î");
        _inputSystem.Player.G.performed += context => PressButton("Ï");
        _inputSystem.Player.H.performed += context => PressButton("Ð");
        _inputSystem.Player.C.performed += context => PressButton("Ñ");
        _inputSystem.Player.N.performed += context => PressButton("Ò");
        _inputSystem.Player.E.performed += context => PressButton("Ó");
        _inputSystem.Player.A.performed += context => PressButton("Ô");
        _inputSystem.Player.OpeningParenthesis.performed += context => PressButton("Õ");
        _inputSystem.Player.W.performed += context => PressButton("Ö");
        _inputSystem.Player.X.performed += context => PressButton("×");
        _inputSystem.Player.I.performed += context => PressButton("Ø");
        _inputSystem.Player.O.performed += context => PressButton("Ù");
        _inputSystem.Player.ClosingParenthesis1.performed += context => PressButton("Ú");
        _inputSystem.Player.S.performed += context => PressButton("Û");
        _inputSystem.Player.Quotation.performed += context => PressButton("Ý");
        _inputSystem.Player.Point.performed += context => PressButton("Þ");
        _inputSystem.Player.Z.performed += context => PressButton("ß");
    }
    
    private void PressButton(string stringer)
    {
        GetComponent<DangerGame>().KeyPress(stringer);
    }
}
