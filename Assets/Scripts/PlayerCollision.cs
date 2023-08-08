using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private List<Collider2D> _userColliders = new List<Collider2D>();
    private bool _isColliding
    {
        get { return _userColliders.Count > 0; }
    }

    void Update()
    {
        if (_isColliding)
        {
            _userColliders.ForEach((col) =>
            {
                CheckForOOB(col);
            });
        }
    }

    void CheckForOOB(Collider2D col)
    {
        RaycastHit2D colliderMin = Physics2D.Raycast(col.bounds.min, Vector2.down, 1f, 1 << 7);
        RaycastHit2D colliderMax = Physics2D.Raycast(col.bounds.max, Vector2.down, 1f, 1 << 7);

        if (colliderMin && colliderMax && colliderMin.collider.gameObject.name == gameObject.name && colliderMax.collider.gameObject.name == gameObject.name)
        {
            // Killing the player
            Debug.Log("Killing");
            DamageReceiver playerDamage = col.GetComponent<DamageReceiver>();
            if (playerDamage)
            {
                playerDamage.Kill();
            }
            _userColliders.Remove(col);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.name);
            _userColliders.Add(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _userColliders.Remove(other);
    }
}
