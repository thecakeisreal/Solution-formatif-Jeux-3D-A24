using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Gère les déplacements de la caméra
/// </summary>
public class ControleurCamera : MonoBehaviour
{
    /// <summary>
    /// Vitesse de déplacement de la caméra
    /// </summary>
    [SerializeField]
    private float vitesseDeplacement;

    /// <summary>
    /// Vitesse pour le zoom de la caméra
    /// </summary>
    [SerializeField]
    private float vitesseZoom;

    /// <summary>
    /// Vitesse de rotation pour changer l'inclinaison
    /// </summary>
    [SerializeField]
    private float vitesseInclinaison;

    /// <summary>
    /// Déplacement saisi aux contrôles
    /// </summary>
    private Vector2 deplacement;

    /// <summary>
    /// Zoom saisi aux contrôles
    /// </summary>
    private float zoom;

    /// <summary>
    /// Inclinaison saisie aux contrôles
    /// </summary>
    private float inclinaison;

    /// <summary>
    /// Action du déplacement.
    /// </summary>
    /// <param name="contexte">Les paramètres de l'action.</param>
    public void Deplacer(InputAction.CallbackContext contexte)
    {
        // On normalise d'abord (important pour les déplacements en diagonal), puis on applique
        // la vitesse
        deplacement = contexte.ReadValue<Vector2>().normalized * vitesseDeplacement;
    }

    /// <summary>
    /// Action du zoom.
    /// </summary>
    /// <param name="contexte">Les paramètres de l'action.</param>
    public void Zoomer(InputAction.CallbackContext contexte)
    {
        // Ici comme on opère sur un axe, les valeurs vont de -1 à 1, donc il n'est pas nécessaire de 
        // normaliser
        zoom = contexte.ReadValue<float>() * vitesseZoom;
    }

    /// <summary>
    /// Action de l'inclinaison.
    /// </summary>
    /// <param name="contexte">Les paramètres de l'action.</param>
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
