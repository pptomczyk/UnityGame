using UnityEngine;

public class InteractionObjectAnimation : MonoBehaviour
{
  public SpriteRenderer spriteRenderer;
  public Sprite[] sprites;
  public int animationFrame;

  private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        animationFrame = 0;
    }

  public void Using()
  {
    this.animationFrame++;
    this.spriteRenderer.sprite = this.sprites[this.animationFrame];
  }

    public void StopUsing()
  {
    this.animationFrame--;
    this.spriteRenderer.sprite = this.sprites[this.animationFrame];
  }

  private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
            Using();
        }
    }
  
  private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
            StopUsing();
        }
    }
}
