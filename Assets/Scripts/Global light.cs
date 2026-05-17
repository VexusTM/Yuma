using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class Globallight : MonoBehaviour
{
    public Color blue=new Color(44,44,84,255);
    public Light2D light;
    public Color white = Color.white;
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void ChangeLight()
    {
        if(light.color==blue)
        {
            StartCoroutine(black2());
        }
        else if(light.color==white)
        {
            StartCoroutine(black1());
        }
    }
    private IEnumerator black1()
    {
        Color color = spriteRenderer.color;

        // Start invisible
        color.a = 0;
        spriteRenderer.color = color;

        // Fade in
        while (color.a < 1)
        {
            color.a += Time.deltaTime;
            spriteRenderer.color = color;

            yield return null;
        }

        // Optional pause
        yield return new WaitForSeconds(0.5f);
        light.color = blue;
        yield return new WaitForSeconds(0.5f);

        // Fade out
        while (color.a > 0)
        {
            color.a -= Time.deltaTime;
            spriteRenderer.color = color;

            yield return null;
        }
    }
    private IEnumerator black2()
    {
        Color color = spriteRenderer.color;

        // Start invisible
        color.a = 0;
        spriteRenderer.color = color;

        // Fade in
        while (color.a < 1)
        {
            color.a += Time.deltaTime;
            spriteRenderer.color = color;

            yield return null;
        }

        // Optional pause
        yield return new WaitForSeconds(0.5f);
        light.color = white;
        yield return new WaitForSeconds(0.5f);

        // Fade out
        while (color.a > 0)
        {
            color.a -= Time.deltaTime;
            spriteRenderer.color = color;

            yield return null;
        }
    }
}
