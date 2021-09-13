using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public InteractableObject interactable;

    void Start() {
        SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        sc.radius *= interactable.interactionRadius;
        sc.isTrigger = true;
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactable.interactionRadius);
    }

    public void Interact() {
        if (interactable.type == "PickUp") {
            // Inventory.instance.Add(item);
            Destroy(gameObject);
        } else {
            Debug.Log("No interaction logic for this type.");
        }
    }

    public string getActionText() {
        string returnString = interactable.name;
        if (interactable.type == "PickUp") {
            return "Pick up " + returnString;
        } else {
            return "Interact with ";
        }
    }

    public string getType() {
        return interactable.type;
    }

    void OnTriggerEnter(Collider collider) {
        if (interactable.type == "Vicinity") {
            switch (interactable.vicinityAction) {
                case "Fire":
                    Debug.Log("OMG this " + interactable.name + " is on fire!!!!!");
                    break;
                default:
                    break;
            }
        }
    }

}
