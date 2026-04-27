using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ButtonScript _buttonPrefab;
    [SerializeField] private GameObject _grid;
    [SerializeField] private List<Sprite> _sprites;

    private List<ButtonScript> _buttons = new();
    private bool _xTurn = true;
    private SaveSystem _saveSystem = new();
    private string _saveName = "SkinIndex";
    private int _skinIndex = 0;

    private void Awake()
    {
        InitGame();
        _saveSystem.Load<int>(_saveName, s => _skinIndex = s);
    }

    public void ResetGame()
    {
        foreach(var button in _buttons)
        {
            button.Reset();
        }
        _xTurn = true;
    }

    private void InitGame()
    {
        for (int i = 0; i < 9; i++)
        {
            int index = i;
            var button = Instantiate(_buttonPrefab, _grid.transform);
            button.Button.onClick.AddListener(() => Click(index, _xTurn));
            button.Button.onClick.AddListener(() => AudioController.Instance.PlayClick(_xTurn ? 1 : 0));
            _buttons.Add(button);
        }
    }

    private void Click(int i, bool xTurn)
    {
        int spriteIndex = _xTurn ? 1 : 0;
        _buttons[i].SetSprite(_sprites[spriteIndex + _skinIndex * 2], xTurn? 1 : 0);
        _xTurn = !_xTurn;

        int winner = CheckWinner();

        if (winner != -1 )
        {
            CEvents.FireGameEnded(winner);
        }
    }

    bool Line(int a, int b, int c, out int winner)
    {
        winner = _buttons[a].Value;

        if (winner != -1 && winner == _buttons[b].Value && winner == _buttons[c].Value)
            return true;

        return false;
    }

    public int CheckWinner()
    {
        int w;

        if (Line(0, 1, 2, out w)) return w;
        if (Line(3, 4, 5, out w)) return w;
        if (Line(6, 7, 8, out w)) return w;

        if (Line(0, 3, 6, out w)) return w;
        if (Line(1, 4, 7, out w)) return w;
        if (Line(2, 5, 8, out w)) return w;

        if (Line(0, 4, 8, out w)) return w;
        if (Line(2, 4, 6, out w)) return w;

        foreach (var b in _buttons)
        {
            if (b.Value == -1)
                return -1; 
        }

        return 2;
    }
}
