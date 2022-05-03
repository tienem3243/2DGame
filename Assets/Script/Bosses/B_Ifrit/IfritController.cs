using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfritController : Boss
{
    [SerializeField] private Rigidbody2D m_rig;
    [SerializeField] private Collider2D m_col;
    [SerializeField] private float speed;
    [SerializeField] private Animator m_anim;
    //spell flame orb
    [SerializeField] private GameObject fireOrb;
    //rolex cirle. the object behind ifrit that turn fire object around
    [SerializeField] Transform CircleRolex;
    //firepoint
    [SerializeField] private Transform[] firePoint;
    [SerializeField] private Transform bossHealbarPos;//todo signhealbar
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;
    private Vector2 onTimePos;
    public Transform test;
    private bool rageMode;
    private void Start()
    {
        m_anim = GetComponent<Animator>();
          Instantiate(_heathBar, transform);
        _heathBar = GetComponentInChildren<HeathBarController>();
        _heathBar.setCanvasGroupAlpha(0);//just like other alpha that can make it invisible
        _heathBar.SetHealthBar(_hitPoint, _maxHitPoint);
    }
    private void Update()
    {
        
        //Rage active check
        if (ModeController(base.gethitpoint(), base.getMaxhitpoint(), 0.5f)&&!rageMode)
        {
            RageMode();
            rageMode = true;
        }
    }

    public void Movement(Vector3 toPos)
    {
        Vector3 direction = toPos - transform.position;
        m_rig.velocity = new Vector2(direction.normalized.x*speed*Time.fixedDeltaTime* 10f, m_rig.velocity.y);
        
    }

    [ContextMenu("Cleaver")]
    public void Cleaver()
    {

    }


    
    public void Spell(string name)
    {
        switch (name)
        {
            case "flameOrb":
                FlameOrbSummon();
                break;
        }
    }

    [ContextMenu("Spell: Flame Orb")]
    public void FlameOrbSummon()
    {
        for (int i = 0; i < firePoint.Length; i++)
        {
            //creat orb
           GameObject flameOrb= Instantiate(fireOrb, firePoint[i].position, Quaternion.identity, CircleRolex.transform);
            //aim
            flameOrb.GetComponent<FireOrb>().target = test;//need find target
        }
    }

    public float Calculate(Vector2 Vect1, Vector2 Vect2)
    {
        float AngleRad = Mathf.Atan2(Vect1.y - Vect2.y, Vect1.x - Vect2.x);


        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        Debug.Log(AngleDeg);
        return AngleDeg;
    }
    public void RageMode()
    {
        Debug.Log("active Rage mode");
    
    }



}
