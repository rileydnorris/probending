using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool _isColliding = false;
    private Collider2D _userCollider;

    void Update()
    {
        if (_isColliding)
        {
            if (_userCollider == null)
            {
                _isColliding = false;
                return;
            }

            RaycastHit2D colliderMin = Physics2D.Raycast(_userCollider.bounds.min, Vector2.down, 1f, 1 << 7);
            RaycastHit2D colliderMax = Physics2D.Raycast(_userCollider.bounds.max, Vector2.down, 1f, 1 << 7);

            if (colliderMin)
            {
                Debug.Log("Min: " + _userCollider.bounds.min);
            }
            if (colliderMax)
            {
                // Debug.Log("Max: " + colliderMax.collider.gameObject.name);
            }

            if (colliderMin && colliderMax && colliderMin.collider.gameObject.name == gameObject.name && colliderMax.collider.gameObject.name == gameObject.name)
            {
                Debug.Log("Killing");
                // Killing the player
                DamageReceiver playerDamage = _userCollider.GetComponent<DamageReceiver>();
                if (playerDamage)
                {
                    playerDamage.Kill();
                }
                _isColliding = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.name);
            _userCollider = other;
            _isColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _isColliding = false;
    }
}
