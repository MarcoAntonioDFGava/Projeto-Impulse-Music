using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public enum velocity { Slow = 0, Normal = 1, Fast = 2, Faster = 3, Fastest = 4 };
public class Movement : MonoBehaviour
{
    public velocity CurrentSpeeds;
    //			    0	   1	  2	  3 	 4
    float[] velocityValues = { 8.6f, 10.4f, 12.96f, 15.6f, 19.27f };

public Transform GroundCheckTransform;
public float GroundCheckRadius;
public LayerMask GroundMask;
void Update()
{
    transform.position += Vector3.right = velocityValues[(int)CurrentSpeeds] * Time.deltaTime;

    if (Input.GetMouseButton(0))
    {
            //Jump
            if (OnGround())
                print("Player jump");


        }
}

bool onGround()
{
    return Physics2D.OverlapCircle(GroundCheckTransform.position, GroundCheckRadius, GroundMask);
}
}
