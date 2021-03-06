using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
	[SerializeField] private float m_dashForce = 40f;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching
	private bool m_wasCrouching = false;

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	[SerializeField] Vector3 spawnPos;

	[SerializeField]
	MeleeAtkSys atkSys;

	Collider2D _colDash, _colStand;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;
	public UnityEvent OnAirEvent;
	public BoolEvent OnCrouchEvent;
	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		_colStand = GetComponent<CapsuleCollider2D>();
		_colDash = GetComponent<PolygonCollider2D>();
		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
		if (OnAirEvent == null)
			OnAirEvent = new UnityEvent();
		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
		
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		// Creat a array that hold many object was scaned by cursor, Physic2D.OverlapCircleAll(cursor position,radius,layer need)
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		if (colliders.Length == 0)
		{
			OnAirEvent.Invoke();
		}
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{

				m_Grounded = true;
				if (!wasGrounded)
				{
					OnLandEvent.Invoke();
				}

			}
            if (colliders[i].CompareTag("Platform")){
				m_CrouchDisableCollider = colliders[i];
            }
          
		}
	}


	public void Move(float move, bool jump, bool dash, bool crouch, bool atk)
	{
		
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					//OnCrouchEvent.Invoke(true);
				}
				

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			}
			else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
		if (dash && m_Grounded)
			Dash();
       
	
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	public void Dash()
    {
		{
			_colStand.enabled = false;
			_colDash.enabled = true;
			if (m_FacingRight)
			{

				m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
				m_Rigidbody2D.velocity = Vector2.right * 22;
				m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
			}
			else
			{
				m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
				m_Rigidbody2D.velocity = Vector2.left * 22;
				m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
			}
			StartCoroutine(WaitforDashEnd());

		}
	}

	public void MoveToPosition(Vector2 pos)
    {
		m_Rigidbody2D.MovePosition(pos);
    }
	IEnumerator WaitforDashEnd()
	{
			yield return new WaitForSeconds(.1f);
		_colDash.enabled = false;
		_colStand.enabled = true;
	}
	public void Repel(float repelForce,Vector3 sourcePos)
    {
	
		Vector3 repelPos = (transform.position - new Vector3(sourcePos.x,sourcePos.y+4f,0)).normalized * repelForce;
		m_Rigidbody2D.AddForce(repelPos);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal"))
        {
			spawnPos = collision.transform.position;
        }
    }

}