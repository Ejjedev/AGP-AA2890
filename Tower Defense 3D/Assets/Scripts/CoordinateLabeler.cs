using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColorCoordinates();
        ToggleLabels();
    }

    void ColorCoordinates()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
