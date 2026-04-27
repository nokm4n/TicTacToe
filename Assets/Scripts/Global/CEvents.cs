using System;
using UnityEngine;

public class CEvents : MonoBehaviour
{
    public static event Action<int> OnGameEnded;
    public static void FireGameEnded(int winner) => OnGameEnded?.Invoke(winner);
}
