using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] List<string> optionsNames;
    [SerializeField] GameObject[] optionsPanels;
    [SerializeField] Dropdown optionsDropdown;
    // Start is called before the first frame update
    void Start()
    {
        optionsDropdown.ClearOptions();
        optionsDropdown.AddOptions(optionsNames);
    }

    
}
