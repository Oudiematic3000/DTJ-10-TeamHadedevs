using UnityEngine;

public class PlayerBodyAnims : MonoBehaviour
{
    public int roleNum;
    public Body[] IdleBack;
    public Body[] IdleFront;
    public Body[] IdleLeft;
    public Body[] IdleRight;
    private SpriteRenderer spriteRen;

    private void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        RoleOptionForward();
        RoleOptionBack();
    }

    private void RoleOptionForward()
    {
        if (spriteRen.sprite.name.Contains("Stand1"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Stand1", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleFront[roleNum].sprites[spriteNum];
        }
    }

    private void RoleOptionBack()
    {
        if (spriteRen.sprite.name.Contains("Stand2"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Stand2", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleFront[roleNum].sprites[spriteNum];
        }
    }
}

[System.Serializable]
public struct Body
{
    public Sprite[] sprites;
}