using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LetterBox : MonoBehaviour
{
    [SerializeField] Color unselectedColor;
    [SerializeField] Color selectedColor;

    [Header("Internal Components")]
    [SerializeField] TextMeshProUGUI letterTextArea;
    [SerializeField] TextMeshProUGUI inputText;
    [SerializeField] Image inputAreaPanel;
    [SerializeField] Button inputButton;

    int boxNumber;
    bool isLetter = true;
    bool isSelected = false;
    TextBlock parentTextBlock;

    public int BoxNumber
    {
        get
        {
            return boxNumber;
        }
        set
        {
            boxNumber = value;
        }
    }
    public string Letter
    {
        get
        {
            return letterTextArea.text;
        }
        set
        {
            letterTextArea.text = value;
        }
    }
    public string InputLetter
    {
        get
        {
            return inputText.text;
        }
        set
        {
            if (isLetter)
                inputText.text = value;
        }
    }
    public bool IsLetter
    {
        get { return isLetter; }
        set
        {
            isLetter = value;
            if (value)
            {
                inputAreaPanel.enabled = true;
                inputText.enabled = true;
                inputButton.enabled = true;
                inputText.text = "";
            }
            else
            {
                inputAreaPanel.enabled = false;
                inputButton.enabled = false;
                inputText.text = Letter;
            }
        }
    }
    public bool IsSelected
    {
        set
        {
            if (value)
            {
                if (!isLetter)
                    Debug.LogWarning($"Error: LetterBox{boxNumber} is not a letter and should not be selected.");
                else
                    isSelected = true;
                    inputAreaPanel.color = selectedColor;
            }
            else
            {
                isSelected = false;
                inputAreaPanel.color = unselectedColor;
            }
        }
    }
    public static Vector2 Dimensions
    {
        get
        {
            return new Vector2(40f,88f);
        }
    }
    public static Vector2 Spacing
    {
        get
        {
            return new Vector2(35f, 80f);
        }
    }

    private void Start()
    {
        parentTextBlock = this.transform.parent.GetComponent<TextBlock>();
        InputLetter = " ";
    }

    public void SelectBox()
    {
        parentTextBlock.UpdateSelectedBox(boxNumber);
    }
}
