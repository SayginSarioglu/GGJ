using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : HitObject {
    public override bool Hit(float direction)
    {
        return false;
    }
}
