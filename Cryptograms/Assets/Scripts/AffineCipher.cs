using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class AffineCipher : MonoBehaviour
{
    #region Variables
    [SerializeField] TextMeshProUGUI instructionsText;
    [SerializeField] TextBlock textBlock;
    [SerializeField] ResultsPanel resultsPanel;

    int keyA;
    int keyB;
    string key;
    string plainText;
    string cipherText;
    string answerText;
    bool isEncrypted = false; //If true, result should be the plaintext

    int numCorrect = 0;
    int numWrong = 0;

    char[] a0z25 = A0Z25.a0z25Table;
    int[] AValues =
    {
        1,
        3,
        5,
        7,
        9,
        11,
        15,
        17,
        19,
        21,
        23,
        25
    };
    int[] AValuesInverted =
    {
        1,
        9,
        21,
        15,
        3,
        19,
        7,
        23,
        11,
        5,
        17,
        25
    };
    #endregion

    #region Unity Methods
    //this bool is needed so it does not run the first time so the other scripts have time to get values for variables they need.
    bool isFirstAttempt = true;
    private void OnEnable()
    {
        if (isFirstAttempt)
        {
            isFirstAttempt = false;
            return;
        }
        LoadNewCipher();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer_Button();
        }
    }
    #endregion

    #region Custom Methods
    public void CheckAnswer_Button()
    {
        //Get output from TextBlock
        string output = textBlock.Output;
        //Find number of correct and wrong characters
        CalculateNumCorrectWrong(output);
        
        //Setup results panel
        resultsPanel.gameObject.SetActive(true);
        resultsPanel.CipherType = "Affine";
        resultsPanel.IsCorrect = (output == answerText.ToUpper());
        resultsPanel.NumCorrect = numCorrect;
        resultsPanel.NumWrong = numWrong;
        print($"The correct answer is {answerText}");
    }

    public void LoadNewCipher()
    {
        //Get Key
        keyA = AValues[Random.Range(0, AValues.Length)];
        keyB = Random.Range(1, 26);
        key = "key: (" + keyA + "," + keyB + ")";
        //Generate message and make encrypted version
        plainText = Messages.RandomMessage();
        cipherText = EncryptAffine(plainText);
        //Decide whether to make player encrypt or decrypt
        if (Random.Range(0, 2) == 0)
            isEncrypted = false;
        else
            isEncrypted = true;
        //Set up the ui
        if (isEncrypted)
        {
            instructionsText.text = "\nDecrypt using the " + key;
            textBlock.Text = cipherText;
            answerText = plainText;
        }
        else
        {
            instructionsText.text = "\nEncrypt using the " + key;
            textBlock.Text = plainText;
            answerText = cipherText;
        }
    }

    public string EncryptAffine(string _message)
    {
        string str  = _message.ToLower();

        //Encrypt
        string output = "";
        char[] strChars = str.ToCharArray();
        for (int c = 0; c < strChars.Length; c++)
        {
            bool addedChar = false;
            for (int i = 0; i < 26; i++)
            {
                if (strChars[c] == a0z25[i])
                {
                    output += a0z25[(i * keyA + keyB)%26];
                    addedChar = true;
                }
            }
            if (addedChar) continue;
            output += strChars[c];
        }

        //Return output
        return (output);
    }

    public void CalculateNumCorrectWrong(string _output)
    {
        numCorrect = 0;
        numWrong = 0;

        string _answerText = answerText.ToUpper();//The output is in uppercase
        for (int i = 0; i < _answerText.Length; i++)
        {
            if (!A0Z25.IsLetter(_answerText[i])) { continue; }
            if (_answerText[i] == _output[i])
                numCorrect++;
            else
                numWrong++;
        }
    }
    #endregion
}
