using UnityEngine;
using System.Collections;

public class SecurityCamera : MonoBehaviour
{

	public string targetTag = "Player";
	public bool idlePan = true;
	public AudioClip cameraPanLoop;
	public AudioClip cameraPanLoopStop;
	public GameObject cameraFrustrum;
	public float panAngleStep = 0.5f;
	public float panDirectionChangeDelay = 20.0f;

	private GameObject theTarget;
	private bool trackingTarget = false;
	private Transform cameraBody;
	private float targetEulerAngleFromMount = 0.0f;
	private float cameraEulerAngleFromMount = 0.0f;
	private Transform myCameraPanBoundsMinTransform;
	private Transform myCameraPanBoundsMaxTransform;
	private float angleFromCameraMountToMinBounds = 0.0f;
	private float angleFromCameraMountToMaxBounds = 0.0f;
	private Transform targetBoundsTransform;
	private bool idlePanTargetBoundsTransformSelected = false;
	private Quaternion cameraPanLoopRotationStep;
	private bool panHasStopped = false;
	private float panDirectionChangeTimer = 0.0f;
	private GameObject myConeFrustrum;
	private bool requireLineOfSight = true;
	private bool hasLineOfSight = false;
	private float previousTargetEulerAngleFromMount = 0.0f;
	private int angleDeltaZeroCount = 0;
	private int maxAngleDeltaZeroCount = 2;
	private GameObject theAlarm;

	void Awake()
	{

		theTarget = GameObject.FindGameObjectWithTag(targetTag);
		cameraBody = transform.Find("Camera");
		myCameraPanBoundsMinTransform = transform.Find("BoundsMin");
		myCameraPanBoundsMaxTransform = transform.Find("BoundsMax");

		cameraPanLoopRotationStep = Quaternion.Euler(new Vector3(0.0f, panAngleStep, 0.0f));

		myConeFrustrum = Instantiate(cameraFrustrum, transform.position, gameObject.transform.rotation) as GameObject;
		myConeFrustrum.transform.parent = cameraBody.transform;

		myConeFrustrum.transform.position += new Vector3(0.0f, -0.28f, 0.0f);

		Quaternion frustrumRotation = Quaternion.Euler(new Vector3(45.0f, 0.0f, 0.0f));
		myConeFrustrum.transform.rotation *= frustrumRotation;

		myConeFrustrum.GetComponent<CameraFrustrum>().setTriggerTag(targetTag);

	}

	void Start()
	{
		Vector3 horizontalRelationToMinBounds = new Vector3(myCameraPanBoundsMinTransform.position.x, transform.position.y, myCameraPanBoundsMinTransform.position.z);
		Vector3 targetDirRelativeToMinBounds = horizontalRelationToMinBounds - transform.position;
		Vector3 forwardRelativeToMinBounds = transform.forward;
		angleFromCameraMountToMinBounds = Vector3.Angle(targetDirRelativeToMinBounds, forwardRelativeToMinBounds);

		Vector3 horizontalRelationToMaxBounds = new Vector3(myCameraPanBoundsMaxTransform.position.x, transform.position.y, myCameraPanBoundsMaxTransform.position.z);
		Vector3 targetDirRelativeToMaxBounds = horizontalRelationToMaxBounds - transform.position;
		Vector3 forwardRelativeToMaxBounds = transform.forward;
		angleFromCameraMountToMaxBounds = Vector3.Angle(targetDirRelativeToMaxBounds, forwardRelativeToMaxBounds);

	}

