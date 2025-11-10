using UnityEngine;
using UnityEngine.AI;
public class Controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject target;
    private NavMeshAgent agent;

    bool isWalking = true;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isWalking)
        {
            agent.destination = target.transform.position;
            //transform.LookAt(target.transform.position);
        }
        else
        {
            agent.destination = transform.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Dragon")
        {
            isWalking = false;
            animator.SetTrigger("ATTACK");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Dragon")
        {
            isWalking = true;
            animator.SetTrigger("WALK");
        }
    }
}