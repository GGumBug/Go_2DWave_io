using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField]
    private float xMoveSpeed = 2;
    [SerializeField]
    private float xDelta = 2;
    private float xStartPosition;

    [Header("Vertical Movement")]
    [SerializeField]
    private float yMoveSpeed = 0.5f;
    private Rigidbody2D rigid2D;

    private void Awake() {
        rigid2D = GetComponent<Rigidbody2D>();

        xStartPosition = transform.position.x;
    }

    public void MoveToX()
    {
        //Time.time 은 게임이 시작된 직후부터 흐른 시간 값을 반환
        float x = xStartPosition + xDelta * Mathf.Sin(Time.time * xMoveSpeed);

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void MoveToY()
    {
        //AddForce를 활용하여 물체에 힘을 작용할 수 있다. 모드에 따라 작용하는 힘의 성질이 달라진다.
        rigid2D.AddForce(transform.up * yMoveSpeed, ForceMode2D.Impulse);
    }
}
