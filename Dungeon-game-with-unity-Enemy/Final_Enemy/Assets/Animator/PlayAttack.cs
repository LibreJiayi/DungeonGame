using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public float intervalTime;
    public float startTime;

    private Animator myAnim;
    private PolygonCollider2D poly2D;

    void Start()
    {
        myAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        poly2D = GetComponent<PolygonCollider2D>();
        
    }

   
    void Update()
    {
        Attack();
    }
    //这下面两个协成的意思还是，当按下Attack时，先触发动画，然后在等待一点时间开始触发hitbox，
    //最后再等待一点时间取消hitbox
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            myAnim.SetTrigger("Attack");
            StartCoroutine(StartHitBox());
        }
    }
    IEnumerator StartHitBox()
    {
        yield return new WaitForSeconds(startTime);
        poly2D.enabled = true;
        StartCoroutine(disableHitBox());
    }
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(intervalTime);
        poly2D.enabled = false;
    }
}