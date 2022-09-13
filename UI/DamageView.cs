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
    public class DamageView : UIList
    {
        Color color = new Color(50, 255, 153);
        //public static Dictionary<string, float> damageSourcesScaled = new Dictionary<string, float>();
        //public static Dictionary<string, float> damageSourcesBase = new Dictionary<string, float>();

        public Dictionary<string, DamageListItem> items = new Dictionary<string, DamageListItem>();
        //public List<DamageListItem> items = new List<DamageListItem>();
        public DamageView()
        {
            //Width.Set(100, 0);
            //Height.Set(40, 0);

            //TESTING
            AddListItem("Summon", 57, 70);
        }

        public void AddListItem(string name,float dmgBase, float dmgScaled)
        {
            if (!items.ContainsKey(name))
            {
                //damageSourcesBase.Add(name, dmgBase);
                //damageSourcesScaled.Add(name, dmgScaled);

                DamageListItem item = new DamageListItem(new Color(255, 255, 200),dmgBase,dmgScaled);
                //item.Parent = this;
                item.Height.Set(25f, 0);
                item.Width.Set(300f, 0);
                item.Left.Set(Main.screenWidth - Width.Pixels, 0f);
                item.Top.Set(5f * items.Count+1, 0);
                //items.Add(name, item);

                //Append(item);
                Add(item);
            }
            else
            {
                items[name].baseDmg = dmgBase;
                items[name].scaledDmg = dmgScaled;
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();
            Point point1 = new Point((int)dimensions.X, (int)dimensions.Y);
            int width = (int)Math.Ceiling(dimensions.Width);
            int height = (int)Math.Ceiling(dimensions.Height);
            spriteBatch.Draw(ModContent.GetTexture("ShowDamage/Textures/Blank"), new Rectangle(point1.X, point1.Y, width, height), color);
        }
    }
}
