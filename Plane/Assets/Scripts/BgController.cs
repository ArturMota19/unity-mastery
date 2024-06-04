using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgController : MonoBehaviour
{
    private Renderer bgRenderer;
    private float initialX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        bgRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        initialX += Time.deltaTime * 0.5f;
        bgRenderer.material.mainTextureOffset = new Vector2(initialX, 0);
    }
}
