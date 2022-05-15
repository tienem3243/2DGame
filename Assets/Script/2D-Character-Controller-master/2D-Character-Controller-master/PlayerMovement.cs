using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Vector2 StartPos;//where you stand when scene change
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool dash = false;
    bool crouch = false;
    bool atk = false;
    bool cooldown;
    bool isStun;
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(StartPos, new Vector2(1, 1));
    }



    // Update is called once per frame
    void Update()
    {
        if (!isStun)
        {
             
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }
      



        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        else
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            Debug.Log(crouch);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            Debug.Log(crouch);
        }else
        if (Input.GetButtonDown("MeleeAtack"))
        {
            atk = true;
        }else
             if (Input.GetButtonDown("Dash")&&!cooldown)
        {
            Invoke("Cooldown",1f);
            cooldown = true;
            dash = true;
            animator.SetTrigger("IsDashing");
        }

    }

    public void Cooldown()
    {
        cooldown = false;
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsGround", true);
    }
    public void OnAir()
    {
        animator.SetBool("IsJumping", true);
        animator.SetBool("IsGround", false);
    }
    public void OnCrouching(bool isCrouching)
    {
    }
    public void TakeDame(Vector3 sourcePos)//take dame and repel
    {
        animator.SetTrigger("getDamaged");
        isStun = true;
        StartCoroutine(EffectCoolDown("stun", 0.75f));
        controller.Repel(3000f, sourcePos);// repel a distance base on position of enemy
    }
    public void TakeDame()
    {
        animator.SetTrigger("getDamaged");
    }
    public IEnumerator EffectCoolDown(string status,float duration) //efeect need a class, not hava
    {
        yield return new WaitForSeconds(duration);
        switch (status)
        {
            case "stun":
                isStun = false;
                break;
        }
        
    }
    void FixedUpdate()
    {
        if (!isStun)
        {

            controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash, crouch, atk);
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        else
        {
            controller.Move(0, false, false, false, false);
        }
        
        dash = false;
        jump = false;
    }
}
