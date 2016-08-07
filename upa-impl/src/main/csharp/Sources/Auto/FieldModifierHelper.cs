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



namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/15/12 7:35 PM
     */
    internal class FieldModifierHelper {

        internal Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> modifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.FieldModifier>();

        internal Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> positiveModifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.UserFieldModifier>();

        internal Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> negativeModifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.UserFieldModifier>();

        public FieldModifierHelper(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> positive, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> negative) {
            if (positive != null) {
                this.positiveModifiers = this.positiveModifiers.AddAll(positive);
            }
            if (negative != null) {
                this.negativeModifiers = this.negativeModifiers.AddAll(negative);
            }
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetPositive() {
            return positiveModifiers;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetNegative() {
            return positiveModifiers;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> GetEffective() {
            return modifiers;
        }

        public virtual void Add(Net.Vpc.Upa.FieldModifier m) {
            modifiers = modifiers.Add(m);
        }

        public virtual void AddUnlessNegated(Net.Vpc.Upa.FieldModifier m, params Net.Vpc.Upa.UserFieldModifier [] all) {
            foreach (Net.Vpc.Upa.UserFieldModifier x in all) {
                if (negativeModifiers.Contains(x)) {
                    return;
                }
            }
            modifiers = modifiers.Add(m);
        }

        public virtual void AddUnless(Net.Vpc.Upa.FieldModifier m, params Net.Vpc.Upa.UserFieldModifier [] all) {
            foreach (Net.Vpc.Upa.UserFieldModifier x in all) {
                if (positiveModifiers.Contains(x)) {
                    return;
                }
            }
            modifiers = modifiers.Add(m);
        }

        public virtual bool IsNotSet(Net.Vpc.Upa.UserFieldModifier m) {
            return !positiveModifiers.Contains(m) && !negativeModifiers.Contains(m);
        }

        public virtual bool Contains(Net.Vpc.Upa.UserFieldModifier m) {
            return positiveModifiers.Contains(m) && !negativeModifiers.Contains(m);
        }

        public virtual bool ContainsNot(Net.Vpc.Upa.UserFieldModifier m) {
            return !positiveModifiers.Contains(m) || negativeModifiers.Contains(m);
        }

        public virtual bool Rejects(Net.Vpc.Upa.UserFieldModifier m) {
            return negativeModifiers.Contains(m);
        }

        public virtual void AddWhenFound(Net.Vpc.Upa.FieldModifier m, params Net.Vpc.Upa.UserFieldModifier [] any) {
            foreach (Net.Vpc.Upa.UserFieldModifier a in any) {
                if (positiveModifiers.Contains(a) && !negativeModifiers.Contains(a)) {
                    modifiers = modifiers.Add(m);
                    return;
                }
            }
        }
    }
}
