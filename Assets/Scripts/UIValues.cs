using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIValues
{
    private static float bestTime;
    private static int bestEnemyScore;

    public static float BestTime { get => bestTime; set => bestTime = value; }
    public static int BestEnemyScore { get => bestEnemyScore; set => bestEnemyScore = value; }
}
