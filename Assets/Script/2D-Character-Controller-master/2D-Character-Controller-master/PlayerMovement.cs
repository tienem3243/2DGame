using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;
	bool crouch = false;
	bool atk = false;
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}
		if (Input.GetButtonDown("Dash"))
		{
			dash = true;
			animator.SetTrigger("IsDashing");
		}
		if (Input.GetButtonDown("Crounch"))
		{
			crouch = true;
			animator.SetTrigger("IsCrouching");
		}
		if (Input.GetButtonDown("MeleeAtack"))
        {
			atk = true;
        }
	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
		animator.SetBool("IsGround",true);
	}
	public void OnAir()
	{
		animator.SetBool("IsJumping", true);
		animator.SetBool("IsGround", false);
	}


	void FixedUpdate ()
	{

        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash, crouch, atk);
		atk = false;
		dash = false;
		jump = false;
		crouch = false;
		
	}
}
