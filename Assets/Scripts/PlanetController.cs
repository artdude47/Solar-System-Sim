
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [Tooltip("Celestial body this planet orbits")]
    public Transform orbitTarget;

    [Tooltip("Rotation duration in Earth days")]
    public float rotationPeriodInEarthDays = 1.0f;

    [Tooltip("Orbit duration in Earth days")]
    public float orbitPeriodInEarthDays = 365.25f;

    private float rotationSpeed;
    private float orbitSpeed;

    private void Start()
    {
        if (DayLengthController.instance == null)
        {
            Debug.LogError("Could not find DayLengthController!");
            return;
        }

        rotationSpeed = 360.0f / (rotationPeriodInEarthDays * DayLengthController.instance.earthDayInSeconds);
        orbitSpeed = 360.0f / (orbitPeriodInEarthDays * DayLengthController.instance.earthDayInSeconds);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        if (orbitTarget != null)
            transform.RotateAround(orbitTarget.position, Vector3.up, orbitSpeed * Time.deltaTime);
        else
        {
            Debug.LogWarning("No orbit target for " + gameObject.name);
        }
    }
}
