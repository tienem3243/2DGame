using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOrb : MonoBehaviour
{
    [SerializeField] public float _dame;
    [SerializeField] public float _speed;
    public Transform target;
    public float waitTime = 1f;
    private Collider2D _col;
    private Rigidbody2D _rig;
    public bool active;//active aim

    // Start is called before the first frame update
    void Start()
    {
        _col = GetComponent<Collider2D>();
        _rig = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitShoot(waitTime));
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {

        if (!active)
        {
            _col.enabled = false;
            AimShoot();
        }
        if (active)
        {
            _col.enabled = true;
          transform.SetParent(null);//out of orbit make by object
            _rig.velocity = transform.right * _speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().takeDamage(_dame);
        }
    }
    public void AimShoot()
    {
        Vector3 targ = target.position;
        targ.z = 0f;
        //actualy it is vector 1-vector2 but that is not optimize and slow
        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;
        //agle that need to rotation
        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    IEnumerator WaitShoot(float time)
    {
        yield return new WaitForSeconds(time);
        active = true;

    }
}
