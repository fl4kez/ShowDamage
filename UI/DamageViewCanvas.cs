﻿using Microsoft.Xna.Framework;
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
    public class DamageViewCanvas : UIState
    {
        //public DamageView damageView;
        public DragableUIPanel uiPanel;
        public UIImageButton resetBtn;
        public UIText sumDmg;
        public float sumDmgValue = 0;
        public static Dictionary<string,UIText> dict;

        public static bool isVisible = true;

        public static bool showBased, showScaled;
        public bool hitEnemy;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //Main.NewText(Main.frameRate);
            /*if (timer > 0)
                timer--;
            if (timer == 0)
            {
                Reset();
                timer = -1;
            }*/
        }
        private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            Reset();
        }
        public override void OnInitialize()
        {

            uiPanel = new DragableUIPanel();
            uiPanel.SetPadding(0);

            
            uiPanel.Width.Set(200f, 0f);
            uiPanel.Height.Set(20, 0f);
            uiPanel.Left.Set(Main.miniMapX-Main.miniMapWidth, 0f);
            uiPanel.Top.Set(100f, 0f);
            uiPanel.BackgroundColor = new Color(73, 94, 171);

            resetBtn = new UIImageButton(ModContent.GetTexture("Terraria/UI/ButtonDelete"));
            resetBtn.Left.Set(uiPanel.Width.Pixels-resetBtn.Width.Pixels, 0);
            resetBtn.Top.Set(0, 0);
            resetBtn.OnClick += OnButtonClick;
            uiPanel.Append(resetBtn);

            sumDmg = new UIText("Total Damage");
            sumDmg.HAlign = 0.5f;
            sumDmg.Top.Set(0, 0);
            sumDmg.Width.Set(0, 0.9f);

            uiPanel.Append(sumDmg);
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

        public void Reset()
        {
            Main.NewText("RESET");
            sumDmg.SetText("Total Damage");
            sumDmgValue = 0;
            foreach (UIText item in dict.Values)
            {
                if(item != sumDmg)
                    uiPanel.RemoveChild(item);
            }
            dict = new Dictionary<string, UIText>();
            uiPanel.Height.Set(20, 0f);
            //uiPanel.RemoveAllChildren();
        }

        public void SetOptions(bool based,bool scaled)
        {
            showBased = based;
            showScaled = scaled;
        }
        public void AddEntry(string name, float based, float scaled,Color color)
        {
            //timer = 60*10;
            hitEnemy = true;
            if (dict.ContainsKey(name))
            {
                string[] split = dict[name].Text.Split('/');
                float prevBased, prevScaled;
                
                string outputString = "";
                if (showBased && showScaled)
                {
                    prevBased = int.Parse(split[1]);
                    prevScaled = int.Parse(split[2]);
                    outputString = $"{name}/{based + prevBased}/{scaled + prevScaled}";
                }
                else if (showBased)
                {
                    prevBased = int.Parse(split[1]);
                    outputString = $"{name}/{based + prevBased}";
                }
                else if (showScaled)
                {
                    prevScaled = int.Parse(split[1]);
                    outputString = $"{name}/{scaled + prevScaled}";
                }

                dict[name].SetText(outputString);
            }
            else
            {
                string outputString = $"";
                if (showBased && showScaled)
                {
                    outputString = $"{name}/{based}/{scaled}";
                }
                else if (showBased)
                    outputString = $"{name}/{based}";
                else if (showScaled)
                    outputString = $"{name}/{scaled}";
                UIText box = new UIText(outputString);
                box.TextColor = color;
                box.Width.Percent = 1;
                box.PaddingTop = 12;
                //tbox.TextScale = 1;
                box.Top.Set(dict.Count * 20, 0);
                dict.Add(name, box);
                uiPanel.Append(box);
                uiPanel.Height.Set(20 + (dict.Count * 20), 0);
            }
            sumDmgValue += scaled;
            sumDmg.SetText($"Total: {sumDmgValue}");
        }
    }
}