	void Update()
	{
		trackingTarget = false;
		hasLineOfSight = false;

		if (requireLineOfSight)
		{

			RaycastHit hit;
			Vector3 rayCastDirection = theTarget.transform.position - transform.position;

			if (Physics.Raycast(transform.position, rayCastDirection, out hit))
			{

				if (hit.transform.CompareTag(targetTag))
				{
					hasLineOfSight = true;
				}
				else
				{
					hasLineOfSight = false;
				}

			}

			if (hasLineOfSight && myConeFrustrum.GetComponent<CameraFrustrum>().isTriggered())
			{
				trackingTarget = true;
			}

		}
		else
		{

			if (myConeFrustrum.GetComponent<CameraFrustrum>().isTriggered())
			{
				trackingTarget = true;
			}

		}

		if (trackingTarget)
		{

			if (!panHasStopped)
			{
				panHasStopped = true;
				gameObject.GetComponent<AudioSource>().Stop();
				gameObject.GetComponent<AudioSource>().clip = cameraPanLoopStop;
				gameObject.GetComponent<AudioSource>().loop = false;
				if (!gameObject.GetComponent<AudioSource>().isPlaying)
				{
					gameObject.GetComponent<AudioSource>().Play();
				}
			}

			idlePanTargetBoundsTransformSelected = false;

			Vector3 relativePos = theTarget.transform.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos);
			Quaternion newRotation = Quaternion.Euler(0.0f, rotation.eulerAngles.y, 0.0f);

			Vector3 horizontalRelationToTarget = new Vector3(theTarget.transform.position.x, transform.position.y, theTarget.transform.position.z);
			Vector3 targetDirRelativeToTarget = horizontalRelationToTarget - transform.position;
			Vector3 forwardRelativeToTarget = transform.forward;

			previousTargetEulerAngleFromMount = targetEulerAngleFromMount;
			targetEulerAngleFromMount = Vector3.Angle(targetDirRelativeToTarget, forwardRelativeToTarget);

			if (Mathf.Abs(previousTargetEulerAngleFromMount - targetEulerAngleFromMount) > 0.0f)
			{

				angleDeltaZeroCount = 0;

				gameObject.GetComponent<AudioSource>().clip = cameraPanLoop;
				gameObject.GetComponent<AudioSource>().loop = true;
				if (!gameObject.GetComponent<AudioSource>().isPlaying)
				{
					gameObject.GetComponent<AudioSource>().Play();
				}

			}
			else
			{

				angleDeltaZeroCount++;

				if ((angleDeltaZeroCount > maxAngleDeltaZeroCount) && gameObject.GetComponent<AudioSource>().isPlaying)
				{
					if (gameObject.GetComponent<AudioSource>().clip == cameraPanLoop)
					{
						gameObject.GetComponent<AudioSource>().clip = cameraPanLoopStop;
						gameObject.GetComponent<AudioSource>().loop = false;
						gameObject.GetComponent<AudioSource>().Play();
					}

				}

			}


			float targetDistanceToMinBounds = Vector3.Distance(myCameraPanBoundsMinTransform.position, theTarget.transform.position);
			float targetDistanceToMaxBounds = Vector3.Distance(myCameraPanBoundsMaxTransform.position, theTarget.transform.position);

			if (targetDistanceToMinBounds <= targetDistanceToMaxBounds)
			{

				if (targetEulerAngleFromMount < angleFromCameraMountToMinBounds)
				{
					cameraBody.rotation = newRotation;
				}

			}
			else
			{

				if (targetEulerAngleFromMount < angleFromCameraMountToMaxBounds)
				{
					cameraBody.rotation = newRotation;
				}

			}


		}
		else
		{

			panHasStopped = false;

			if (idlePan)
			{

				cameraEulerAngleFromMount = Quaternion.Angle(transform.rotation, cameraBody.transform.rotation);

				if (!idlePanTargetBoundsTransformSelected)
				{

					if (Mathf.Abs(cameraEulerAngleFromMount - angleFromCameraMountToMinBounds) < Mathf.Abs(cameraEulerAngleFromMount - angleFromCameraMountToMaxBounds))
					{
						targetBoundsTransform = myCameraPanBoundsMinTransform;
						idlePanTargetBoundsTransformSelected = true;
					}
					else
					{
						targetBoundsTransform = myCameraPanBoundsMaxTransform;
						idlePanTargetBoundsTransformSelected = true;
					}

				}

				Vector3 relativePosToTargetBounds = targetBoundsTransform.position - transform.position;
				Quaternion rotationToBounds = Quaternion.LookRotation(relativePosToTargetBounds);
				Quaternion boundsRotation = Quaternion.Euler(0.0f, rotationToBounds.eulerAngles.y, 0.0f);

				if (panDirectionChangeTimer == 0.0f)
				{

					gameObject.GetComponent<AudioSource>().clip = cameraPanLoop;
					gameObject.GetComponent<AudioSource>().loop = true;
					if (!gameObject.GetComponent<AudioSource>().isPlaying)
					{
						gameObject.GetComponent<AudioSource>().Play();
					}

					if (targetBoundsTransform == myCameraPanBoundsMinTransform)
					{
						cameraBody.transform.rotation *= cameraPanLoopRotationStep;
					}
					else
					{
						cameraBody.transform.rotation *= Quaternion.Inverse(cameraPanLoopRotationStep);
					}

				}
				else
				{
					panDirectionChangeTimer -= 1.0f;
				}

				float angleToTargetBounds = Mathf.Abs(boundsRotation.eulerAngles.y - cameraBody.transform.rotation.eulerAngles.y);

				if (angleToTargetBounds < 2.0f && panDirectionChangeTimer == 0)
				{

					panDirectionChangeTimer = panDirectionChangeDelay;

					gameObject.GetComponent<AudioSource>().Stop();
					gameObject.GetComponent<AudioSource>().clip = cameraPanLoopStop;
					gameObject.GetComponent<AudioSource>().loop = false;
					gameObject.GetComponent<AudioSource>().Play();

					if (targetBoundsTransform == myCameraPanBoundsMinTransform)
					{
						targetBoundsTransform = myCameraPanBoundsMaxTransform;
					}
					else
					{
						targetBoundsTransform = myCameraPanBoundsMinTransform;
					}

				}

			}

		}


	}

	public bool currentlyTrackingTarget()
	{
		return trackingTarget;
	}

}
