using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class playerinteractions : MonoBehaviour
{

    Animator animator;
    NavMeshAgent player;
    public List<GameObject> weapons;

    private bool pickeditem1 = false;
    private bool pickeditem2 = false;

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
            animator.SetBool("PickUp", false);
        }

        if (player.destination.magnitude <= 1)
        {
            animator.SetBool("Walking", false);
        }

        if (pickeditem1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                weapons[0].SetActive(true);
                weapons[0].transform.position = transform.position + transform.forward*1;
            }
        }

        if (pickeditem1)
        {
            if (Input.GetKey(KeyCode.Alpha0))
            {
                weapons[0].SetActive(false);

            }
        }

        if (pickeditem2)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                weapons[1].SetActive(true);
                weapons[1].transform.position = transform.position + transform.forward * 1;
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "gun1")
        {
            pickeditem1 = true;
            other.gameObject.SetActive(false);
            Debug.Log("picked up gun 1");
            animator.SetBool("PickUp", true);
        }

        if(other.gameObject.name == "gun2")
        {
            pickeditem2 = true;
            other.gameObject.SetActive(false);
            Debug.Log("picked up gun 2");
            animator.SetBool("PickUp", true);

            Application.Quit();
            EditorApplication.isPlaying = false;
        }

        if(other.gameObject.CompareTag("jump"))
        {
            Debug.Log("jump");
            animator.SetBool("Jump", true);
        }
    }
}
