using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HumanoidAnimationControll : MonoBehaviour
{
    [SerializeField] float moveMultiplier;
    [SerializeField] string horizontalAnimationParameter;
    [SerializeField] string verticalAnimationParameter;
    [SerializeField] string animTagParameter;

    int horID;
    int vertID;
    int animID;


    NavMeshAgent agent;
    Animator animator;

    public void PlayAnimation(int num)
    {
        animator.SetInteger(animID, num);
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        horID = Animator.StringToHash(horizontalAnimationParameter);
        vertID = Animator.StringToHash(verticalAnimationParameter);
        animID = Animator.StringToHash(animTagParameter);
    }


    private void Update()
    {
        Debug.DrawRay(transform.position, agent.velocity);
        animator.SetFloat(horID, transform.InverseTransformVector(agent.velocity).x*moveMultiplier);
        animator.SetFloat(vertID, transform.InverseTransformVector(agent.velocity).z*moveMultiplier);

    }


}
