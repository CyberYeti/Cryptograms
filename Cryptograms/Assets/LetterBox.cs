using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LetterBox : MonoBehaviour
{
    [SerializeField] bool isSelected = false;
    [SerializeField] Color unselectedColor;
    [SerializeField] Color selectedColor;

    [Header("Internal Components")]
    [SerializeField] TextMeshProUGUI letterTextArea;
    [SerializeField] TextMeshProUGUI inputTextArea;
    [SerializeField] Image inputAreaPanel;

    private void Start()
    {
        inputTextArea.text = "";
    }

    void Update()
    {
        if (isSelected)
        {
            inputAreaPanel.color = selectedColor;
        }
        else
        {
            inputAreaPanel.color = unselectedColor;
        }
    }

    void SetLetter(string _letter)
    {
        letterTextArea.text = _letter;
    }

    void DetectInput()
    {
        //Arrow Key Input
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            print("PrevBox");
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            print("NextBox");
            return;
        }

        //Letter Input
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetLetter("A");
            return;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SetLetter("B");
            return;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SetLetter("C");
            return;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SetLetter("D");
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetLetter("E");
            return;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SetLetter("F");
            return;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SetLetter("G");
            return;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            SetLetter("H");
            return;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetLetter("I");
            return;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            SetLetter("J");
            return;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetLetter("K");
            return;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SetLetter("L");
            return;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetLetter("M");
            return;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SetLetter("N");
            return;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SetLetter("O");
            return;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetLetter("P");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetLetter("Q");
            return;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetLetter("R");
            return;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetLetter("S");
            return;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetLetter("T");
            return;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            SetLetter("U");
            return;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SetLetter("V");
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetLetter("W");
            return;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SetLetter("X");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SetLetter("Y");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SetLetter("Z");
            return;
        }
    }
}
