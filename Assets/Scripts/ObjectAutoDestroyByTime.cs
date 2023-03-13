using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAutoDestroyByTime : MonoBehaviour
{
    [SerializeField]
    private float destroyTime;

    private void Awake() {
        Destroy(gameObject, destroyTime);
    }
}
