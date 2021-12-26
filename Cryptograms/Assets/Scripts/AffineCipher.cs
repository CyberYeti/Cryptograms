using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class AffineCipher : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inputText;
    [SerializeField] TextMeshProUGUI outputText;

    int keyA;
    int keyB;
    string key;
    string plainText;
    string cipherText;
    bool isEncrypted = false;

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

    private void OnEnable()
    {
        LoadNewCipher();
    }

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

        outputText.text = "";

        if (isEncrypted)
            inputText.text = cipherText + "\nDecrypt using the " + key;
        else
            inputText.text = plainText + "\nEncrypt using the " + key;
    }

    public void ShowAnswer()
    {
        
        if (isEncrypted)
            outputText.text = plainText;
        else
            outputText.text = cipherText;
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
}
