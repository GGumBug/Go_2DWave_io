using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    [SerializeField]
    private GameObject      playerDieEffect;
    private Movement2D      movement;

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
            stageController.IncreaseScore(1);

            collision.GetComponent<Item>().Exit();
        }
        else if (collision.tag.Equals("Obstacle"))
        {
            Instantiate(playerDieEffect, transform.position, Quaternion.identity);

            //Destroy로 컴포넌트도 파괴 가능하다.
            Destroy(GetComponent<Rigidbody2D>());

            stageController.GameOver();
        }
    }
}
