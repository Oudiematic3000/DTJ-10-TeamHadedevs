using UnityEngine;

public class NPCSkin : MonoBehaviour
{
    public int skinNum;
    public Skin[] IdleBack;
    public Skin[] IdleFront;
    public Skin[] IdleLeft;
    public Skin[] IdleRight;
    public Skin[] WalkBack;
    public Skin[] WalkFront;
    public Skin[] WalkLeft;
    public Skin[] WalkRight;
    private SpriteRenderer spriteRen;

    private void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        OptionForward();
        OptionBack();
        OptionLeft();
        OptionRight();
        OptionRightWalk();
        OptionLeftWalk();
        OptionBackWalk();
        OptionForwardWalk();
    }

    private void OptionForward()
    {
        if (spriteRen.sprite.name.Contains("SkinI_1_F"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("SkinI_1_F_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleFront[skinNum].sprites[spriteNum];
        }
    }

    private void OptionBack()
    {
        if (spriteRen.sprite.name.Contains("SkinI_1_B"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("SkinI_1_B_", "");
            int spriteNum = int.Parse(spriteName);
            Debug.Log(spriteNum);

            spriteRen.sprite = IdleBack[skinNum].sprites[spriteNum];
        }
    }

    private void OptionLeft()
    {
        if (spriteRen.sprite.name.Contains("SkinI_1_L"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("SkinI_1_L_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleLeft[skinNum].sprites[spriteNum];
        }
    }

    private void OptionRight()
    {
        if (spriteRen.sprite.name.Contains("SkinI_1_R"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("SkinI_1_R_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleRight[skinNum].sprites[spriteNum];
        }
    }

    private void OptionForwardWalk()
    {
        if (spriteRen.sprite.name.Contains("Skin_1_F"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Skin_1_F_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkFront[skinNum].sprites[spriteNum];
        }
    }

    private void OptionBackWalk()
    {
        if (spriteRen.sprite.name.Contains("Skin_1_B"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Skin_1_B_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkBack[skinNum].sprites[spriteNum];
        }
    }

    private void OptionLeftWalk()
    {
        if (spriteRen.sprite.name.Contains("Skin_1_L"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Skin_1_L_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkLeft[skinNum].sprites[spriteNum];
        }
    }

    private void OptionRightWalk()
    {
        if (spriteRen.sprite.name.Contains("Skin_1_R"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Skin_1_R_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkRight[skinNum].sprites[spriteNum];
        }
    }
}

[System.Serializable]
public struct Skin
{
    public Sprite[] sprites;
}
