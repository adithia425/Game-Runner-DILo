using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl insPlayerControl;


    [Header("Profile")]
    [SerializeReference]
    private float hitPoint;
    [SerializeReference]
    private float moveSpeed;
    [SerializeReference]
    private float damageAttack;
    [SerializeReference]
    private float jumpForce;


    [Header("Attack")]
    public bool isAttacking;


    [Header("Secondary")]
    Rigidbody2D rB;
    public Animator anim;


    private void Awake()
    {

        insPlayerControl = this;
    }
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
        JumpControl();
    }

    void JumpControl()
    {
        if(Input.GetButtonDown("Jump"))
        {
            anim.Play("PlayerJump");
            rB.AddForce(new Vector2(rB.velocity.x, jumpForce));
        }
    }

    private void FixedUpdate()
    {
        MoveControl();
    }

    void MoveControl()
    {
        float moveDirect = Input.GetAxis("Horizontal");

        if (moveDirect == 0)
            anim.SetBool("Walk", false);
        else
        {
            anim.SetBool("Walk", true);

            if (moveDirect < 0)
                transform.eulerAngles = new Vector3(0, 180, 0);
            else if (moveDirect > 0)
                transform.eulerAngles = Vector3.zero;
        }

        rB.velocity = new Vector2(moveDirect * moveSpeed * Time.deltaTime, rB.velocity.y);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isAttacking)
            isAttacking = true;
    }

    public void ModeRun()
    {
        anim.SetBool("Run", true);
    }
    public void ModeFight()
    {
        anim.SetBool("Run", false);
    }



    //Getter and Setter
    //Hit Point
    public float GetHitPoint()
    {
        return hitPoint;
    }
    public void SetHitPoint(float hitPoint)
    {
        this.hitPoint -= hitPoint;
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
}
