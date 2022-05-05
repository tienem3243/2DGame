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
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance > 6 && !action && !controller.m_anim.GetCurrentAnimatorStateInfo(0).IsName("Ifrit_Cleaver"))
        {
            controller.m_anim.SetBool("isWalk", true);
            controller.Movement(new Vector3(target.position.x, target.position.y + 3));
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
            float random = Random.Range(0f, (float)controller.Skillist.Length-0.01f);// i make this to sure enemy hard to lead
            action = !action;
            DetectTarget();

            if (target != null)
            {
              
                if (distance <= 6f)
                {
                    if(random<(controller.Skillist.Length)/2) //half of array  
                    random += 0.4f;//increasing melee rate, this is my secret because melee atk type is alway plant on the right field of array, i know that hard to understand but it fun and fast
                    controller.Atk(controller.Skillist[(int)random], target);
            
                }
                if (distance > 6f && !action)
                {
                    controller.Atk("flameorb", target);

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
