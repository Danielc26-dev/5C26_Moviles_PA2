using UnityEngine;

public class Blade : MonoBehaviour
{
    public Vector3 direction { get; private set; }

    private Camera mainCamera;

    private Collider sliceCollider;
    private TrailRenderer sliceTrail;

    public float sliceForce = 5f;
    public float minSliceVelocity = 0.01f;

    private bool slicing;

    private void Awake()
    {
        mainCamera = Camera.main;
        sliceCollider = GetComponent<Collider>();
        sliceTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void OnEnable()
    {
        StopSlice();
    }

    private void OnDisable()
    {
        StopSlice();
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0)) {
        //    StartSlice();
        //} else if (Input.GetMouseButtonUp(0)) {
        //    StopSlice();
        //} else if (slicing) {
        //    ContinueSlice();
        //}

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                StartSlice(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                ContinueSlice(touch.position);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                StopSlice();
            }
        }
    }

    private void StartSlice(Vector3 touchPosition)
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(touchPosition);
        position.z = 0f;
        transform.position = position;

        slicing = true;
        sliceCollider.enabled = true;
        sliceTrail.enabled = true;
        sliceTrail.Clear();
    }

    private void StopSlice()
    {
        slicing = false;
        sliceCollider.enabled = false;
        sliceTrail.enabled = false;
    }

    private void ContinueSlice(Vector3 touchPosition)
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(touchPosition);
        newPosition.z = 0f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        sliceCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
    }

}
