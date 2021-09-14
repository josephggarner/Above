using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable" , menuName = "Scriptable/Interactable")]
public class InteractableObject : ScriptableObject {

    public new string name;
    public string type;
    public float interactionRadius = 3f;
    public string vicinityAction;
    public bool isOpen = false;
    
}
