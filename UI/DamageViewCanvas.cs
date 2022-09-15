using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace ShowDamage.UI
{
    public class DamageViewCanvas : UIState
    {
        //public DamageView damageView;
        public DragableUIPanel uiPanel;
        public UIText tbox;
        public static Dictionary<string,UIText> dict;

        public static bool isVisible;
        public override void OnInitialize()
        {
            uiPanel = new DragableUIPanel();
            uiPanel.SetPadding(0);

            
            uiPanel.Width.Set(200f, 0f);
            uiPanel.Height.Set(300f, 0f);
            uiPanel.Left.Set(Main.miniMapX-Main.miniMapWidth, 0f);
            uiPanel.Top.Set(100f, 0f);
            uiPanel.BackgroundColor = new Color(73, 94, 171);

            /*damageView = new DamageView();
            damageView.Height.Set(400f, 0);
            damageView.Width.Set(150f, 0);
            damageView.Left.Set(0, 0f);
            damageView.Top.Set(0, 0);
            //Append(damageView);
            uiPanel.Append(damageView);*/
            dict = new Dictionary<string, UIText>();

            //tbox = new UIText("Bow - 9 / 13");
            //tbox.Width.Percent = 1;
            //tbox.PaddingTop = 12;
            //tbox.TextScale = 1;

            //dict.Add("Bow,",tbox);

            //uiPanel.Append(tbox);

            Append(uiPanel);
        }

        public void AddEntry(string name, float based, float scaled)
        {
            if (dict.ContainsKey(name))
            {
                string damageValues = dict[name].Text.Split('-')[1];
                float prevBased = int.Parse(damageValues.Split('/')[0]);
                float prevScaled = int.Parse(damageValues.Split('/')[1]);
                dict[name].SetText($"{name}-{based+prevBased}/{scaled+prevScaled}");
            }
            else
            {
                UIText box = new UIText($"{name}-{based}/{scaled}");
                box.Width.Percent = 1;
                box.PaddingTop = 12;
                //tbox.TextScale = 1;
                box.Top.Set(dict.Count * 20, 0);
                dict.Add(name, box);
                uiPanel.Append(box);
            }
        }
    }
}
