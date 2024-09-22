using UnityEngine;

/// <summary>
/// Bouton pour quitter la simulation
/// </summary>
public class BoutonQuitter : MonoBehaviour
{
    /// <summary>
    /// Force l'application � quitter
    /// </summary>
    public void QuitterApplication()
    {
        Application.Quit();
    }
}
