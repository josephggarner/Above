using UnityEngine;
// {requires component (BoxCollider)}

public class Interactable : MonoBehaviour {
    public float radius = 3f;
    public string nameOfInteractable;

    void Start() {
        nameOfInteractable = this.gameObject.name;
        SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        sc.radius *= 3;
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact() {
        Debug.Log("Interacting with " + nameOfInteractable);
    }
}