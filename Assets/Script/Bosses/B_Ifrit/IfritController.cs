using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfritController : Boss
{
    [SerializeField] private Rigidbody2D m_rig;
    [SerializeField] private Collider2D m_col;
    [SerializeField] private float speed;
    [SerializeField] public Animator m_anim;
    //spell flame orb
    [SerializeField] private GameObject fireOrb;
    //rolex cirle. the object behind ifrit that turn fire object around
    [SerializeField] Transform CircleRolex;
    //atk melee point
    [SerializeField] private Transform Melee;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask PlayerLayer;
    //firepoint
    [SerializeField] private Transform[] firePoint;
    [SerializeField] private Transform bossHealbarPos;//todo signhealbar
    public float timeRest = 4f;//time that enermy wait for another attack
    private Vector3 m_Velocity = Vector3.zero;
    private Vector2 onTimePos;
    public Transform test;
    private bool rageMode;
    public string[] Skillist = { "flameorb","cleaver" }; //right field for melee left for range, if you want to add more atk just add to bottom or top of array
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Melee.position,radius);
    }
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

        //damed+
        //Rage active check
        if (ModeController(base.gethitpoint(), base.getMaxhitpoint(), 0.5f)&&!rageMode)
        {
            Debug.Log("active Rage mode");
            RageMode();
            rageMode = true;
        }
    }

    public void  Movement(Vector3 toPos)
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(toPos.x,transform.position.y), speed * Time.deltaTime);

    }
       

    [ContextMenu("Cleaver")]
    public void Cleaver()
    {
        m_anim.SetTrigger("Attack_Melee");
       
    }
    public void MeleeAtk()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(Melee.position, radius, PlayerLayer);
        foreach (Collider2D col in cols)
        {
            if (col.gameObject != gameObject)
            {
                Debug.Log("atack " + col.name + " " + _dame);
           
                    col.GetComponent<Player>().takeDamage(_dame);  
            }
        }
    }
   /// <summary>
   /// -flameorb: summon fire orb swing on the orbit
   /// -cleaver: simple melee
   /// </summary>
   /// <param name="name"></param>
   /// <param name="Itarget"></param>
    public void Atk(string name,Transform Itarget)
    {
        switch (name)
        {
            case "flameorb":
                FlameOrbSummon(Itarget);
                Debug.Log("flame");
                break;
            case "cleaver":
                Cleaver();
                break;
            case "skyrider": //fall off from the sky to target 
                break;
            case "meteor"://shooting the string of massive fireorb after flying to sky, decree restTime to nearly zero then weakness when fall off ground 
                break;
        }
    }

    public void FlameOrbSummon(Transform Itarget)
    {
        for (int i = 0; i < firePoint.Length; i++)
        {
           
            //creat orb
           GameObject flameOrb= Instantiate(fireOrb, firePoint[i].position, Quaternion.identity, CircleRolex.transform);
            //aim
            flameOrb.GetComponent<FireOrb>().target =Itarget;//need find target
        }
    }

 
    public void RageMode()
    {
        
        //more dame
        _dame += 20;
        //bigger orb
        CircleRolex.transform.localScale = fireOrb.transform.localScale* 2;
        //more sensivity
        timeRest /= 2;
        //unlock sign skill skyrider and meteor by add those to Skillist
    
    }



}
