using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool isUserColliding = false;
    private bool _isColliding = false;
    private Collider2D _userCollider;

    void Update()
    {
        if (_isColliding)
        {
            RaycastHit2D colliderMin = Physics2D.Raycast(_userCollider.bounds.min, Vector2.down, 1f, 1 << 7);
            RaycastHit2D colliderMax = Physics2D.Raycast(_userCollider.bounds.max, Vector2.down, 1f, 1 << 7);

            if (colliderMin && colliderMax && colliderMin.collider.gameObject.name == gameObject.name && colliderMax.collider.gameObject.name == gameObject.name)
            {
                // Killing the player
                AnimationHandler anim = _userCollider.GetComponent<AnimationHandler>();
                if (anim)
                {
                    anim.SetDeath();
                }

                ObjectStatus status = _userCollider.GetComponent<ObjectStatus>();
                if (status)
                {
                    status.isAlive = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _userCollider = other;
        _isColliding = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _isColliding = false;
    }
}
