using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitObject : MonoBehaviour
{
    public abstract bool Hit(float direction);
}
