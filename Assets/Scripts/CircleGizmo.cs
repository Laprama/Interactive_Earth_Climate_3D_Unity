using UnityEngine;

/// <summary>
/// Draws a customizable circle gizmo in the Unity Editor scene view.
/// This helps visualize a radius for placing objects.
/// Attach this script to an empty GameObject.
/// </summary>
public class CircleGizmo : MonoBehaviour
{
    [Header("Circle Settings")]
    [Tooltip("The radius of the circle.")]
    [Min(0.1f)]
    public float radius = 2f;

    [Tooltip("The radius of the solid dot at the center.")]
    [Min(0.01f)]
    public float centerDotRadius = 0.1f;

    [Tooltip("The number of line segments to use for drawing the circle. More segments create a smoother circle.")]
    [Range(4, 256)]
    public int segments = 36;

    [Header("Gizmo Appearance")]
    [Tooltip("The color of the gizmo circle.")]
    public Color gizmoColor = Color.cyan;

    /// <summary>
    /// This method is called by Unity whenever gizmos should be drawn.
    /// It only runs in the editor.
    /// We use OnDrawGizmosSelected so the circle only appears when the object is selected.
    /// </summary>
    private void OnDrawGizmos()
    {
        // Set the color for the gizmos that will be drawn next.
        Gizmos.color = gizmoColor;

        // The center of the circle is the position of the GameObject this script is attached to.
        Vector3 center = transform.position;

        // Draw the solid sphere at the center
        Gizmos.DrawSphere(center, centerDotRadius);

        // We need to calculate the position of points on the circle's circumference.
        // We'll draw lines between these points to form the circle.
        Vector3 prevPoint = Vector3.zero;
        Vector3 firstPoint = Vector3.zero;

        for (int i = 0; i <= segments; i++)
        {
            // Calculate the angle for the current segment in radians.
            float angle = i * (2f * Mathf.PI) / segments;

            // Calculate the x and z coordinates for the point on the circle.
            // We use the XZ plane for a circle that lies flat on the "ground".
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            // Create the point in 3D space, relative to the center.
            Vector3 currentPoint = center + new Vector3(x, 0f, z);

            if (i > 0)
            {
                // Draw a line from the previous point to the current point.
                Gizmos.DrawLine(prevPoint, currentPoint);
            }
            else
            {
                // Store the very first point so we can close the circle at the end.
                firstPoint = currentPoint;
            }

            // Update the previous point for the next iteration.
            prevPoint = currentPoint;
        }
    }
}