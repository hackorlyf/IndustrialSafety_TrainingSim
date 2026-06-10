using UnityEngine;
using System.Collections; // Required for Coroutines

public class FloatingCollectible : MonoBehaviour
{
    [Header("Bounce Settings")]
    [Tooltip("How high and low the object will float.")]
    [SerializeField] private float amplitude = 0.25f;
    
    [Tooltip("How fast the object bounces.")]
    [SerializeField] private float frequency = 6f;

    [Header("Rotation Settings")]
    [Tooltip("Rotation speed around each axis (degrees per second).")]
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0f, 45f, 0f);

    [Header("Inspect Settings")]
    [Tooltip("How long the sturdiness shake lasts in seconds.")]
    [SerializeField] private float shakeDuration = 1.0467f;
    
    [Tooltip("How violently the object shakes (degrees).")]
    [SerializeField] private float shakeIntensity = 15f;

    // State & Caching
    private Vector3 _startLocalPos;
    private bool _isInspecting = false;
    
    private void OnEnable(){
        GameEvents.OnInteractBtnClicked += InteractAndInspect;
    }

    private void Start()
    {
        _startLocalPos = transform.localPosition;
    }

    private void Update()
    {
        // Only do the standard float/spin if we aren't actively inspecting it
        if (!_isInspecting)
        {
            AnimateCollectible();
        }
    }

    private void AnimateCollectible()
    {
        // 1. Handle Bouncing
        float bounceOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = new Vector3(_startLocalPos.x, _startLocalPos.y + bounceOffset, _startLocalPos.z);

        // 2. Handle Rotation
        if (rotationSpeed != Vector3.zero)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
        }
    }

    /// <summary>
    /// Call this function from your Player Interaction script!
    /// </summary>
    private void InteractAndInspect()
    {
        // Prevent spam-clicking from running multiple shakes at once
        if (!_isInspecting)
        {
            StartCoroutine(InspectShakeRoutine());
        }
    }

    private IEnumerator InspectShakeRoutine()
    {
        _isInspecting = true;
        
        // Cache the exact rotation at the moment we grabbed it
        Quaternion startRotation = transform.localRotation;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            elapsed += Time.deltaTime;
            
            // 1. Dampen the intensity over time so it settles naturally (Lerp to 0)
            float currentIntensity = Mathf.Lerp(shakeIntensity, 0f, elapsed / shakeDuration);
            
            // 2. Create a rapid back-and-forth shake (50f is the rapid speed)
            float shakeAngle = Mathf.Sin(Time.time * 50f) * currentIntensity;
            
            // 3. Apply the shake to the Z and X axis to simulate tilting a heavy object
            transform.localRotation = startRotation * Quaternion.Euler(shakeAngle, 0f, shakeAngle * 0.5f);
            
            yield return null; // Wait for the next frame
        }

        // Snap back to exactly where it was so the idle animation resumes seamlessly
        transform.localRotation = startRotation;
        _isInspecting = false;
        
        // TODO: Call your actual "Add to Inventory" or UI event here!
        // Debug.Log($"{gameObject.name} inspected and ready to collect!");
    }

    private void OnDisable(){
        GameEvents.OnInteractBtnClicked -= InteractAndInspect;
    }
}