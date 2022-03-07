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
			animator.SetBool("isDashing", true);
		} else if (Input.GetButtonUp("Dash"))
		{
			dash = false;
			animator.SetBool("isDashing", false);

		}

	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}


	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, dash, jump);
		jump = false;
	}
}
