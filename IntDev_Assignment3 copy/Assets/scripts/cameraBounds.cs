using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBounds : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset;
    public float cameraSpeed = 0.1f;

    public BoxCollider2D bounds;

    Bounds viewBounds;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = player.position + cameraOffset;
        viewBounds = bounds.bounds;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 finalPosition = player.position + cameraOffset;
        Vector3 lerpPosition = Vector3.Lerp(transform.position, finalPosition, cameraSpeed);
        transform.position = lerpPosition;

        Bounds cameraBounds = CameraExtensions.OrthographicBounds(Camera.main);

        Vector2 minimumBoundary = new Vector2(viewBounds.min.x + cameraBounds.size.x / 2, viewBounds.min.y + cameraBounds.size.y / 2);
        Vector2 maximumBoundary = new Vector2(viewBounds.max.x - cameraBounds.size.x / 2, viewBounds.max.y - cameraBounds.size.y / 2);

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, minimumBoundary.x, maximumBoundary.x),
            Mathf.Clamp(transform.position.y, minimumBoundary.y, maximumBoundary.y),
            transform.position.z
            );
    }
}

public static class CameraExtensions
{
    public static Bounds OrthographicBounds(this Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}
