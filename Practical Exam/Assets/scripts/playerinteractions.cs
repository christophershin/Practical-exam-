using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class playerinteractions : MonoBehaviour
{

    Animator animator;
    NavMeshAgent player;


    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Walking", true);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (!player.isOnOffMeshLink)
        {
            Debug.Log("jump");
            animator.SetBool("Jump", true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "gun1")
        {
            Destroy(other.gameObject);
            Debug.Log("picked up gun 1");
            animator.SetBool("PickUp", true);
        }

        if(other.gameObject.name == "gun2")
        {
            Destroy(other.gameObject);
            Debug.Log("picked up gun 2");
            animator.SetBool("PickUp", true);
        }
    }
}
