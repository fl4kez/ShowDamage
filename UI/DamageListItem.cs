using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace ShowDamage.UI
{
    public class DamageListItem : UIElement
    {
        Color color;
        public float baseDmg, scaledDmg;
        UIText nameTxt;
        UIText baseTxt;
        UIText scaledTxt;
        public DamageListItem(Color color, float baseDmg, float scaledDmg,string name)
        {
            this.color = color;
            this.baseDmg = baseDmg;
            this.scaledDmg = scaledDmg;

            nameTxt = new UIText(name);
            nameTxt.Left.Set(15, 0);
            Append(nameTxt);

            baseTxt = new UIText(baseDmg.ToString());
            baseTxt.HAlign = 0.5f;
            Append(baseTxt);

            scaledTxt = new UIText(scaledDmg.ToString());
            scaledTxt.Left.Set(100,0);
            Append(scaledTxt);
            
        }
        /*public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ModContent.GetTexture("Terraria/UI/InnerPanelBackground"), new Vector2(Main.screenWidth - 20, Main.screenHeight - 20) / 2f, color);
        }*/
        /*protected override void Draw(SpriteBatch spriteBatch)
        {
            Utils.DrawBorderString(spriteBatch, "ListItem", new Vector2(Main.screenWidth - Parent.Width.Pixels, Main.screenHeight - Parent.Height.Pixels), color);
        }*/
    }
}
