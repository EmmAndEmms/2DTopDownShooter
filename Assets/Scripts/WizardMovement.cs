using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovement : MonoBehaviour
{
	public float speed = 15.0f;
	public bool smooth;
    private Vector3 input;

    /// <summary>
	/// If movement is set to `relative`, player movement would be based on the character's rotation instead of absolute directions.
	/// </summary>
	public bool relative;

    private Animator anim;

    void Start(){
        anim = GetComponent<Animator>();

    }

	// Update is called once per frame
	private void FixedUpdate()
	{
        // if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        // {
        //     transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal")* speed * Time.deltaTime, 0.0f, 0.0f));
        // }

        // if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        // {
        //     transform.Translate (new Vector3(Input.GetAxisRaw("Vertical")* speed * Time.deltaTime, 0.0f, 0.0f));
        // }


        if (smooth)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        //One line version of the above code: Vector3 input = smooth ? new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) : new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input.magnitude > 1)
        {
            input.Normalize();
        }

		if (relative)
        {
            input = transform.TransformVector(new Vector2(input.y, -input.x));
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Vertical"));

        //anim.SetFloat("MoveY", Input.GetAxisRaw("Horizontal"));

		transform.position += input * speed * Time.deltaTime;

        
	}
}
