using ShowDamage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace ShowDamage
{
    public class ShowDamageConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [ReloadRequired]
        [Label("Show base damage")]
        public bool basedChecked = true;

        [ReloadRequired]
        [Label("Show true damage")]
        public bool scaledChecked = true;

        public override void OnChanged()
        {
            DamageViewCanvas.showBased = basedChecked;
            DamageViewCanvas.showScaled = scaledChecked;
            //ShowDamage.DamageView.SetOptions(basedChecked, scaledChecked);
        }
    }
}
