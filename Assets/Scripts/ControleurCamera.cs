using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// G�re les d�placements de la cam�ra
/// </summary>
public class ControleurCamera : MonoBehaviour
{
    /// <summary>
    /// Vitesse de d�placement de la cam�ra
    /// </summary>
    [SerializeField]
    private float vitesseDeplacement;

    /// <summary>
    /// Vitesse pour le zoom de la cam�ra
    /// </summary>
    [SerializeField]
    private float vitesseZoom;

    /// <summary>
    /// Vitesse de rotation pour changer l'inclinaison
    /// </summary>
    [SerializeField]
    private float vitesseInclinaison;

    /// <summary>
    /// D�placement saisi aux contr�les
    /// </summary>
    private Vector2 deplacement;

    /// <summary>
    /// Zoom saisi aux contr�les
    /// </summary>
    private float zoom;

    /// <summary>
    /// Inclinaison saisie aux contr�les
    /// </summary>
    private float inclinaison;

    /// <summary>
    /// Action du d�placement.
    /// </summary>
    /// <param name="contexte">Les param�tres de l'action.</param>
    public void Deplacer(InputAction.CallbackContext contexte)
    {
        // On normalise d'abord (important pour les d�placements en diagonal), puis on applique
        // la vitesse
        deplacement = contexte.ReadValue<Vector2>().normalized * vitesseDeplacement;
    }

    /// <summary>
    /// Action du zoom.
    /// </summary>
    /// <param name="contexte">Les param�tres de l'action.</param>
    public void Zoomer(InputAction.CallbackContext contexte)
    {
        // Ici comme on op�re sur un axe, les valeurs vont de -1 � 1, donc il n'est pas n�cessaire de 
        // normaliser
        zoom = contexte.ReadValue<float>() * vitesseZoom;
    }

    /// <summary>
    /// Action de l'inclinaison.
    /// </summary>
    /// <param name="contexte">Les param�tres de l'action.</param>
    public void Incliner(InputAction.CallbackContext contexte)
    {
        inclinaison = contexte.ReadValue<float>() * vitesseInclinaison;
    }

    private void FixedUpdate()
    {
        // Application des changements
        transform.transform.position += new Vector3(deplacement.x, 0.0f, deplacement.y) * Time.deltaTime;
        transform.transform.position += Time.deltaTime * zoom * transform.forward;
        transform.transform.Rotate(Vector3.right, inclinaison * Time.deltaTime);
    }

}
