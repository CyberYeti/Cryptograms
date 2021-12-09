using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class AtbashCipher : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inputText;
    [SerializeField] TextMeshProUGUI outputText;

    char[] a0z25 =
    {
        "a"[0],
        "b"[0],
        "c"[0],
        "d"[0],
        "e"[0],
        "f"[0],
        "g"[0],
        "h"[0],
        "i"[0],
        "j"[0],
        "k"[0],
        "l"[0],
        "m"[0],
        "n"[0],
        "o"[0],
        "p"[0],
        "q"[0],
        "r"[0],
        "s"[0],
        "t"[0],
        "u"[0],
        "v"[0],
        "w"[0],
        "x"[0],
        "y"[0],
        "z"[0]
};

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
