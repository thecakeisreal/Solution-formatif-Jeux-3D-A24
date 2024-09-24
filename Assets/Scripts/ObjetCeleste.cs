using UnityEngine;

/// <summary>
/// G�re la rotation d'un objet c�leste autour d'un centre
/// </summary>
public class ObjetCeleste : MonoBehaviour
{
    /// <summary>
    /// P�riode de r�volution relative � celle de la Terre
    /// </summary>
    [SerializeField]
    private float periodeRevolution;

    /// <summary>
    /// GameObject autour duquel l'objet tourne
    /// </summary>
    [SerializeField]
    private GameObject centreRotation;

    public void FixedUpdate()
    {
        // Applique la rotation selon la vitesse de la simulation
        transform.RotateAround(centreRotation.transform.position, Vector3.up,
            360.0f / periodeRevolution 
            * Time.deltaTime * ControleurTemps.Instance.RatioTemps);
    }
}
