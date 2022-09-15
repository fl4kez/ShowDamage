using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ShowDamage
{
    public class DamageGlobalProjectile : GlobalProjectile
    {
        public Item myWeapon;
        /*public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            float valScaled = 0;
            float valBase = 0;
            if (!ShowDamage.damageSourcesScaled.TryGetValue(projectile.Name, out valScaled) && !ShowDamage.damageSourcesBase.TryGetValue(projectile.Name, out valBase))
            {
                ShowDamage.damageSourcesScaled.Add(projectile.Name, valScaled);
                ShowDamage.damageSourcesBase.Add(projectile.Name, valBase);
                ShowDamage.damageSourcesScaled[projectile.Name] = valScaled + damage;
                ShowDamage.damageSourcesBase[projectile.Name] = valBase + projectile.damage;
            }
            else
            {
                ShowDamage.damageSourcesScaled[projectile.Name] = valScaled + damage;
                ShowDamage.damageSourcesBase[projectile.Name] = valBase + projectile.damage;
            }
            //base.OnHitNPC(item, player, target, damage, knockBack, crit);
            Main.NewText($"{projectile.Name}:{ShowDamage.damageSourcesScaled[projectile.Name]}({ShowDamage.damageSourcesBase[projectile.Name]})");
        }*/
        public override bool PreAI(Projectile projectile)
        {
            myWeapon = Main.player[projectile.owner].HeldItem;
            return base.PreAI(projectile);
        }
        public override bool InstancePerEntity => true;
    }
}
