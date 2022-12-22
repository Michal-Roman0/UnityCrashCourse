using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider; //can be added in inspector, to make sure it's the correct one
    Vector2 rightAttackOffset;
    float damage = 3;
    void Start()
    {
        //swordCollider = GetComponent<Collider2D>(); // it won't find BOXcollider2D, it's better to add it from the UI
        rightAttackOffset = transform.position;
    }
    public void AttackRight()
    {
        swordCollider.enabled = true;
        //transform.Position = rightAttackOffset;
        //^wrong, because we want position relative to the player, not the global coordinates!
        transform.localPosition = rightAttackOffset;
    }
    public void AttackLeft()
    {
        swordCollider.enabled = true;

        transform.localPosition = new Vector2(-rightAttackOffset.x, rightAttackOffset.y);
    }
    public void StopAttack()
    {
        swordCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("HIT " + other.tag);
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null){
                enemy.Health -= damage;
            }
        }
    }
}
