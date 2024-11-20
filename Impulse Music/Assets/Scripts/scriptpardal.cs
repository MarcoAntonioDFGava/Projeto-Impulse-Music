using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Velocity { Slow = 0, Normal = 1, Fast = 2, Faster = 3, Fastest = 4 };

public class Movement : MonoBehaviour
{
    public Velocity CurrentSpeeds;
    //			    0	   1	  2	  3 	 4
    float[] velocityValues = { 8.6f, 10.4f, 12.96f, 15.6f, 19.27f };

    public Transform GroundCheckTransform;
    public float GroundCheckRadius;
    public LayerMask GroundMask;
    public float jumpforce;
    public bool jump, isGrounded;
    public Rigidbody2D Bird;
    public float speed;
    private float moveBird;

    void Update()
    {
        // Movimento horizontal com a velocidade baseada no enum 'CurrentSpeeds'
        transform.position += Vector3.right * velocityValues[(int)CurrentSpeeds] * Time.deltaTime;

        // Verifica se o jogador pressionou o bot o do mouse (clique esquerdo)
        if (Input.GetMouseButton(0))
        {
            // Verifica se o jogador est  no ch o antes de pular
            if (onGround())
                moveBird = Input.GetAxis("Horizontal");
            Bird.linearVelocity = new Vector2(moveBird * speed, Bird.linearVelocity.y);
            jump = Input.GetButtonDown("Jump");
            if (jump == true)
            {
                Bird.AddForce(new Vector2(0, jumpforce));
            }
        }

        // Fun  o para verificar se o jogador est  tocando o ch o
        bool onGround()
        {
            return Physics2D.OverlapCircle(GroundCheckTransform.position, GroundCheckRadius, GroundMask);
        }
    }
}