using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scriptcamera : MonoBehaviour
{
    public velocity CurrentSpeeds;
    // 0 Slow, 1 Normal, 2 Fast, 3 Faster, 4 Fastest
    float[] velocityValues = { 7.2f, 8.6f, 12.96f, 15.6f, 19.27f };

    public Transform GroundCheckTransform;
    public float GroundCheckRadius;
    public LayerMask GroundMask;

    void Update()
    {
        // Movimento horizontal com a velocidade baseada no enum 'CurrentSpeeds'
        transform.position += Vector3.right * velocityValues[(int)CurrentSpeeds] * Time.deltaTime;
    }
}