using System;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private SaveData _saves;
    private SaveSystem _saveSystem = new();
    private string _saveName = "ScoreSave";

    private void Awake()
    {
        CEvents.OnGameEnded += GameEnded;

        _saveSystem.Load<SaveData>(_saveName, s => _saves = s);

        _scoreText.text = "X: " + _saves.xScore + "\nO: " + _saves.oScore + "\nDraws: " + _saves.drawScore;
    }

    private void OnDisable()
    {
        CEvents.OnGameEnded -= GameEnded;
    }

    private void GameEnded(int winner)
    {
        if(winner == 2)
        {
            _saves.drawScore++;
        }
        else if(winner == 1)
        { 
            _saves.xScore++;
        }
        else
        {
            _saves.oScore++;
        }

        _scoreText.text = "X: " + _saves.xScore + "\nO: " + _saves.oScore + "\nDraws: " + _saves.drawScore;
        _saveSystem.Save(_saveName, _saves);
    }
}

[Serializable]
public struct SaveData
{
    public int xScore;
    public int oScore;
    public int drawScore;
}
