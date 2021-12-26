using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBlock : MonoBehaviour
{
    [SerializeField] LetterBox letterBoxPF;
    [SerializeField] float spaceGap = 20;

    string text = "Tantalus made a wild grab, but the marshmallow committed suicide, diving into the flames.";

    List<LetterBox> letterBoxes = new List<LetterBox>();
    List<string> words = new List<string>();
    List<string> rowsText = new List<string>();

    Vector2 letterBoxDim;
    RectTransform rt;
    int selectedBoxIndex = 0;

    public string Output
    {
        get
        {
            string output = "";
            foreach (LetterBox box in letterBoxes)
                output += box.InputLetter;
            return output;
        }
    }

    private void Start()
    {
        //Load variables
        letterBoxDim = LetterBox.Dimensions;
        rt = GetComponent<RectTransform>();

        //Generate Text Block
        GenerateTextBlock(text);

        //LetterBoxes Setup
        letterBoxes[selectedBoxIndex].IsSelected = true;
    }

    private void Update()
    {
        DetectInput();
        print(Output);
    }

    public void UpdateSelectedBox(int newIndex)
    {
        letterBoxes[selectedBoxIndex].IsSelected = false;
        letterBoxes[newIndex].IsSelected = true;
        selectedBoxIndex = newIndex;
    }

    private void SelectNextBox()
    {
        int newBoxIndex = selectedBoxIndex;
        do
        {
            if (newBoxIndex == letterBoxes.Count - 1)
                newBoxIndex = selectedBoxIndex;
            else
                newBoxIndex++;
        }
        while (!letterBoxes[newBoxIndex].IsLetter);//Makes sure you are switching to a letter whose value you can change and not something like a period
        UpdateSelectedBox(newBoxIndex);
    }

    private void SelectPrevBox()
    {
        int newBoxIndex = selectedBoxIndex;
        do
        {
            if (newBoxIndex == 0)
                newBoxIndex = selectedBoxIndex;
            else
                newBoxIndex--;
        }
        while (!letterBoxes[newBoxIndex].IsLetter);//Makes sure you are switching to a letter whose value you can change and not something like a period
        UpdateSelectedBox(newBoxIndex);
    }

    private void GenerateTextBlock(string _text)
    {
        SeperateWords(_text);
        SeperateWordsIntoRows();
        InstantiateLetterBoxes(_text);

    }

    private void InstantiateLetterBoxes(string _text)
    {
        int numRows = rowsText.Count;
        int counter = 0;
        float yPos = rt.position.y + (numRows * letterBoxDim.y / 2) - (letterBoxDim.y / 2);
        foreach (string word in rowsText)
        {
            float xPos = rt.position.x - rt.sizeDelta.x / 2 + letterBoxDim.x / 2;
            foreach (char c in word)
            {
                if (c == " "[0])
                {
                    LetterBox NewLetterBox = Instantiate(letterBoxPF);
                    NewLetterBox.InputLetter = " ";
                    NewLetterBox.gameObject.SetActive(false);
                    letterBoxes.Add(NewLetterBox);
                    print(NewLetterBox.InputLetter);

                    xPos += spaceGap;
                    counter++;
                    continue;
                }

                LetterBox NewLB = Instantiate(letterBoxPF);

                NewLB.GetComponent<RectTransform>().position = new Vector2(xPos, yPos);
                NewLB.transform.SetParent(this.transform);
                NewLB.transform.name = $"LetterBox{counter}";
                letterBoxes.Add(NewLB);

                NewLB.BoxNumber = counter;
                NewLB.Letter = _text[counter].ToString().ToUpper();
                NewLB.IsLetter = A0Z25.IsLetter(_text[counter]);

                xPos += letterBoxDim.x;
                counter++;
            }

            LetterBox NewBox = Instantiate(letterBoxPF);
            NewBox.InputLetter = " ";
            NewBox.gameObject.SetActive(false);
            letterBoxes.Add(NewBox);
            print(NewBox.InputLetter);

            counter++;
            yPos -= letterBoxDim.y;
        }
    }

    private void SeperateWordsIntoRows()
    {
        float spaceTaken = 0f;
        string textInRow = "";
        foreach (string word in words)
        {
            if (spaceTaken + spaceGap + (word.Length * letterBoxDim.x) > rt.sizeDelta.x)
            {
                rowsText.Add(textInRow.Remove(0, 1));
                textInRow = "";
                spaceTaken = 0f;
            }
            textInRow += $" {word}";
            spaceTaken += spaceGap + (word.Length * letterBoxDim.x);
        }
        rowsText.Add(textInRow.Remove(0, 1));
    }

    private void SeperateWords(string _text)
    {
        words.Clear();

        char[] charText = _text.ToCharArray();
        string word = "";
        foreach (char c in charText)
        {
            if (c == " "[0])
            {
                if (!(word.Length == 0))
                {
                    words.Add(word);
                }
                word = "";
            }
            else
                word += c;
        }

        if (!(word.Length == 0))
        {
            words.Add(word);
        }
    }

    void DetectInput()
    {
        //Non-Letter Key Input
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SelectPrevBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            letterBoxes[selectedBoxIndex].InputLetter = " ";
            SelectNextBox();
            return;
        }

        //Letter Key Input
        if (Input.GetKeyDown(KeyCode.A))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "A";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "B";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "C";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "D";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "E";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "F";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "G";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "H";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "I";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "J";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "K";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "L";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "M";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "N";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "O"; ;
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "P";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "Q";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "R";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "S";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "T";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "U";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "V";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "W";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "X";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "Y";
            SelectNextBox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            letterBoxes[selectedBoxIndex].InputLetter = "Z";
            SelectNextBox();
            return;
        }
    }
}
