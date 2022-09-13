using ShowDamage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShowDamage
{
    public class DamagePlayer : ModPlayer 
    {
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            //base.OnHitNPCWithProj(proj, target, damage, knockback, crit);
            float valScaled = 0;
            /*float valBase = 0;
            if (!DamageView.damageSourcesScaled.TryGetValue(proj.Name, out valScaled) && !DamageView.damageSourcesBase.TryGetValue(proj.Name, out valBase))
            {
                DamageView.damageSourcesScaled.Add(proj.Name, valScaled);
                DamageView.damageSourcesBase.Add(proj.Name, valBase);
                DamageView.damageSourcesScaled[proj.Name] = valScaled + damage;
                DamageView.damageSourcesBase[proj.Name] = DamageView.damageSourcesBase[proj.Name] + proj.damage;
            }
            else
            {
                DamageView.damageSourcesScaled[proj.Name] = valScaled + damage;
                DamageView.damageSourcesBase[proj.Name] = DamageView.damageSourcesBase[proj.Name] + proj.damage;
            }
            //base.OnHitNPC(item, player, target, damage, knockBack, crit);
            Main.NewText($"{proj.Name}:{DamageView.damageSourcesScaled[proj.Name]}({DamageView.damageSourcesBase[proj.Name]})");*/

            /*int npcCount = 0;
            foreach(NPC npc in Main.npc)
            {
                if (npc.townNPC)
                    npcCount += 1;
            }
            int c = NPCID.Sets.Skeletons.Count;
            Main.NewText($"{npcCount} {c} {c/npcCount}");*/
            //base.OnHitNPCWithProj(proj, target, damage, knockback, crit);
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            //base.OnHitNPC(item, target, damage, knockback, crit);
            float valScaled = 0;
            float valBase = 0;
            /*if (!DamageView.damageSourcesScaled.TryGetValue(item.Name, out valScaled) && !DamageView.damageSourcesBase.TryGetValue(item.Name, out valBase))
            {
                DamageView.damageSourcesScaled.Add(item.Name, valScaled);
                DamageView.damageSourcesBase.Add(item.Name, valBase);
                DamageView.damageSourcesScaled[item.Name] = valScaled + damage;
                DamageView.damageSourcesBase[item.Name] = DamageView.damageSourcesBase[item.Name] + item.damage;
            }
            else
            {
                DamageView.damageSourcesScaled[item.Name] = valScaled + damage;
                DamageView.damageSourcesBase[item.Name] = DamageView.damageSourcesBase[item.Name] + item.damage;
            }
            //base.OnHitNPC(item, player, target, damage, knockBack, crit);
            Main.NewText($"{item.Name}:{DamageView.damageSourcesScaled[item.Name]}({DamageView.damageSourcesBase[item.Name]})");*/
            //base.OnHitNPC(item, target, damage, knockback, crit);
        }
    }
}
