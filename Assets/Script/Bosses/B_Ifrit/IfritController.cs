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

    [SerializeField] public int _rageSkillCount;
    [SerializeField]public int rageSkillCount;
    public bool _FacingRight;
    public string[] RangeSkill= { "flameorb" };
    public string[] MeleeSkill= { "cleaver" };
    public bool rageMode;
    public bool onRageAtk;
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Melee.position,radius);
    }
    private void Start()
    {
        rageSkillCount = _rageSkillCount;

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
       
    public void Flip()
    {
        _FacingRight = !_FacingRight;
        transform.Rotate(new Vector2(0, 180));
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
   /// -meteor: string of flameorb
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
            case "meteor":
                StartCoroutine(MeteorPerform(5f));
                break;
        }
    }

    [ContextMenu("test")]
    public void testMeteor()
    {
        StartCoroutine(MeteorPerform(5f));
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
    
    public IEnumerator MeteorPerform(float duration)
    { //TODO get actactly time
        onRageAtk = true;
        StartCoroutine(Teleport(transform.position + new Vector3(0, 19, 0)));
        yield return new WaitForSeconds(1.2f);
        timeRest = 0.09f;   
        yield return new WaitForSeconds(duration);
        m_rig.gravityScale = 3;
        timeRest = 2;//need handle
        onRageAtk = false;
        Debug.Log(m_rig.gravityScale);
    }
    public IEnumerator Teleport(Vector3 position)
    {
        m_anim.SetBool("isDisapear", true);
        yield return new WaitForSeconds(1.2f);
        m_anim.SetBool("isDisapear", false);
        m_rig.gravityScale = 0;
        m_rig.MovePosition(position);
    }
 
    public IEnumerator RageATK(Transform target)
    {
        rageSkillCount--;
        Atk("meteor", target);
        yield return new WaitForSeconds(5f);
        
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
