using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <Destroyer>
/// Skrypt znajduje sie na obiekcie 'Destroyer' i dziala dokladnie tak samo jak skrypt 'Taker'.
/// Jedyna roznica jest wyslana inna nazwa collidera.
/// Wiecej informacji znajdziesz w skrypcie 'Taker'.
/// </Destroyer>
public class Destroyer : MonoBehaviour
{
    private Transform scale;
    private SwipeDetector swipeSeed;
    void Start()
    {
        scale = gameObject.GetComponent<Image>().transform;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        scale.localScale = new Vector2(1.2f, 1.2f);
        swipeSeed = col.gameObject.GetComponent<SwipeDetector>();
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (scale.localScale.x < 1.1f && scale.localScale.y < 1.1f)
            scale.localScale = new Vector2(1.2f, 1.2f);
        if (!swipeSeed.colliding)
            swipeSeed.colliding = true;
        if (swipeSeed.whichCollider != "Destroyer")
            swipeSeed.whichCollider = "Destroyer";
    }
    void OnCollisionExit2D(Collision2D col)
    {
        scale.localScale = new Vector2(1.0f, 1.0f);
        swipeSeed.colliding = false;
        swipeSeed.whichCollider = "none";
    }
}
