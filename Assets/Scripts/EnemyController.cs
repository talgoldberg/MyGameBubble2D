using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public int EnemySpeed;//מהירות האויב
    public Vector2 direction;//כיוון האויב
    Rigidbody2D rb2d;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    void OnTriggerEnter2D(Collider2D other)//פונקצייה לבדיקת טריגרים עבור אובייקט האויב
    {                                    
                                        //בדיקה אם:
        if(other.CompareTag("PointEnd"))// שתי נקודות שמסומנות כטריגר שנמצאות
        {                              //בסוף כל פלטפורמה במידה והאויב מתנגש באחת מהם הוא משנה כיוון
            Flip();
        }

        if(other.CompareTag("Bubble"))//הריסת אובייקט האויב לאחר פגיעה בבועה
        {
            Destroy(this.gameObject);
        }
    }

    void Flip()
    {
        direction = -direction;//שמירת שינוי כיוון הבועה
        Vector2 newScale = transform.localScale;//וקטור חדש על מנת לשנות את כיוון האויב
        newScale.x = newScale.x * -1;//שינוי הכיוון
        transform.localScale = newScale;//משנה את הכיוון של האויב

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(direction.x * EnemySpeed, rb2d.velocity.y);//x-הוספה מהירות לאויב בציר ה 
    }
}
