using UnityEngine;

public class CoroutinePerformer : MonoBehaviour
{
    public static CoroutinePerformer Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
