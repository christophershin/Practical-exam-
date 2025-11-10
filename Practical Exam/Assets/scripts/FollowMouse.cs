using UnityEngine;
using UnityEngine.AI;
public class FollowMouse : MonoBehaviour
{


    [SerializeField] private Camera cam;


    private void Start()
    {

    }


    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                transform.position = hit.point;
            }
        }

    }
}
