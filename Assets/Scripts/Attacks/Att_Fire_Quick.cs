using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Att_Fire_Quick : Attack
{
    override protected void OnAwake()
    {
        SetCollisionDestruction();
        StartCoroutine(SetTimedDestruction(1f));
    }
}
