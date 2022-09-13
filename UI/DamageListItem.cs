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
        public DamageListItem(Color color, float baseDmg, float scaledDmg)
        {
            this.color = color;
            this.baseDmg = baseDmg;
            this.scaledDmg = scaledDmg;
        }
        /*public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ModContent.GetTexture("Terraria/UI/InnerPanelBackground"), new Vector2(Main.screenWidth - 20, Main.screenHeight - 20) / 2f, color);
        }*/
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
        }
    }
}
