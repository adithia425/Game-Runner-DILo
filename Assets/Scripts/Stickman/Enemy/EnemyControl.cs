using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [Header("Profile")]
    [SerializeReference]
    private float hitPoint;
    [SerializeReference]
    private float moveSpeed;
    [SerializeReference]
    private float damageAttack;
    public bool findPlayer;


    [Header("Attack")]
    public bool isAttacking;
    public Transform positionAttack;
    [SerializeReference]
    private float xRange;
    [SerializeReference]
    private float yRange;
    public LayerMask layerTarget;


    [Header("Get Hit")]
    [SerializeReference]
    private float effectHitRange;
    [SerializeReference]
    private float timeFreeze;
    private float timeFreezeUpdate;

    [Header("Secondary")]
    Rigidbody2D rB;
    Animator anim;

    public Transform target;
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Collider2D targetHit = Physics2D.OverlapBox(positionAttack.position, new Vector2(xRange, yRange), 1, layerTarget);
        if (targetHit != null)
        {
                findPlayer = false;

        }else
            findPlayer = true;


        if (findPlayer && timeFreezeUpdate <= 0)
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        else
            timeFreezeUpdate -= Time.deltaTime;
    }

    public void GetHit(float dmg)
    {
        timeFreezeUpdate = timeFreeze;
        rB.AddForce(new Vector2(effectHitRange, rB.velocity.y));
        SetHitPoint(GetHitPoint() - dmg);
    }
    

    //Getter and Setter
    //Hit Point
    public float GetHitPoint()
    {
        return hitPoint;
    }
    public void SetHitPoint(float hitPoint)
    {
        this.hitPoint = hitPoint;
    }

    //Damage
    public void SetDamage(float damageAttack)
    {
        this.damageAttack = damageAttack;
    }

    //Move
    public void SetSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    //Fisik
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Weapon"))
        {
            GetHit(20);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(positionAttack.position, new Vector2(xRange, yRange));
    }
}
