using UnityEngine;

public class NPCEyes : MonoBehaviour
{
    public int eyeNum;
    
    public Hair[] IdleFront;
    public Hair[] IdleLeft;
    public Hair[] IdleRight;
    
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
        
        OptionLeft();
        OptionRight();
        OptionRightWalk();
        OptionLeftWalk();
        
        OptionForwardWalk();
    }

    private void OptionForward()
    {
        if (spriteRen.sprite.name.Contains("GreenEyeI_F"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("GreenEyeI_F_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleFront[eyeNum].sprites[spriteNum];
        }
    }

    

    private void OptionLeft()
    {
        if (spriteRen.sprite.name.Contains("GreenEyeI_L"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("GreenEyeI_L_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleLeft[eyeNum].sprites[spriteNum];
        }
    }

    private void OptionRight()
    {
        if (spriteRen.sprite.name.Contains("GreenEyeI_R"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("GreenEyeI_R_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = IdleRight[eyeNum].sprites[spriteNum];
        }
    }

    private void OptionForwardWalk()
    {
        if (spriteRen.sprite.name.Contains("GreenEye_F"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("GreenEye_F_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkFront[eyeNum].sprites[spriteNum];
        }
    }

    

    private void OptionLeftWalk()
    {
        if (spriteRen.sprite.name.Contains("GreenEye_L"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("GreenEye_L_", "");
            int spriteNum = int.Parse(spriteName);

            Debug.Log(spriteNum);

            spriteRen.sprite = WalkLeft[eyeNum].sprites[spriteNum];
        }
    }

    private void OptionRightWalk()
    {
        if (spriteRen.sprite.name.Contains("GreenEye_R"))
        {
            string spriteName = spriteRen.sprite.name;
            spriteName = spriteName.Replace("GreenEye_R_", "");
            int spriteNum = int.Parse(spriteName);

            spriteRen.sprite = WalkRight[eyeNum].sprites[spriteNum];
        }
    }
}

[System.Serializable]
public struct Eyes
{
    public Sprite[] sprites;
}
