using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class AffineCipher : MonoBehaviour
{
    #region Variables
    [SerializeField] TextMeshProUGUI instructionsText;
    [SerializeField] TextBlock textBlock;

    int keyA;
    int keyB;
    string key;
    string plainText;
    string cipherText;
    bool isEncrypted = false; //If true, result should be the plaintext

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
            CheckAnswer();
        }
    }
    #endregion

    #region Custom Methods
    public void LoadNewCipher()
    {
        keyA = AValues[Random.Range(0, AValues.Length)];
        keyB = Random.Range(1, 26);
        key = "key: (" + keyA + "," + keyB + ")";
        plainText = Messages.RandomMessage();
        cipherText = EncryptAffine(plainText);
        if (Random.Range(0, 2) == 0)
            isEncrypted = false;
        else
            isEncrypted = true;

        if (isEncrypted)
        {
            instructionsText.text = "\nDecrypt using the " + key;
            textBlock.Text = cipherText;
        }
        else
        {
            instructionsText.text = "\nEncrypt using the " + key;
            textBlock.Text = plainText;
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

    public void CheckAnswer()
    {
        string output = textBlock.Output;
        if (isEncrypted)
        {
            if (output == plainText.ToUpper())
            {
                print($"Correct!. The answer is {plainText}");
            }
            else
            {
                print($"Wrong. The correct answer is {plainText}");
            }
        }
        else
        {
            if (output == cipherText.ToUpper())
            {
                print($"Correct!. The answer is {cipherText}");
            }
            else
            {
                print($"Wrong. The correct answer is {cipherText}");
            }
        }
    }

    private string RemoveEndingCharacter(string str)
    {
        char[] strc1 = str.ToCharArray();
        str = "";
        for (int i = 0; i < strc1.Length - 1; i++)
        {
            str += strc1[i];
        }

        return str;
    }
    #endregion
}
