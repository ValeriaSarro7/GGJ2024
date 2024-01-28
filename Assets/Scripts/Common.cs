using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public enum JokeCategory
{
    NEGROS,
    BLANCOS,
    VERDES,
    INFORMATICOS,
    None
};

public struct InputResult
{
    JokeCategory[] jokeCategories;
};
