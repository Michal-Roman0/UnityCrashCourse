using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public float Health{
        set{
            if(health > value){
                print("Damaged");
                animator.SetTrigger("Damaged");
            }

            health = value;

            if(health <= 0){
                Defeated();
            }
            
        }
        get{
            return health;
        }
    }
    void Start(){
        animator = GetComponent<Animator>();
    }
    public float health = 1;
    public void Defeated(){ //apart from RemoveEnemy(), so we can First play defeat animation, and then remove
        animator.SetTrigger("Defeated"); //starts defeated animation, which calls RemoveEnemy() at the end
    }
    public void RemoveEnemy(){
        Destroy(gameObject);
    }
}
