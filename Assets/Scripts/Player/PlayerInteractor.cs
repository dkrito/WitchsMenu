using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float maxRayDistance;


    [SerializeField] private Texture2D tex;
    [SerializeField] private ItemName currentName;
    private bool playerCanInteract;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        playerCanInteract = true;
    }

    private void OnEnable()
    {
        InteractionBroker.CameraMovementHandle += ToggleInteract;
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


                //If the ray hits an object, check if its interactable or collectible
                if(Physics.Raycast(ray, out hit, maxRayDistance))
                {
                    if(currentName != ItemName.None)
                    {
                        IChangeable changable;
                        if (hit.transform.TryGetComponent<IChangeable>(out changable))
                        {
                            if (changable.Change(currentName))
                            {
                                print("Successfully added: " + currentName);
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                                currentName = ItemName.None;
                            }
                            else
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                                currentName = ItemName.None;
                            }
                        }
                    }


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

    public void ChangeCursor(Texture2D tex, ItemName name)
    {
        Cursor.SetCursor(tex, Vector2.zero, CursorMode.ForceSoftware);
        currentName = name;
    }
    private void OnDisable()
    {
        InteractionBroker.CameraMovementHandle -= ToggleInteract;
    }

    public void ToggleInteract(bool state)
    {
        print("Can interact: " + playerCanInteract);
        playerCanInteract = !playerCanInteract;

    }
}
