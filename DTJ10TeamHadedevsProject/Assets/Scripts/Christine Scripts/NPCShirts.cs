using UnityEngine;

public class NPCShirts : MonoBehaviour
{
    public int shirtNum;
    public Shirt[] IdleBack;
    public Shirt[] IdleFront;
    public Shirt[] IdleLeft;
    public Shirt[] IdleRight;
    public Shirt[] WalkBack;
    public Shirt[] WalkFront;
    public Shirt[] WalkLeft;
    public Shirt[] WalkRight;
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
        if (spriteRen.sprite.name.Contains("RedI_F"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("RedI_F_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleFront[shirtNum].sprites[spriteNum];
        }
    }

    private void OptionBack()
    {
        if (spriteRen.sprite.name.Contains("RedI_B"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("RedI_B_", "");
            int spriteNum = int.Parse(spriteName);
            Debug.Log(spriteNum);

            spriteRen.sprite = IdleBack[shirtNum].sprites[spriteNum];
        }
    }

    private void OptionLeft()
    {
        if (spriteRen.sprite.name.Contains("RedI_L"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("RedI_L_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleLeft[shirtNum].sprites[spriteNum];
        }
    }

    private void OptionRight()
    {
        if (spriteRen.sprite.name.Contains("RedI_R"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("RedI_R_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleRight[shirtNum].sprites[spriteNum];
        }
    }

    private void OptionForwardWalk()
    {
        if (spriteRen.sprite.name.Contains("Red_F"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Red_F_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkFront[shirtNum].sprites[spriteNum];
        }
    }

    private void OptionBackWalk()
    {
        if (spriteRen.sprite.name.Contains("Red_B"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Red_B_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkBack[shirtNum].sprites[spriteNum];
        }
    }

    private void OptionLeftWalk()
    {
        if (spriteRen.sprite.name.Contains("Red_L"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Red_L_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkLeft[shirtNum].sprites[spriteNum];
        }
    }

    private void OptionRightWalk()
    {
        if (spriteRen.sprite.name.Contains("Red_R"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Red_R_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkRight[shirtNum].sprites[spriteNum];
        }
    }
}

[System.Serializable]
public struct Shirt
{
    public Sprite[] sprites;
}
