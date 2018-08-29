using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsMake : ScriptableObject
{
    public abstract List<GameObject> Objects { get; }

    public abstract void Make(Transform parent, int sumBox);
}
