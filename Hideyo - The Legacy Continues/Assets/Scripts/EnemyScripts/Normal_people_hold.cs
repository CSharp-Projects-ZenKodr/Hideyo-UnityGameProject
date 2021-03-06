﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Normal_people_hold : MonoBehaviour
{
    public Transform player;
    //public AudioSource SwordSlashAudioSource;
    public static bool detekcija = false;
    // public enemy_moving_around skripa;
    NavMeshAgent navMeshAgent;

    private Animator animator;
    float timer = 0.0f;

    void Start()
    {
        // skripa = this.GetComponent<enemy_moving_around>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
    }

    public void isDetected()
    {
        try
        {
            Vector3 direction = player.position - this.transform.position;
            float angle = Vector3.Angle(direction, this.transform.forward);
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (Vector3.Distance(player.position, this.transform.position) < 3 && angle < 180)
            {
                
                direction.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
                if (direction.magnitude >= 0)
                {
                    
                    navMeshAgent.SetDestination(this.transform.position);


                }
               

            }





            navMeshAgent.stoppingDistance = 1;
        }
        catch (System.Exception)
        {


        }

    }
    void Update()
    {
        timer += Time.deltaTime;
        timer %= 60;
        isDetected();

    }

}
