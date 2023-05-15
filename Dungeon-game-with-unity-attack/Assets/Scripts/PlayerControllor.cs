using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{

    Rigidbody2D rb;

    Animator anim;

    public float speed;

    public float timeBetweenAttacks;
    float nextAttackTime;

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemylayer;

    public int damage;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextAttackTime)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D [] enemiesToDamage = Physics2D.OverlapCircleALL(attackPoint.position, attackRange, enemylayer);
                foreach (Collider2D col in enemiesToDamage)
                {
                    col.GetComponent<Enemy>().TakeDamge(damage);
                }

                anim.SetTrigger("attack");
                nextAttackTime = Time.time + timeBetweenAttacks;
            }
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
         if (movement.x != 0)
        {
            transform.localScale = new Vector3(movement.x, 1, 1);
        }
        SwitchAnim();
    }

      private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void SwitchAnim()
    {
        anim.SetFloat("speed", movement.magnitude);
    }

    public void Attack() {
        Collider2D [] enemiesToDamage = Physics2D.OverlapCircleALL(attackPoint.position, attackRange, enemylayer);
        foreach (Collider2D col in enemiesToDamage)
        {
            col.GetComponent<Enemy>().TakeDamge(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color .red;
        Gizmos.DrawWireSpher(attackPoint.position, attackRange);
    }
}
