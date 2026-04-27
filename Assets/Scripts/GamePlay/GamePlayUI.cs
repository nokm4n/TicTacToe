using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private GameObject _winnerScreen;
    [SerializeField] private TextMeshProUGUI _resultsText;

    private void Start()
    {
        CEvents.OnGameEnded += ShowResults;
        _winnerScreen.transform.DOScale(0, 0);
    }

    private void OnDisable()
    {
        CEvents.OnGameEnded -= ShowResults;
    }

    private void ShowResults(int winner)
    {
        _winnerScreen.transform.DOScale(1, 0.3f);
        if(winner == 2)
        {
            _resultsText.text = "Draw!";
        }
        else
        {
            _resultsText.text = winner == 1 ? "The winner is X" : "The winner is O";
        }
    }

    public void NewGame()
    {
        _winnerScreen.transform.DOScale(0, 0.3f);
    }

    public void OpenMenu()
    {
        CoroutinePerformer.Instance.StartCoroutine(PlayAsync());
    }

    private IEnumerator PlayAsync()
    {
        LoadingScreen.Instance.Show();
        //LoadingScreen.Instance.SendMessage("Loading...");

        yield return SceneLoaderService.LoadAsync(0);

        LoadingScreen.Instance.Hide();
    }
}
