using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private List<Button> _skinButtons;

    private SaveSystem _saveSystem = new();
    private string _saveName = "SkinIndex";
    private int _skinIndex = 0;

    private void Awake()
    {
        _saveSystem.Load<int>(_saveName, s => _skinIndex = s);

        if (_skinButtons[_skinIndex] != null)
        {
            foreach (Button button in _skinButtons)
            {
                button.interactable = true;
            }
            _skinButtons[_skinIndex].interactable = false;
        }

        for(int i = 0; i < _skinButtons.Count; i++)
        {
            int index = i;
            _skinButtons[i].onClick.AddListener(() => SetSkin(index));
        }
    }

    public void SetSkin(int index)
    {
        if (_skinButtons[index] != null)
        {
            foreach (Button button in _skinButtons)
            {
                button.interactable = true;
            }
            _skinButtons[index].interactable = false;

            _saveSystem.Save(_saveName, index);
        }
    }
}
