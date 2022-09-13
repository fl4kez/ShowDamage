using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ShowDamage
{
	public class ShowDamage : Mod
	{
		public static Dictionary<string,float> damageSourcesScaled = new Dictionary<string, float>();
		public static Dictionary<string, float> damageSourcesBase = new Dictionary<string, float>();

	}
}