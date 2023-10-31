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

    private Vector2 startTouch;
    private Vector2 EndTouch;


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

            Vector2 position = Camera.main.ScreenToWorldPoint(touch.position);
            transform.position = position;

            if (touch.phase == TouchPhase.Began)
            {
                startTouch = touch.position;

                RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);

                if (touch.tapCount == 1)
                {
                    slicing = true;
                    sliceCollider.enabled = true;
                    sliceTrail.enabled = true;
                    sliceTrail.Clear();
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                //if (currentObject != null)
                //{
                //    currentObject.transform.position = position;
                //    isDrag = true;
                //}
                //else
                //{
                //    isDrag = false;
                //}
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                EndTouch = touch.position;

                slicing = false;
                sliceCollider.enabled = false;
                sliceTrail.enabled = false;
            }
        }
    }

    private void StartSlice()
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(touch.position);
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

    private void ContinueSlice()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(touch.position);
        newPosition.z = 0f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        sliceCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
    }

}
