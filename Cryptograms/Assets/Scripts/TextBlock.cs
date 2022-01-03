using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBlock : MonoBehaviour
{
    #region Variables
    [SerializeField] LetterBox letterBoxPF;
    [SerializeField] float spaceGap = 20;
    [SerializeField] bool centerAlignX = true;
    [SerializeField] bool centerAlignY = false;

    string text = "";

    List<LetterBox> letterBoxes = new List<LetterBox>();
    List<string> words = new List<string>();
    List<string> rowsText = new List<string>();

    Vector2 letterBoxDim;
    Vector2 letterBoxSpacing;
    Vector2 dimensions;
    RectTransform rt;
    int selectedBoxIndex = -1;
    #endregion

    #region Attributes
    public string Text
    {
        set
        {
            //Reset Letter Boxer
            selectedBoxIndex = -1;
            while (letterBoxes.Count > 0)
            {
                LetterBox boxToRemove = letterBoxes[0];
                letterBoxes.RemoveAt(0);
                Destroy(boxToRemove.gameObject);
            }

            //Generate New Text
            text = value;
            GenerateTextBlock(text);

            //LetterBoxes Setup
            letterBoxes[0].IsSelected = true;
        }
    }
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
    #endregion

    #region Unity Methods
    private void Awake()
    {
        //Load variables
        letterBoxDim = LetterBox.Dimensions;
        letterBoxSpacing = LetterBox.Spacing;
        rt = GetComponent<RectTransform>();
        dimensions = GetComponent<BoxDimensions>().Dimensions;
    }

    private void Update()
    {
        //SelectedBoxIndex = selectedBoxIndex;
        DetectInput();
    }
    #endregion

    #region TextBlock Methods
    //Generate TextBlock Methods
    private void GenerateTextBlock(string _text)
    {
        if (rt ==  null)
        {
            letterBoxDim = LetterBox.Dimensions;
            rt = GetComponent<RectTransform>();
        }

        SeperateWords(_text);
        SeperateWordsIntoRows();

        /*debugging
        print("Strings to print");
        foreach (string text in rowsText)
            print(text);
        */
        InstantiateLetterBoxes(_text);

    }

    float xpos;
    //Debugging
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(new Vector3(xpos, 0, rt.position.z), new Vector3(xpos, 10000, rt.position.z));
        Gizmos.color = Color.black;
        Gizmos.DrawLine(new Vector3(rt.position.x, 0, rt.position.z), new Vector3(rt.position.x, 10000, rt.position.z));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(rt.position.x - dimensions.x / 2, 0, rt.position.z), new Vector3(rt.position.x - dimensions.x / 2, 10000, rt.position.z));
    }
    */
    private void InstantiateLetterBoxes(string _text)
    {
        int numRows = rowsText.Count;
        int counter = 0;

        float yPos;
        if (centerAlignY)
        {
            float blockHeight = numRows * letterBoxSpacing.y;
            yPos = rt.position.y + blockHeight / 2 - letterBoxSpacing.y / 2;
        }
        else
        {
            yPos = rt.position.y + dimensions.y / 2 - letterBoxSpacing.y / 2;
        }

        foreach (string text in rowsText)
        {
            float xPos = 0f;
            if (centerAlignX)
            {
                int numWords = text.Split(" "[0]).Length;
                float blockWidth = numWords*letterBoxSpacing.x + (numWords-1)*spaceGap;
                xPos = rt.position.x - blockWidth / 2 + letterBoxDim.x / 2;
            }
            else
            {
                xPos = rt.position.x - dimensions.x / 2 + letterBoxDim.x / 2;
            }

            //debugging
            xpos = xPos;

            foreach (char c in text)
            {
                if (c == " "[0])
                {
                    LetterBox NewLetterBox = Instantiate(letterBoxPF);
                    NewLetterBox.transform.SetParent(this.transform);
                    NewLetterBox.Letter = " ";
                    NewLetterBox.transform.name = $"LetterBox{counter}";
                    NewLetterBox.IsLetter = false;
                    NewLetterBox.gameObject.SetActive(false);
                    letterBoxes.Add(NewLetterBox);

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
                if (selectedBoxIndex == -1)
                {
                    NewLB.IsSelected = true;
                    selectedBoxIndex = counter;
                }

                xPos += letterBoxSpacing.x;
                counter++;
            }

            LetterBox NewBox = Instantiate(letterBoxPF);
            NewBox.transform.SetParent(this.transform);
            NewBox.Letter = " ";
            NewBox.transform.name = $"LetterBox{counter}";
            NewBox.IsLetter = false;
            NewBox.gameObject.SetActive(false);
            letterBoxes.Add(NewBox);

            counter++;
            yPos -= letterBoxSpacing.y;
        }

        //Removes the ending space that the code above adds
        LetterBox box = letterBoxes[letterBoxes.Count - 1];
        letterBoxes.RemoveAt(letterBoxes.Count - 1);
        Destroy(box.gameObject);
    }

    private void SeperateWordsIntoRows()
    {
        rowsText.Clear();
        
        float spaceTaken = 0f;
        string textInRow = "";
        foreach (string word in words)
        {
            if (spaceTaken + spaceGap + (word.Length * letterBoxDim.x) > dimensions.x)
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

        string[] w = _text.Split(" "[0]);

        foreach (string word in w)
            words.Add(word);
    }

    //Input Methods
    private void DetectInput()
    {
        //print($"The current index at start of Detect Input is {selectedBoxIndex}");
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
            //print("---------------------------------------------------------------------");
            //print($"The current index as of pressing backspace or space is {selectedBoxIndex}.");
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

    public void UpdateSelectedBox(int newIndex)
    {
        letterBoxes[selectedBoxIndex].IsSelected = false;
        letterBoxes[newIndex].IsSelected = true;
        selectedBoxIndex = newIndex;
        //print($"The current index after updating the selected box is {selectedBoxIndex}.");
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
        //print($"New index at the time of choosing the new index is {newBoxIndex} and the current index is {selectedBoxIndex}.");
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
    #endregion
}
