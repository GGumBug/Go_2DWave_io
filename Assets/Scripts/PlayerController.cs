using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement2D movement;

    private void Awake() {
        movement = GetComponent<Movement2D>();
    }

    private void FixedUpdate() {
        movement.MoveToX();

        if (Input.GetMouseButton(0))
        {
            movement.MoveToY();
        }
    }
}
