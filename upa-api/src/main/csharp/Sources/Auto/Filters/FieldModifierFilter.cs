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



namespace Net.Vpc.Upa.Filters
{


    public class FieldModifierFilter : Net.Vpc.Upa.Filters.AbstractFieldFilter {

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier>[] accepted;

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier>[] rejected;

        private bool acceptDynamic;

        public FieldModifierFilter() {
            accepted = new Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier>[0];
            rejected = new Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier>[0];
        }

        private FieldModifierFilter(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier>[] accepted, Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier>[] rejected, bool acceptDynamic) {
            this.accepted = accepted;
            this.rejected = rejected;
            this.acceptDynamic = acceptDynamic;
        }


        public override bool AcceptDynamic() {
            return acceptDynamic;
        }

        public virtual bool IsAcceptDynamic() {
            return acceptDynamic;
        }

        public virtual Net.Vpc.Upa.Filters.FieldModifierFilter SetAcceptDynamic(bool acceptDynamic) {
            if (this.acceptDynamic == acceptDynamic) {
                return this;
            }
            return new Net.Vpc.Upa.Filters.FieldModifierFilter(accepted, rejected, acceptDynamic);
        }

        public virtual bool Accept(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> modifiersValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            for (int i = 0; i < accepted.Length; i++) {
                if (Accept(modifiersValue, i)) {
                    return true;
                }
            }
            return false;
        }

        private bool Accept(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> modifiersValue, int i) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> a = accepted[i];
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> r = rejected[i];
            foreach (Net.Vpc.Upa.FieldModifier m in a) {
                if (!modifiersValue.Contains(m)) {
                    return false;
                }
            }
            foreach (Net.Vpc.Upa.FieldModifier m in r) {
                if (modifiersValue.Contains(m)) {
                    return false;
                }
            }
            return true;
        }

