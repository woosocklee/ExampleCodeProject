using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Pair<T1, T2>
{
    public T1 First;
    public T2 Second;

    public Pair(T1 first, T2 second)
    {
        First = first;
        Second = second;
    }

    public override string ToString()
    {
        return First.ToString() + "," + Second.ToString();
    }
}

[Serializable]
public struct EnumPair<Enum, T> where Enum: System.Enum
{
    public Enum First;
    public T Second;

    public EnumPair(Enum first, T second)
    {
        First = first;
        Second = second;
    }

    public override string ToString()
    {
        return First.ToString() + "," + Second.ToString();
    }
}