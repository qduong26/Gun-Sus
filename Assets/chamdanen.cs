
using UnityEngine;

public class chamdanen : MonoBehaviour
{
    // Start is called before the first frame update
    public float hitForce = 0.5f;
   
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        botban Ban = new botban();
        int myDamage = Ban.damageAmount;
        if (other.gameObject.tag == "Bullet1")
        {

            Maupl PLHealth = GetComponent<Maupl>();
            if (PLHealth != null)
            {
                PLHealth.TakeDamage(myDamage);
            }


          
           Destroy(other.gameObject);

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 hitDirection = (transform.position - other.transform.position).normalized;
            
            rb.AddForce(hitDirection * hitForce, ForceMode2D.Impulse);
        }
        
    }
    
}
