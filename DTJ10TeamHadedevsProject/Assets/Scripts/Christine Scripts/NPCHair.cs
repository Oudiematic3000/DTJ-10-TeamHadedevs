using UnityEngine;

public class NPCHair : MonoBehaviour
{
    public int hairNum;
    public Hair[] IdleBack;
    public Hair[] IdleFront;
    public Hair[] IdleLeft;
    public Hair[] IdleRight;
    public Hair[] WalkBack;
    public Hair[] WalkFront;
    public Hair[] WalkLeft;
    public Hair[] WalkRight;
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
        if (spriteRen.sprite.name.Contains("BlackI_Hair_F"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("BlackI_Hair_F_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleFront[hairNum].sprites[spriteNum];
        }
    }

    private void OptionBack()
    {
        if (spriteRen.sprite.name.Contains("BlackI_Hair_B"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("BlackI_Hair_B_", "");
            int spriteNum = int.Parse(spriteName);
            Debug.Log(spriteNum);

            spriteRen.sprite = IdleBack[hairNum].sprites[spriteNum];
        }
    }

    private void OptionLeft()
    {
        if (spriteRen.sprite.name.Contains("BlackI_Hair_L"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("BlackI_Hair_L_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleLeft[hairNum].sprites[spriteNum];
        }
    }

    private void OptionRight()
    {
        if (spriteRen.sprite.name.Contains("BlackI_Hair_R"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("BlackI_Hair_R_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleRight[hairNum].sprites[spriteNum];
        }
    }

    private void OptionForwardWalk()
    {
        if (spriteRen.sprite.name.Contains("Black_Hair_F"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Black_Hair_F_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkFront[hairNum].sprites[spriteNum];
        }
    }

    private void OptionBackWalk()
    {
        if (spriteRen.sprite.name.Contains("Black_Hair_B"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Black_Hair_B_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkBack[hairNum].sprites[spriteNum];
        }
    }

    private void OptionLeftWalk()
    {
        if (spriteRen.sprite.name.Contains("Black_Hair_L"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Black_Hair_L_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkLeft[hairNum].sprites[spriteNum];
        }
    }

    private void OptionRightWalk()
    {
        if (spriteRen.sprite.name.Contains("Black_Hair_R"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("Black_Hair_R_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkRight[hairNum].sprites[spriteNum];
        }
    }
}

[System.Serializable]
public struct Hair
{
    public Sprite[] sprites;
}
