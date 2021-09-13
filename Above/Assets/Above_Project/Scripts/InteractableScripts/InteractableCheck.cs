using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class InteractableCheck : MonoBehaviour
{

    Camera cam;
    public GameObject player;
    public TMP_Text interactionText;
    [SerializeField]
    int interactDistance = 1;
      
    void Start() {
        cam = Camera.main;
    }

    void Update() {
        // Retrieve interactable object from raycast
        Interactable interactable = raycast();

        // If an object was found...
        if (interactable != null && interactable.getType() != "Vicinity") {
            // Enable message for user to interact with object
            interactionText.text = interactable.getActionText();
            interactionText.gameObject.SetActive(true);

            // Interact with item if user presses interaction key
            if (Input.GetKeyDown(KeyCode.F)) {
                interactable.Interact();
            }
        } else {
            // If no item is found, ensure text is hidden
            interactionText.gameObject.SetActive(false);
        }
    }

    // Shoots a raycast forward from the player to detect if an interactable object is found
    // Returns a reference to the interactable object found, or null if none are found
    Interactable raycast() {
        RaycastHit hit;
        Vector3 start = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z) + cam.transform.up;
        if (Physics.Raycast(start, (cam.transform.forward * 5), out hit, interactDistance)) {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null) {
                return interactable;
            }
        }
        return null;
    }
}
