using DG.Tweening;
using System.Collections;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _statsPanel;


    public void Play()
    {
        CoroutinePerformer.Instance.StartCoroutine(PlayAsync());
    }

    private IEnumerator PlayAsync()
    {
        LoadingScreen.Instance.Show();
        //LoadingScreen.Instance.SendMessage("Loading...");

        yield return SceneLoaderService.LoadAsync(1);

        LoadingScreen.Instance.Hide();
    }

    public void OpenMainPanel()
    {
        _mainPanel.transform.DOScale(1, .2f);
        _settingsPanel.transform.DOScale(0, 0);
        _statsPanel.transform.DOScale(0, 0);
    }

    public void OpenSettingsPanel()
    {
        _mainPanel.transform.DOScale(0, 0);
        _settingsPanel.transform.DOScale(1, .2f);
        _statsPanel.transform.DOScale(0, 0);
    }

    public void OpenStatsPanel()
    {
        _mainPanel.transform.DOScale(0, 0);
        _settingsPanel.transform.DOScale(0, 0);
        _statsPanel.transform.DOScale(1, .2f);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
