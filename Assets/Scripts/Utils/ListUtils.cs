using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListUtils
{

    public static T PickRandom<T>(List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}
