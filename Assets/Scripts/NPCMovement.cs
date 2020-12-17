using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour
{
    public Animator Animal;
    public GameObject Player;
    public Transform[] Positions;
    private Transform target;
    public State currentState = State.Idle;

    public float Movespeed = 2f;
    public float Runspeed = 5f;
    public float Rotationspeed = 200f;
    public float stoppingDistance = .1f;
    public float runningDistance = 5f;
    public float idleTime = 4f;
    public float runTime = 10f;
    Vector3 runDirection;

    public enum State
    {
        Idle, Walk, Run
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        switch (currentState)
        {
            case State.Idle: 
                if (idleTime > 0)
                {
                    Animal.SetBool("Walk", false);
                    Animal.SetBool("Idle", true);
                    Animal.SetBool("Run", false);

                    idleTime -= Time.deltaTime;
                }
                else
                {
                    idleTime = 4f;

                    currentState = State.Walk;
                }
                break;

            case State.Walk: Walk(); break;

            case State.Run: Run(); break;
        }

        if (distance < 10)
        {
            runDirection = transform.position - Player.transform.position;
            runDirection.Scale(new Vector3(1, 0, 1));

            currentState = State.Run;
        }
    }

    void Walk()
    {
        if (target != null)
        {
            Animal.SetBool("Walk", true);
            Animal.SetBool("Idle", false);
            Animal.SetBool("Run", false);

            transform.position = Vector3.MoveTowards(transform.position, target.position, Movespeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(target.position - transform.position), Rotationspeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < stoppingDistance)
            {
                target = null;

                currentState = State.Idle;
            }
        }
        else
        {
            target = Positions[Random.Range(0, Positions.Length)];
        }
    }

    void Run()
    {
        if (runTime > 0)
        {
            Animal.SetBool("Walk", false);
            Animal.SetBool("Idle", false);
            Animal.SetBool("Run", true);

            transform.position += runDirection.normalized * Runspeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(runDirection), Rotationspeed * Time.deltaTime);

            runTime -= Time.deltaTime;
        }
        else
        {
            runTime = 10f;

            currentState = State.Idle;
        }
    }
}

