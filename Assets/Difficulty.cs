using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    static int secondsUntilMaxDifficulty = 20;

    public static float getDifficulty() {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsUntilMaxDifficulty);
    }
}
