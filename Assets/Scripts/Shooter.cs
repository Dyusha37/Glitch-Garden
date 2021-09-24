using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject projectile, gun;
    AtackerSpawner myLineSpawner;
    Animator animator;
    private void Start()
    {
        SetLAneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }


    private void SetLAneSpawner()
    {
        AtackerSpawner[] spawners = FindObjectsOfType<AtackerSpawner>(); 
        foreach(AtackerSpawner spawner in spawners)
        {
            bool isCloseEnought = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnought)
            {
                myLineSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLineSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void Fire()
    {
        Instantiate(projectile,gun.transform.position,Quaternion.identity);
        return;
    }
}
