using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IfritAI : MonoBehaviour
{
   
    //sensivity zone
    public LayerMask layerPlayer;
    public float radius;
    Transform target;
    float distance;
    public IfritController controller;
    [SerializeField]
    private bool action;
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
      
    }

    private void Start()
    {
        
        StartCoroutine(_Update(controller.timeRest));
    }
    private void Update()
    {
     
     
        //move control
        if(target!=null)
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance > 6 && !action && !controller.m_anim.GetCurrentAnimatorStateInfo(0).IsName("Ifrit_Cleaver"))
        {
            if(transform.position.x-target.position.x>0&&transform.rotation.y>=0||
                transform.position.x - target.position.x < 0 && transform.rotation.y < 0)//facing on right way
            {
                controller.m_anim.SetBool("isWalk", true);
                controller.Movement(new Vector3(target.position.x, target.position.y));
            }
              
        }
        else
        {
            controller.m_anim.SetBool("isWalk", false);
         
        }
    }
    private IEnumerator _Update(float timeRest)
    {
       
        while (true)
        {
            // i make this to sure enemy hard to lead
            action = !action;
            DetectTarget();
            if (controller.rageMode && controller.rageSkillCount > 0 && controller.m_anim.GetCurrentAnimatorStateInfo(0).IsName("Ifrit_Idle")) 
            {
               
                
                StartCoroutine(controller.RageATK(target));
                
            }
            if (target != null&& !controller.m_anim.GetCurrentAnimatorStateInfo(0).IsName("Ifrit_Cleaver"))
            {
                //flip controller
                if (target.position.x - transform.position.x > 0&&!controller._FacingRight)
                {
                    controller.Flip();
                }
                if (target.position.x - transform.position.x < 0 && controller._FacingRight)
                {   
                    controller.Flip();
                }
                if (distance <= 6)
                {
                    int random =Random.Range(0,controller.MeleeSkill.Length+1 );// +1 is mean 1 outrange to have a change perfome range Skill
                   // string[] merg = controller.MeleeSkill + controller.RangeSkill;
                    Debug.Log(random);
                    if (random > controller.MeleeSkill.Length - 1)//change to perform range skill in melee range
                    {
                        int randomz = Random.Range(0, controller.RangeSkill.Length - 1);
                        controller.Atk(controller.RangeSkill[randomz], target);
                    }
                    else
                    controller.Atk(controller.MeleeSkill[(int)random], target);
            
                }
                if (distance > 6f && !action)
                {
                    int random = Random.Range(0, controller.RangeSkill.Length - 1);
                
                    controller.Atk(controller.RangeSkill[random], target);
                }
                

            }
          
            yield return new WaitForSeconds(controller.timeRest);
        }
       
            
    }
    public void DetectTarget()
    {
        
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius,layerPlayer);
        foreach(Collider2D col in cols)
        {
            if (col.gameObject != gameObject)
            {
                
                target = col.transform;
                //do something
            }
        }
    }
    
}
