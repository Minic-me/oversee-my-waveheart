using UnityEngine;
using Tobii.EyeTracking;

/// <summary>
/// Changes the color of the game object's material, when the the game object 
/// is in focus of the user's eye-gaze.
/// </summary>
/// <remarks>
/// Referenced by the Target game objects in the Simple Gaze Selection example scene.
/// </remarks>
[RequireComponent(typeof(GazeAware))]
[RequireComponent(typeof(MeshRenderer))]
public class setColor : MonoBehaviour
{

    public Color selectionColor;

    private GazeAware _gazeAwareComponent;
    private MeshRenderer _meshRenderer;

    private Color _color;
    private float _fadeSpeed = 0.1f;

    /// <summary>
    /// Set the lerp color
    /// </summary>
    void Start()
    {
        _gazeAwareComponent = GetComponent<GazeAware>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _color = _meshRenderer.material.color;
    }

    /// <summary>
    /// Lerping the color
    /// </summary>
    void Update()
    {

        if (_meshRenderer.material.color != _color)
        {
            _meshRenderer.material.color = Color.Lerp(_meshRenderer.material.color, _color, _fadeSpeed);
        }

        // Change the color of the cube
        if (_gazeAwareComponent.HasGazeFocus)
        {
            SetLerpColor(selectionColor);
        }
    }

    /// <summary>
    /// Update the color, which should used for the lerping
    /// </summary>
    /// <param name="color"></param>
    public void SetLerpColor(Color newColor)
    {
        this._color = newColor;
    }
}
