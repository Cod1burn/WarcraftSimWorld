namespace CombatComp.Spells
{
    public class OffhandAttack : Spell
    {
        public OffhandAttack()
        {
            Name = "Offhand Attack";
            Description = "Attack the target with offhand weapon.";
            CastTime = 0.0f;
            SpellID = 2;
        }

        public override void OnCast()
        {
            Damage damage = new Damage();
            damage.Caster = Caster;
            damage.DamageType = DamageType.Physical;
            damage.Spell = this;
            damage.RawDamage = Caster.offHandDmg;
        }
    }
}