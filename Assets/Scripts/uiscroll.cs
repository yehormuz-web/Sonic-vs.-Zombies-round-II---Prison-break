using UnityEngine;
using UnityEngine.UI;

public class uiscroll : MonoBehaviour
{
    public RawImage coverimage;
    public float scrollspeed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coverimage.uvRect = new Rect(
            coverimage.uvRect.position.x- (scrollspeed * Time.deltaTime), coverimage.uvRect.position.y,
            coverimage.uvRect.width, coverimage.uvRect.height);

    }
}
