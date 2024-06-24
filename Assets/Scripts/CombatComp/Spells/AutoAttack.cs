namespace CombatComp.Spells
{
    public class AutoAttack : Spell
    {
        public AutoAttack()
        {
            Name = "Auto Attack";
            Description = "Attack the target with weapons.";
            CastTime = 0.0f;
        }

        public override void OnCast()
        {
            Damage damage = new Damage();
            damage.Caster = Caster;
            damage.DamageType = DamageType.Physical;
            damage.Spell = this;
            damage.RawDamage = Caster.mainHandDmg;
        }
    }
}