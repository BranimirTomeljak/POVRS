using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class Wander : MonoBehaviour
{
	public float speed = 5;
	public float directionChangeInterval = 1;
	public float maxHeadingChange = 30;
	public TextAsset txtFile;
	private Transform shoot;

	CharacterController controller;
	float heading;
	int rand;
	Vector3 targetRotation;

	void Awake ()
	{
		controller = GetComponent<CharacterController>();

		// Set random initial rotation
		heading = Random.Range(0, 360);
		rand = Random.Range(0,10);
		Debug.Log(rand);
		string [] pos = txtFile.text.Split('\n');

		string [] field = pos[rand].Split(',');
		Debug.Log("Ovdje");
		Debug.Log(float.Parse(field[0]));
		shoot = GameObject.FindWithTag("Shoot").transform;
		shoot.position = new Vector3(float.Parse(field[3]),float.Parse(field[4]),float.Parse(field[5]));
		transform.position = new Vector3(float.Parse(field[0]),float.Parse(field[1]),float.Parse(field[2]));
		transform.eulerAngles = new Vector3(0, heading, 0);

		StartCoroutine(NewHeading());
	}

	/* private void OnCollisionEnter(Collision collision) {
   		Destroy(collision.gameObject);
	} */

	void Update ()
	{
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * speed);
	}

	/// <summary>
	/// Repeatedly calculates a new direction to move towards.
	/// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
	/// </summary>
	IEnumerator NewHeading ()
	{
		while (true) {
			NewHeadingRoutine();
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}

	/// <summary>
	/// Calculates a new direction to move towards.
	/// </summary>
	void NewHeadingRoutine ()
	{
		var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
		var ceil  = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
		heading = Random.Range(floor, ceil);
		Debug.Log(heading);
		targetRotation = new Vector3(0, heading, 0);
	}
}