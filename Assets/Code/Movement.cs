using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Movement : MonoBehaviour
{
    public float Speed=5f;
    public Vector2 PlayerMovement;
    public Rigidbody2D RB;
    public static bool MovementEnabled=true;
    public Animator animator;

    // Update is called once per frame
    void Update(){
      animator.SetFloat("Horizontal",Input.GetAxis("Horizontal"));
      animator.SetFloat("Vertical",Input.GetAxis("Vertical"));
        PlayerMovement.x=Input.GetAxisRaw("Horizontal");
        PlayerMovement.y=Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate(){
      if(MovementEnabled==true){
        RB.MovePosition(RB.position + PlayerMovement * Speed * Time.fixedDeltaTime);
      }
    }
}
