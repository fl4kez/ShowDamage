using Microsoft.Xna.Framework;
using ShowDamage.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace ShowDamage
{
    public class ShowDamage : Mod
    {
        public static DamageViewCanvas DamageView;
        private UserInterface _damageView;

        int timer = -1;
        public override void Load()
        {
            if (!Main.dedServ)
            {
                DamageView = new DamageViewCanvas();
                DamageView.Activate();
                _damageView = new UserInterface();
                _damageView.SetState(DamageView);
            }
        }
        private GameTime _lastUpdateUiGameTime;

        public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUiGameTime = gameTime;
            if (_damageView?.CurrentState != null)
            {
                _damageView.Update(gameTime);
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "ShowDamage: DPS per source",
                    delegate
                    {
                        //_damageView.Update(Main._drawInterfaceGameTime);
                        _damageView.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
        public override void MidUpdateTimeWorld()
        {
            base.MidUpdateTimeWorld();
            if(DamageView.hitEnemy)
            {
                DamageView.hitEnemy = false;
                timer = 600;
            }
            timer--;
            if(timer == 0)
            {
                DamageView.Reset();
                timer = -1;
            }
        }
    }
}