using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleobject : MonoBehaviour
{
    public float max_scale_offset = 1.0f;
    public float speed = 1.0f;

    private float original_scale;
    private void Start()
    {
        original_scale = transform.localScale.y;
    }

    private void Update()
    {
       transform.localScale = Vector3.one * (original_scale + max_scale_offset * Mathf.Sin(Time.time * speed));

    }
}
