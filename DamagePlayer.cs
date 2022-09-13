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
            float valBase = 0;
            if (!ShowDamage.damageSourcesScaled.TryGetValue(proj.Name, out valScaled) && !ShowDamage.damageSourcesBase.TryGetValue(proj.Name, out valBase))
            {
                ShowDamage.damageSourcesScaled.Add(proj.Name, valScaled);
                ShowDamage.damageSourcesBase.Add(proj.Name, valBase);
                ShowDamage.damageSourcesScaled[proj.Name] = valScaled + damage;
                ShowDamage.damageSourcesBase[proj.Name] = ShowDamage.damageSourcesBase[proj.Name] + proj.damage;
            }
            else
            {
                ShowDamage.damageSourcesScaled[proj.Name] = valScaled + damage;
                ShowDamage.damageSourcesBase[proj.Name] = ShowDamage.damageSourcesBase[proj.Name] + proj.damage;
            }
            //base.OnHitNPC(item, player, target, damage, knockBack, crit);
            Main.NewText($"{proj.Name}:{ShowDamage.damageSourcesScaled[proj.Name]}({ShowDamage.damageSourcesBase[proj.Name]})");

            /*int npcCount = 0;
            foreach(NPC npc in Main.npc)
            {
                if (npc.townNPC)
                    npcCount += 1;
            }
            int c = NPCID.Sets.Skeletons.Count;
            Main.NewText($"{npcCount} {c} {c/npcCount}");*/
            
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            //base.OnHitNPC(item, target, damage, knockback, crit);
            float valScaled = 0;
            float valBase = 0;
            if (!ShowDamage.damageSourcesScaled.TryGetValue(item.Name, out valScaled) && !ShowDamage.damageSourcesBase.TryGetValue(item.Name, out valBase))
            {
                ShowDamage.damageSourcesScaled.Add(item.Name, valScaled);
                ShowDamage.damageSourcesBase.Add(item.Name, valBase);
                ShowDamage.damageSourcesScaled[item.Name] = valScaled + damage;
                ShowDamage.damageSourcesBase[item.Name] = ShowDamage.damageSourcesBase[item.Name] + item.damage;
            }
            else
            {
                ShowDamage.damageSourcesScaled[item.Name] = valScaled + damage;
                ShowDamage.damageSourcesBase[item.Name] = ShowDamage.damageSourcesBase[item.Name] + item.damage;
            }
            //base.OnHitNPC(item, player, target, damage, knockBack, crit);
            Main.NewText($"{item.Name}:{ShowDamage.damageSourcesScaled[item.Name]}({ShowDamage.damageSourcesBase[item.Name]})");
        }
    }
}
