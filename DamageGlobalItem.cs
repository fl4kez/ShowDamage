using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ShowDamage
{
    public class DamageGlobalItem : GlobalItem 
    {
        /*public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
            float valScaled = 0;
            float valBase = 0;
            if (!ShowDamage.damageSourcesScaled.TryGetValue(item.Name, out valScaled) && !ShowDamage.damageSourcesBase.TryGetValue(item.Name, out valBase))
            {
                ShowDamage.damageSourcesScaled.Add(item.Name, valScaled);
                ShowDamage.damageSourcesBase.Add(item.Name, valBase);
                ShowDamage.damageSourcesScaled[item.Name] = valScaled + damage;
                ShowDamage.damageSourcesBase[item.Name] = valBase + item.damage;
            }
            else
            {
                ShowDamage.damageSourcesScaled[item.Name] = valScaled + damage;
                ShowDamage.damageSourcesBase[item.Name] = valBase + item.damage;
            }
            //base.OnHitNPC(item, player, target, damage, knockBack, crit);
            Main.NewText($"{item.Name}:{ShowDamage.damageSourcesScaled[item.Name]}({ShowDamage.damageSourcesBase[item.Name]})");
        }*/
    }

}
