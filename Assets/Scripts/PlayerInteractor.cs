using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float maxRayDistance;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                Debug.DrawRay(cam.transform.position, Vector3.forward, Color.red, 10);

                if(Physics.Raycast(ray, out hit, maxRayDistance))
                {
                    IInteractable i;
                    if (hit.transform.TryGetComponent<IInteractable>(out i))
                    {
                        i.Interact();
                    }
                    else
                    {
                        ICollectible c;

                        if(hit.transform.TryGetComponent<ICollectible>(out c))
                        {
                            c.Collect();
                        }
                    }

                }
            }
        }
    }
}
