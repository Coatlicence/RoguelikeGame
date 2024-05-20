using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAttack : MonoBehaviour
{
    public Animator animator;
    GameObject Weapon;

    // Start is called before the first frame update
    void Start()
    {
        animator=this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("MouseClicked", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("MouseClicked", false);
            //animator.SetBool("SwordAttacked", true);
        }

    }
}
