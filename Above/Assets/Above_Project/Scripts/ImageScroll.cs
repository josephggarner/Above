using UnityEngine;
using UnityEngine.UI;

public class ImageScroll : MonoBehaviour
{

    private RawImage background;
    public float scrollSpeed;

    private void Start()
    {
        background = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        background.material.mainTextureOffset = new Vector2((Time.time * scrollSpeed)%1,0f);
    }
}
