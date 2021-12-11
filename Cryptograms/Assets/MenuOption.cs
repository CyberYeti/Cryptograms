using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOption : MonoBehaviour
{
    string optionName;
    GameObject optionPanel;

    public MenuOption(string _optionName, GameObject _optionPanel)
    {
        optionName = _optionName;
        optionPanel = _optionPanel;
    }
}
