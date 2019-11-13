using UnityEditor;
using UnityEngine;

/// <summary>
/// Manages player rotation based on mouse position.
/// </summary>
/// <remarks>
///	Requires the original player image to face right.
/// </remarks>
public class PlayerRotation : MonoBehaviour
{
    // Sprites for each orientation, can change in the Inspector if needed
    public Sprite face_up;
    public Sprite face_down;
    public Sprite face_right;
    public Sprite face_left;
	private Camera m_MainCamera;

	private void Start()
	{
		m_MainCamera = Camera.main;
	}

	private void Update()
	{
        // Get the child GameObject named "Renderer" and access its SpriteRenderer
        GameObject child = GameObject.Find("Renderer"); 
        SpriteRenderer sprite_renderer = child.GetComponent<SpriteRenderer>();

        // Calculate the angle of the mouse/intended player rotation
        Vector2 mouseDirection = m_MainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float mouseAngle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg; // Bounds: 0 - 180, -180 - 0
        
        // Uncomment to find the current angle of the mouse
        //Debug.Log(mouseAngle);

        // Change the current sprite depending on the angle of the mouse
        if (-45 <= mouseAngle && mouseAngle < 45)
        {
            sprite_renderer.sprite = face_right;
            sprite_renderer.flipX = false;
        }
        else if (45 <= mouseAngle && mouseAngle < 135)
        {
            sprite_renderer.sprite = face_up;
        }
        else if ((135 <= mouseAngle && mouseAngle <= 180) || (-180 <= mouseAngle && mouseAngle < -135))
        {
            sprite_renderer.sprite = face_left;
            sprite_renderer.flipX = true;
        }
        else
        {
            sprite_renderer.sprite = face_down;
        }


	}
}
