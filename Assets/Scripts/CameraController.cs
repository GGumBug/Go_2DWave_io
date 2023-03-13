using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform       target;
    [SerializeField]
    private float           yOffset = 8;
    [SerializeField]
    private float           smoothTime = 0.3f;
    private Vector3         velocity = Vector3.zero; // 값의 변화량 현재 속도

    private Camera          mainCamera;

    private void Awake() {
        mainCamera = GetComponent<Camera>();
    }

    private void FixedUpdate() {
        // TransformPoint는 로컬 좌표를 월드좌표로 반환한다.
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, yOffset, -10));
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

        // 목표 위치까지 부트럽게 이동할 때 사용하는 메소드
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public void ChangeBackGroundColor()
    {
        float colorHue = Random.Range(0, 10);
        colorHue *= 0.1f;
        //HSVToRGB의 인자값은 색상 채도 명도를 나타낸다.
        mainCamera.backgroundColor = Color.HSVToRGB(colorHue, 0.6f, 0.8f);
    }
}
