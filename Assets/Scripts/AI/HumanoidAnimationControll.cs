using UnityEngine;
using UnityEngine.AI;
public class HumanoidAnimationControll : MonoBehaviour
{
    [SerializeField] private float moveMultiplier;

    [SerializeField] private string horizontalAnimationParameter;
    [SerializeField] private string verticalAnimationParameter;
    [SerializeField] private string animTagParameter;

    private int horID;
    private int vertID;
    private int animID;


    private NavMeshAgent agent;
    private Animator animator;

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
        animator.SetFloat(horID, transform.InverseTransformVector(agent.velocity).x * moveMultiplier);
        animator.SetFloat(vertID, transform.InverseTransformVector(agent.velocity).z * moveMultiplier);
    }
}
