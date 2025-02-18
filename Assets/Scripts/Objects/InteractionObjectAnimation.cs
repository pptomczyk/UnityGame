using UnityEngine;

public class InteractionObjectAnimation : MonoBehaviour
{
  public SpriteRenderer spriteRenderer;
  public Sprite[] sprites;
  public GameObject notification;
  public int animationFrame;

  private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        animationFrame = 0;
    }

  public void CanUse()
  {
    //this.animationFrame++;
    //this.spriteRenderer.sprite = this.sprites[this.animationFrame];
    notification.SetActive(true);
  }

    public void CantUse()
  {
    //this.animationFrame--;
    //this.spriteRenderer.sprite = this.sprites[this.animationFrame];
    notification.SetActive(false);
  }

  private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Interaction")){
            CanUse();
        }
    }
  
  private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Interaction")){
            CantUse();
        }
    }
}
