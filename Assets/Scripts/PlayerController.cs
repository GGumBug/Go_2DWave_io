using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    private Movement2D movement;

    private void Awake() {
        movement = GetComponent<Movement2D>();
    }

    private void FixedUpdate() {

        if (stageController.IsGameOver == true) return;

        movement.MoveToX();

        if (Input.GetMouseButton(0))
        {
            movement.MoveToY();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Item"))
        {
            Debug.Log("Score + 1");

            Destroy(collision.gameObject);
        }
        else if (collision.tag.Equals("Obstacle"))
        {
            //Destroy로 컴포넌트도 파괴 가능하다.
            Destroy(GetComponent<Rigidbody2D>());

            stageController.GameOver();
        }
    }
}
