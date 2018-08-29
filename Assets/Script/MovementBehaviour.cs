using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementBehaviour : ScriptableObject
{
    public abstract void MoveObject(GameObject obj, Transform left, Transform right);
}
