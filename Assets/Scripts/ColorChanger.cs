using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Renderer SetMaterial(Renderer rendererCube)
    {
        rendererCube.material.color = UnityEngine.Random.ColorHSV();

        return rendererCube;
    }
}
