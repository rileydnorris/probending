using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Attack LaunchAttack(GameObject parent, GameObject prefab, Vector2 direction)
    {
        GameObject attackObj = GameObject.Instantiate(prefab, parent.transform);
        Attack att = attackObj.GetComponent<Attack>();
        att.Launch(direction);
        return att;
    }
}
