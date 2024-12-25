using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcusPlayer_Script : MonoBehaviour
{
    public Transform target; // Nhân vật hoặc đối tượng cần theo dõi
    public float smoothSpeed = 0.125f; // Tốc độ mượt
    public Vector3 offset; // Độ lệch của camera so với đối tượng

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
