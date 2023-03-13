using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private static ShakeCamera instance;
    // 외부에서 Get 접근만 가능하도록 Instance 프로퍼티 선언.
    public static ShakeCamera Instance => instance;

    private float shakeTime;
    private float shakeIntensity;

    public ShakeCamera()
    {
        instance = this;
    }
    //인자값에 다음과 같이 하였을때 함수 사용시 인자값을 정의 하지 않아도 사용이 가능하다.
    public void OnShakeCamera(float shakeTime=1.0f, float shakeIntensity=0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByRotation");
        StartCoroutine("ShakeByRotation");
    }

    private IEnumerator ShakeByRotation()
    {
        // 흔들리기 직전의 회전값
        Vector3 startRotation = transform.eulerAngles;
        float power = 10f;

        while (shakeTime > 0.0f)
        {
            float x = 0;
            float y = 0;
            float z = Random.Range(-1f,1f);
            transform.rotation = Quaternion.Euler(startRotation + new Vector3(x,y,z)*shakeIntensity*power);

            shakeTime -= Time.deltaTime;

            yield return null;
        }
        transform.rotation = Quaternion.Euler(startRotation);
    }
}
