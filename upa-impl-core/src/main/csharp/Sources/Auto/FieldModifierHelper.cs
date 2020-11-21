/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/15/12 7:35 PM
     */
    internal class FieldModifierHelper {

        internal Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> modifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.FieldModifier>();

        internal Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> positiveModifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.UserFieldModifier>();

        internal Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> negativeModifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.UserFieldModifier>();

        public FieldModifierHelper(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> positive, Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> negative) {
            if (positive != null) {
                this.positiveModifiers = this.positiveModifiers.AddAll(positive);
            }
            if (negative != null) {
                this.negativeModifiers = this.negativeModifiers.AddAll(negative);
            }
        }

        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetPositive() {
            return positiveModifiers;
        }

        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetNegative() {
            return positiveModifiers;
        }

        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> GetEffective() {
            return modifiers;
        }

        public virtual void Add(Net.TheVpc.Upa.FieldModifier m) {
            modifiers = modifiers.Add(m);
        }

        public virtual void AddUnlessNegated(Net.TheVpc.Upa.FieldModifier m, params Net.TheVpc.Upa.UserFieldModifier [] all) {
            foreach (Net.TheVpc.Upa.UserFieldModifier x in all) {
                if (negativeModifiers.Contains(x)) {
                    return;
                }
            }
            modifiers = modifiers.Add(m);
        }

        public virtual void AddUnless(Net.TheVpc.Upa.FieldModifier m, params Net.TheVpc.Upa.UserFieldModifier [] all) {
            foreach (Net.TheVpc.Upa.UserFieldModifier x in all) {
                if (positiveModifiers.Contains(x)) {
                    return;
                }
            }
            modifiers = modifiers.Add(m);
        }

        public virtual bool IsNotSet(Net.TheVpc.Upa.UserFieldModifier m) {
            return !positiveModifiers.Contains(m) && !negativeModifiers.Contains(m);
        }

        public virtual bool Contains(Net.TheVpc.Upa.UserFieldModifier m) {
            return positiveModifiers.Contains(m) && !negativeModifiers.Contains(m);
        }

        public virtual bool ContainsNot(Net.TheVpc.Upa.UserFieldModifier m) {
            return !positiveModifiers.Contains(m) || negativeModifiers.Contains(m);
        }

        public virtual bool Rejects(Net.TheVpc.Upa.UserFieldModifier m) {
            return negativeModifiers.Contains(m);
        }

        public virtual void AddWhenFound(Net.TheVpc.Upa.FieldModifier m, params Net.TheVpc.Upa.UserFieldModifier [] any) {
            foreach (Net.TheVpc.Upa.UserFieldModifier a in any) {
                if (positiveModifiers.Contains(a) && !negativeModifiers.Contains(a)) {
                    modifiers = modifiers.Add(m);
                    return;
                }
            }
        }
    }
}
