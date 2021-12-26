using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] List<string> optionsNames;
    [SerializeField] GameObject[] optionsPanels;
    [SerializeField] Dropdown optionsDropdown;

    int currentIndex = 0;

    void Start()
    {
        optionsDropdown.ClearOptions();
        optionsDropdown.AddOptions(optionsNames);
        optionsDropdown.value = 0;
        optionsDropdown.RefreshShownValue();

        foreach (GameObject panel in optionsPanels)
        {
            panel.SetActive(false);
        }
        optionsPanels[currentIndex].SetActive(true);
    }

    public void OptionsDropdown(int _index)
    {
        optionsPanels[currentIndex].SetActive(false);
        optionsPanels[_index].SetActive(true);
        currentIndex = _index;
    }
}
