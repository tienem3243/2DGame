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
	int atkCount = 0;
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
			atkCount += 1;
			Debug.Log("atk active");
        }
	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
		Debug.Log("active funtion onlanding");
	}
	public void OnAir()
	{
		animator.SetBool("IsJumping", true);
		Debug.Log("Fall");
	}


	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump,dash,crouch,atkCount);
		dash = false;
		jump = false;
		crouch = false;
	}
}
