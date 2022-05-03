using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public bool ModeController(float hitpoint, float maxhitpoint, float threshold)//thresh hold active rage mode
    {
        if (hitpoint / maxhitpoint <= threshold)
        {
            return true;
        }
        return false;
    }
}