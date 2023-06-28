using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Att_Fire_Quick LaunchAttack(GameObject parent, GameObject prefab, Vector2 direction)
    {
        GameObject attackObj = GameObject.Instantiate(prefab, parent.transform);
        Att_Fire_Quick att = attackObj.GetComponent<Att_Fire_Quick>();
        att.Launch(direction, parent);
        return att;
    }
}
