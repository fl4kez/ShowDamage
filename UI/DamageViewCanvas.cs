using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.UI;

namespace ShowDamage.UI
{
    public class DamageViewCanvas : UIState
    {
        public DamageView damageView;
        public DragableUIPanel uiPanel;

        public static bool isVisible;
        public override void OnInitialize()
        {
            uiPanel = new DragableUIPanel();
            uiPanel.SetPadding(0);

            uiPanel.Left.Set(400f, 0f);
            uiPanel.Top.Set(100f, 0f);
            uiPanel.Width.Set(200f, 0f);
            uiPanel.Height.Set(500f, 0f);
            uiPanel.BackgroundColor = new Color(73, 94, 171);

            damageView = new DamageView();
            damageView.Height.Set(400f, 0);
            damageView.Width.Set(150f, 0);
            damageView.Left.Set(Main.screenWidth - 50f, 0f);
            damageView.Top.Set(0f, 0);
            //Append(damageView);
            uiPanel.Append(damageView);

            Append(uiPanel);
        }
    }
}
