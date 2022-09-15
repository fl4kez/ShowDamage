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

        [Label("Show base damage")]
        public bool basedChecked = true;

        [Label("Show true damage")]
        public bool scaledChecked = true;

        public override void OnChanged()
        {
            //ShowDamage.DamageView.SetOptions(basedChecked, scaledChecked);
        }
    }
}
