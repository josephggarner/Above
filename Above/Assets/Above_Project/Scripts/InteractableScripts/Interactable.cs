using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public InteractableObject interactable;

    void Start() {
        SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        sc.radius *= 3;
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }

    public void Interact() {
        Debug.Log("Interacting with " + interactable.name);
        if (interactable.type == "PickUp") {
            Debug.Log("This item is of type \"PickUp\"");
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

}
