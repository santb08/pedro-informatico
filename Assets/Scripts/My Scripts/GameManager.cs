using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int CurrentLevel = 1;
    private static string GameThematic = "Prueba";

    public static string GetGameThematic()
    {
        return GameThematic;
    }

    public static void SetGameThematic(string newThematic)
    {
        GameThematic = newThematic;
    }
}
