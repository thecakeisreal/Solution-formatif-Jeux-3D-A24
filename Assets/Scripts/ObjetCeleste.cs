using UnityEngine;

public class ObjetCeleste : MonoBehaviour
{
    [SerializeField]
    private float periodeRevolution;

    [SerializeField]
    private GameObject centreRotation;

    public void FixedUpdate()
    {
        transform.RotateAround(centreRotation.transform.position, Vector3.up, 360.0f / periodeRevolution * Time.deltaTime * ControleurTemps.Instance.RatioTemps);
    }
}
