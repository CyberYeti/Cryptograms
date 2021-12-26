using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class AtbashCipher : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inputText;
    [SerializeField] TextMeshProUGUI outputText;

    char[] a0z25 = A0Z25.a0z25Table;

    public void EncryptAtbash()
    {
        //Get input
        string str = inputText.text.ToLower();
        str = RemoveEndingCharacter(str);

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
                    output += a0z25[25 - i];
                    addedChar = true;
                }
            }
            if (addedChar) continue;
            output += strChars[c];
        }

        //Print output
        outputText.text = output;
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
