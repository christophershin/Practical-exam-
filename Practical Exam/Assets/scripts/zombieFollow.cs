using UnityEngine;
using UnityEngine.AI;

public class zombieFollow : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;

    bool isWalking = true;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        animator.SetFloat("Blend", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {


    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == target)
        {
            isWalking = true;
            agent.destination = target.transform.position;
            animator.SetFloat("Blend", 1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == target)
        {
            isWalking = false;
            animator.SetFloat("Blend", 0.5f);
        }
    }

}
