using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image _loadingCircle;
    [SerializeField] private TextMeshProUGUI _messageText;

    public static LoadingScreen Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        Hide();
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    public void ShowMessage(string message) => _messageText.text = message;

    private void Update()
    {
        _loadingCircle.transform.Rotate(Vector3.forward * Time.deltaTime * 100, Space.World);
    }
}
