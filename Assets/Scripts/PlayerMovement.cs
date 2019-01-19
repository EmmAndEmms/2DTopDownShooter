﻿using Boo.Lang;
using UnityEngine;
using UnityEngineInternal.Input;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 15.0f;
	public bool smooth;

	/// <summary>
	/// If movement is set to `relative`, player movement would be based on the character's rotation instead of absolute directions.
	/// </summary>
	public bool relative;

	// Update is called once per frame
	private void Update()
	{
		Vector3 input = smooth
			? new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))
			: new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if (input.magnitude > 1) input.Normalize();

		if (relative) input = transform.TransformVector(new Vector2(input.y, -input.x));

		transform.position += input * speed * Time.deltaTime;
	}
}