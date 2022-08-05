using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsPanel : MonoBehaviour
{
    //Variables
    [SerializeField] TextMeshProUGUI cipherTypeUI;
    [SerializeField] TextMeshProUGUI AnswerCorrectnessUI;
    [SerializeField] TextMeshProUGUI numCorrectWrongUI;

    bool isCorrect = true;
    int numCorrect = 0;
    int numWrong = 0;

    //Attributes
    public string CipherType
    {
        set
        {
            cipherTypeUI.text = $"Cipher: {value}";
        }
    }
    public bool IsCorrect
    {
        get { return isCorrect; }
        set
        {
            isCorrect = value;
            if (isCorrect)
            {
                AnswerCorrectnessUI.text = "Your Answer Is Correct!";
            }
            else
            {
                AnswerCorrectnessUI.text = "Your Answer Is Wrong!";
            }
            
        }
    }
    public int NumCorrect
    {
        set
        {
            numCorrect = value;
            numCorrectWrongUI.text = $"Correct Letters: {numCorrect}     Wrong Letters: {numWrong}";
        }
    }
    public int NumWrong
    {
        set
        {
            numWrong = value;
            numCorrectWrongUI.text = $"Correct Letters: {numCorrect}     Wrong Letters: {numWrong}";
        }
    }

    //Unity Methods
}
