using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Image _cell;
    [SerializeField] private Button _button;
    [SerializeField] private List<AudioClip> _clicks;

    private int _value = -1;
    public Button Button => _button;
    public int Value => _value;

    private void Start()
    {
        CEvents.OnGameEnded += GameOver;
    }

    public void SetSprite(Sprite sprite, int value)
    {
        _cell.sprite = sprite;
        _button.interactable = false;
        _value = value;
    }

    public void Reset()
    {
        _cell.sprite = null;
        _button.interactable = true;
        _value = -1;
    }

    private void GameOver(int i)
    {
        _button.interactable = false;
    }

}
