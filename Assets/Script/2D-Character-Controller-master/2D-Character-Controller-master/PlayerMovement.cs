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
		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
			Debug.Log(crouch);
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
			Debug.Log(crouch);
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
	public void OnCrouching(bool isCrouching)
	{
	}

	void FixedUpdate ()
	{

        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash, crouch, atk);
		dash = false;
		jump = false;
		Debug.Log(crouch);
	}
}
