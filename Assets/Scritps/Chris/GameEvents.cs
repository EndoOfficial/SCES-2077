using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void tempDelegate(float _temp);
    public static tempDelegate temp;

    public static Action temp2;
}
