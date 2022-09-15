using Microsoft.Xna.Framework;
using ShowDamage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShowDamage
{
    public class DamagePlayer : ModPlayer 
    {
        Dictionary<string, Color> colors = new Dictionary<string, Color>();
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            //base.OnHitNPCWithProj(proj, target, damage, knockback, crit);
            //float valScaled = 0;
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
            float valScaled = damage;
            float valBase = proj.damage;
            //Main.NewText($"B:{valBase} S:{valScaled}");e
            Item wep = proj.GetGlobalProjectile<DamageGlobalProjectile>().myWeapon;
            Color cl = ItemRarity.GetColor(wep.rare);
            if (wep.rare == ItemRarityID.Red)
                cl = Color.Red;
            ShowDamage.DamageView.AddEntry(proj.Name, valBase, valScaled, cl);
            //Main.NewText($"{proj.GetGlobalProjectile<DamageGlobalProjectile>().GetMyWep().Name}");
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            //Main.NewText(Main.projectile[item.shoot].Name);
            //base.OnHitNPC(item, target, damage, knockback, crit);
            if (item.melee == true)
            {
                float valScaled = damage;
                float valBase = player.GetWeaponDamage(item);
                //Main.NewText($"B:{valBase} S:{valScaled}");

                ShowDamage.DamageView.AddEntry(item.Name, valBase, valScaled, ItemRarity.GetColor(item.rare));
            }
            //base.OnHitNPC(item, target, damage, knockback, crit);
           
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
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            base.ProcessTriggers(triggersSet);
           
            if(ShowDamage.toggleUI.JustPressed)
            {
                ModContent.GetInstance<ShowDamage>().ToggleUI();
            }
        }
    }
}
