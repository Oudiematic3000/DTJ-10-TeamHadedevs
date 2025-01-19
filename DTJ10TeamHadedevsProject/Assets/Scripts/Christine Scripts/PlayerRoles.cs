using UnityEngine;

public class PlayerRoles : MonoBehaviour
{
    public int roleNum;
    public Role[] IdleBack;
    public Role[] IdleFront;
    public Role[] IdleLeft;
    public Role[] IdleRight;
    private SpriteRenderer spriteRen;

    private void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        RoleOptionForward();
        RoleOptionBack();
        RoleOptionLeft();
        RoleOptionRight();
    }

    private void RoleOptionForward()
    {
        if (spriteRen.sprite.name.Contains("Idle_Forward_Role_1"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Idle_Forward_Role_1_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleFront[roleNum].sprites[spriteNum];
        }
    }

    private void RoleOptionBack()
    {
        if (spriteRen.sprite.name.Contains("Idle_Back_Role_1"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Idle_Back_Role_1_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleBack[roleNum].sprites[spriteNum];
        }
    }

    private void RoleOptionLeft()
    {
        if (spriteRen.sprite.name.Contains("Idle_Left_Role_1"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Idle_Left_Role_1_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleLeft[roleNum].sprites[spriteNum];
        }
    }

    private void RoleOptionRight()
    {
        if (spriteRen.sprite.name.Contains("Idle_Right_Role_1"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Idle_Right_Role_1_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleRight[roleNum].sprites[spriteNum];
        }
    }
}

[System.Serializable]
public struct Role
{
    public Sprite[] sprites;
}
