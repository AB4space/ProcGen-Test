﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public string GameSeed = "Default";
    public bool useStringSeed;
    public bool randomizeSeed;
    public int CurrentSeed = 0;

    private void Awake()
    {
        CurrentSeed = GameSeed.GetHashCode();
        Random.InitState(CurrentSeed);
    }
}