        public override bool Accept(Net.Vpc.Upa.Field f) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> modifiersValue = f.GetModifiers();
            return Accept(modifiersValue);
        }

        private Net.Vpc.Upa.Filters.FieldModifierFilter Or(Net.Vpc.Upa.FieldModifier[] modifierYes, Net.Vpc.Upa.FieldModifier[] modifierNo) {
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> y = modifierYes == null ? Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.FieldModifier>() : Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.FieldModifier>().AddAll(modifierYes);
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> n = modifierNo == null ? Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.FieldModifier>() : Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.FieldModifier>().AddAll(modifierNo);
            for (int i = 0; i < accepted.Length; i++) {
                if (accepted[i].Equals(y) && rejected[i].Equals(n)) {
                    return this;
                }
            }
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier>[] na = new Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier>[accepted.Length + 1];
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier>[] nr = new Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier>[rejected.Length + 1];
            System.Array.Copy(accepted, 0, na, 0, accepted.Length);
            System.Array.Copy(rejected, 0, nr, 0, rejected.Length);
            na[na.Length - 1] = y;
            nr[nr.Length - 1] = n;
            return new Net.Vpc.Upa.Filters.FieldModifierFilter(na, nr, acceptDynamic);
        }

        public virtual Net.Vpc.Upa.Filters.FieldModifierFilter IsAllOfFirstsAndNoneOfSeconds(Net.Vpc.Upa.FieldModifier[] modifierYes, Net.Vpc.Upa.FieldModifier[] modifierNo) {
            if (accepted.Length != 0) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("use orIsAllOfFirstsAndNoneOfSeconds instead");
            }
            return Or(modifierYes, modifierNo);
        }

        public virtual Net.Vpc.Upa.Filters.FieldModifierFilter OrIsAllOfFirstsAndNoneOfSeconds(Net.Vpc.Upa.FieldModifier[] modifierYes, Net.Vpc.Upa.FieldModifier[] modifierNo) {
            if (accepted.Length == 0) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("use isAllOfFirstsAndNoneOfSeconds instead");
            }
            return Or(modifierYes, modifierNo);
        }

        public virtual Net.Vpc.Upa.Filters.FieldModifierFilter IsOneOfFirstsAndNoneOfSeconds(Net.Vpc.Upa.FieldModifier[] modifierYes, Net.Vpc.Upa.FieldModifier[] modifierNo) {
            if (accepted.Length != 0) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("use orIsAllOfFirstsAndNoneOfSeconds instead");
            }
            Net.Vpc.Upa.Filters.FieldModifierFilter x = this;
            for (int i = 0; i < modifierYes.Length; i++) {
                x = Or(new Net.Vpc.Upa.FieldModifier[] { modifierYes[i] }, modifierNo);
            }
            return x;
        }

        public virtual Net.Vpc.Upa.Filters.FieldModifierFilter OrIsOneOfFirstsAndNoneOfSeconds(Net.Vpc.Upa.FieldModifier[] modifierYes, Net.Vpc.Upa.FieldModifier[] modifierNo) {
            if (accepted.Length == 0) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("use isAllOfFirstsAndNoneOfSeconds instead");
            }
            Net.Vpc.Upa.Filters.FieldModifierFilter x = this;
            for (int i = 0; i < modifierYes.Length; i++) {
                x = Or(new Net.Vpc.Upa.FieldModifier[] { modifierYes[i] }, modifierNo);
            }
            return x;
        }

        public virtual Net.Vpc.Upa.Filters.FieldModifierFilter IsAllOf(params Net.Vpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length != 0) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("use orIsAllOf instead");
            }
            return Or(modifiers);
        }

        public virtual Net.Vpc.Upa.Filters.FieldModifierFilter IsAnyOf(params Net.Vpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length != 0) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("use orIsOneOf instead");
            }
            Net.Vpc.Upa.Filters.FieldModifierFilter x = this;
            foreach (Net.Vpc.Upa.FieldModifier m in modifiers) {
                x = x.Or(new Net.Vpc.Upa.FieldModifier[] { m });
            }
            return x;
        }

        public virtual Net.Vpc.Upa.Filters.FieldModifierFilter OrIsOneOf(params Net.Vpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length == 0) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("use isOneOf instead");
            }
            Net.Vpc.Upa.Filters.FieldModifierFilter x = this;
            foreach (Net.Vpc.Upa.FieldModifier m in modifiers) {
                x = Or(new Net.Vpc.Upa.FieldModifier[] { m });
            }
            return x;
        }

        public virtual Net.Vpc.Upa.Filters.FieldModifierFilter IsNotAllOf(params Net.Vpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length != 0) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("use orIsNotOneOf instead");
            }
            Net.Vpc.Upa.Filters.FieldModifierFilter x = this;
            foreach (Net.Vpc.Upa.FieldModifier m in modifiers) {
                x = OrNot(new Net.Vpc.Upa.FieldModifier[] { m });
            }
            return x;
        }

        public virtual Net.Vpc.Upa.Filters.FieldModifierFilter OrIsNotAllOf(params Net.Vpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length == 0) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("use isNotOneOf instead");
            }
            Net.Vpc.Upa.Filters.FieldModifierFilter x = this;
            foreach (Net.Vpc.Upa.FieldModifier m in modifiers) {
                x = OrNot(new Net.Vpc.Upa.FieldModifier[] { m });
            }
            return x;
        }

        public virtual Net.Vpc.Upa.Filters.FieldModifierFilter IsNoneOf(params Net.Vpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length != 0) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("use orIsNoneOf instead");
            }
            return OrNot(modifiers);
        }

        public virtual Net.Vpc.Upa.Filters.FieldModifierFilter OrIsAllOf(params Net.Vpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length == 0) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("use isAllOf instead");
            }
            return Or(modifiers);
        }

        public virtual Net.Vpc.Upa.Filters.FieldModifierFilter OrIsNoneOf(params Net.Vpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length == 0) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("use isNoneOf instead");
            }
            return OrNot(modifiers);
        }

        private Net.Vpc.Upa.Filters.FieldModifierFilter Or(Net.Vpc.Upa.FieldModifier[] modifiers) {
            return Or(modifiers, null);
        }

        private Net.Vpc.Upa.Filters.FieldModifierFilter OrNot(Net.Vpc.Upa.FieldModifier[] modifiers) {
            return Or(null, modifiers);
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("EffectiveModifiers(");
            for (int i = 0; i < accepted.Length; i++) {
                if (i > 0) {
                    sb.Append(") or (");
                }
                bool first = true;
                foreach (Net.Vpc.Upa.FieldModifier e in accepted[i]) {
                    if (first) {
                        first = false;
                    } else {
                        sb.Append(" and ");
                    }
                    sb.Append(e);
                }
                foreach (Net.Vpc.Upa.FieldModifier e in rejected[i]) {
                    if (first) {
                        sb.Append("not ");
                        first = false;
                    } else {
                        sb.Append(" and not ");
                    }
                    sb.Append(e);
                }
            }
            sb.Append(")");
            //        sb.append(acceptedFields);
            //        sb.append(" !");
            //        sb.append(nonAcceptedFields);
            return sb.ToString();
        }


        public override bool Equals(object other) {
            if (this == other) {
                return true;
            }
            if (other == null || !(other is Net.Vpc.Upa.Filters.FieldModifierFilter)) {
                return false;
            }
            Net.Vpc.Upa.Filters.FieldModifierFilter m = (Net.Vpc.Upa.Filters.FieldModifierFilter) other;
            if (m.accepted.Length != accepted.Length) {
                return false;
            }
            for (int i = 0; i < m.accepted.Length; i++) {
                bool found = false;
                for (int j = 0; j < accepted.Length; j++) {
                    if ((m.accepted[i].Equals(accepted[j])) && (m.rejected[i] == rejected[j])) {
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    return false;
                }
            }
            for (int i = 0; i < accepted.Length; i++) {
                bool found = false;
                for (int j = 0; j < m.accepted.Length; j++) {
                    if ((accepted[i].Equals(m.accepted[j])) && (rejected[i] == m.rejected[j])) {
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    return false;
                }
            }
            return true;
        }


        public override int GetHashCode() {
            int hash = 7;
            hash = 97 * hash + ArrayHash(this.accepted);
            hash = 97 * hash + ArrayHash(this.rejected);
            hash = 97 * hash + (this.acceptDynamic ? 1 : 0);
            return hash;
        }

        /**
             * Arrays.deepHashCode not used because java sepcific
             *
             * @param arr
             * @return
             */
        private int ArrayHash(object[] arr) {
            int x = 0;
            if (arr != null) {
                foreach (object o in arr) {
                    if (o != null) {
                        x += 31 * o.GetHashCode();
                    }
                }
            }
            return x;
        }
    }
}
