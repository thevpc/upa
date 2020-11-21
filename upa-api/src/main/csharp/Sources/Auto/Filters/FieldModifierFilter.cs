/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Filters
{


    public class FieldModifierFilter : Net.TheVpc.Upa.Filters.AbstractFieldFilter {

        private Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier>[] accepted;

        private Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier>[] rejected;

        private bool acceptDynamic;

        public FieldModifierFilter() {
            accepted = new Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier>[0];
            rejected = new Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier>[0];
        }

        private FieldModifierFilter(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier>[] accepted, Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier>[] rejected, bool acceptDynamic) {
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

        public virtual Net.TheVpc.Upa.Filters.FieldModifierFilter SetAcceptDynamic(bool acceptDynamic) {
            if (this.acceptDynamic == acceptDynamic) {
                return this;
            }
            return new Net.TheVpc.Upa.Filters.FieldModifierFilter(accepted, rejected, acceptDynamic);
        }

        public virtual bool Accept(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> modifiersValue) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            for (int i = 0; i < accepted.Length; i++) {
                if (Accept(modifiersValue, i)) {
                    return true;
                }
            }
            return false;
        }

        private bool Accept(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> modifiersValue, int i) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> a = accepted[i];
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> r = rejected[i];
            foreach (Net.TheVpc.Upa.FieldModifier m in a) {
                if (!modifiersValue.Contains(m)) {
                    return false;
                }
            }
            foreach (Net.TheVpc.Upa.FieldModifier m in r) {
                if (modifiersValue.Contains(m)) {
                    return false;
                }
            }
            return true;
        }

        public override bool Accept(Net.TheVpc.Upa.Field f) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> modifiersValue = f.GetModifiers();
            return Accept(modifiersValue);
        }

        private Net.TheVpc.Upa.Filters.FieldModifierFilter Or(Net.TheVpc.Upa.FieldModifier[] modifierYes, Net.TheVpc.Upa.FieldModifier[] modifierNo) {
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> y = modifierYes == null ? Net.TheVpc.Upa.FlagSets.NoneOf<>() : Net.TheVpc.Upa.FlagSets.NoneOf<>().AddAll(modifierYes);
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> n = modifierNo == null ? Net.TheVpc.Upa.FlagSets.NoneOf<>() : Net.TheVpc.Upa.FlagSets.NoneOf<>().AddAll(modifierNo);
            for (int i = 0; i < accepted.Length; i++) {
                if (accepted[i].Equals(y) && rejected[i].Equals(n)) {
                    return this;
                }
            }
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier>[] na = new Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier>[accepted.Length + 1];
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier>[] nr = new Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier>[rejected.Length + 1];
            System.Array.Copy(accepted, 0, na, 0, accepted.Length);
            System.Array.Copy(rejected, 0, nr, 0, rejected.Length);
            na[na.Length - 1] = y;
            nr[nr.Length - 1] = n;
            return new Net.TheVpc.Upa.Filters.FieldModifierFilter(na, nr, acceptDynamic);
        }

        public virtual Net.TheVpc.Upa.Filters.FieldModifierFilter IsAllOfFirstsAndNoneOfSeconds(Net.TheVpc.Upa.FieldModifier[] modifierYes, Net.TheVpc.Upa.FieldModifier[] modifierNo) {
            if (accepted.Length != 0) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("use orIsAllOfFirstsAndNoneOfSeconds instead");
            }
            return Or(modifierYes, modifierNo);
        }

        public virtual Net.TheVpc.Upa.Filters.FieldModifierFilter OrIsAllOfFirstsAndNoneOfSeconds(Net.TheVpc.Upa.FieldModifier[] modifierYes, Net.TheVpc.Upa.FieldModifier[] modifierNo) {
            if (accepted.Length == 0) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("use isAllOfFirstsAndNoneOfSeconds instead");
            }
            return Or(modifierYes, modifierNo);
        }

        public virtual Net.TheVpc.Upa.Filters.FieldModifierFilter IsOneOfFirstsAndNoneOfSeconds(Net.TheVpc.Upa.FieldModifier[] modifierYes, Net.TheVpc.Upa.FieldModifier[] modifierNo) {
            if (accepted.Length != 0) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("use orIsAllOfFirstsAndNoneOfSeconds instead");
            }
            Net.TheVpc.Upa.Filters.FieldModifierFilter x = this;
            for (int i = 0; i < modifierYes.Length; i++) {
                x = Or(new Net.TheVpc.Upa.FieldModifier[] { modifierYes[i] }, modifierNo);
            }
            return x;
        }

        public virtual Net.TheVpc.Upa.Filters.FieldModifierFilter OrIsOneOfFirstsAndNoneOfSeconds(Net.TheVpc.Upa.FieldModifier[] modifierYes, Net.TheVpc.Upa.FieldModifier[] modifierNo) {
            if (accepted.Length == 0) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("use isAllOfFirstsAndNoneOfSeconds instead");
            }
            Net.TheVpc.Upa.Filters.FieldModifierFilter x = this;
            for (int i = 0; i < modifierYes.Length; i++) {
                x = Or(new Net.TheVpc.Upa.FieldModifier[] { modifierYes[i] }, modifierNo);
            }
            return x;
        }

        public virtual Net.TheVpc.Upa.Filters.FieldModifierFilter IsAllOf(params Net.TheVpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length != 0) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("use orIsAllOf instead");
            }
            return Or(modifiers);
        }

        public virtual Net.TheVpc.Upa.Filters.FieldModifierFilter IsAnyOf(params Net.TheVpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length != 0) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("use orIsOneOf instead");
            }
            Net.TheVpc.Upa.Filters.FieldModifierFilter x = this;
            foreach (Net.TheVpc.Upa.FieldModifier m in modifiers) {
                x = x.Or(new Net.TheVpc.Upa.FieldModifier[] { m });
            }
            return x;
        }

        public virtual Net.TheVpc.Upa.Filters.FieldModifierFilter OrIsOneOf(params Net.TheVpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length == 0) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("use isOneOf instead");
            }
            Net.TheVpc.Upa.Filters.FieldModifierFilter x = this;
            foreach (Net.TheVpc.Upa.FieldModifier m in modifiers) {
                x = Or(new Net.TheVpc.Upa.FieldModifier[] { m });
            }
            return x;
        }

        public virtual Net.TheVpc.Upa.Filters.FieldModifierFilter IsNotAllOf(params Net.TheVpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length != 0) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("use orIsNotOneOf instead");
            }
            Net.TheVpc.Upa.Filters.FieldModifierFilter x = this;
            foreach (Net.TheVpc.Upa.FieldModifier m in modifiers) {
                x = OrNot(new Net.TheVpc.Upa.FieldModifier[] { m });
            }
            return x;
        }

        public virtual Net.TheVpc.Upa.Filters.FieldModifierFilter OrIsNotAllOf(params Net.TheVpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length == 0) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("use isNotOneOf instead");
            }
            Net.TheVpc.Upa.Filters.FieldModifierFilter x = this;
            foreach (Net.TheVpc.Upa.FieldModifier m in modifiers) {
                x = OrNot(new Net.TheVpc.Upa.FieldModifier[] { m });
            }
            return x;
        }

        public virtual Net.TheVpc.Upa.Filters.FieldModifierFilter IsNoneOf(params Net.TheVpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length != 0) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("use orIsNoneOf instead");
            }
            return OrNot(modifiers);
        }

        public virtual Net.TheVpc.Upa.Filters.FieldModifierFilter OrIsAllOf(params Net.TheVpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length == 0) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("use isAllOf instead");
            }
            return Or(modifiers);
        }

        public virtual Net.TheVpc.Upa.Filters.FieldModifierFilter OrIsNoneOf(params Net.TheVpc.Upa.FieldModifier [] modifiers) {
            if (accepted.Length == 0) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("use isNoneOf instead");
            }
            return OrNot(modifiers);
        }

        private Net.TheVpc.Upa.Filters.FieldModifierFilter Or(Net.TheVpc.Upa.FieldModifier[] modifiers) {
            return Or(modifiers, null);
        }

        private Net.TheVpc.Upa.Filters.FieldModifierFilter OrNot(Net.TheVpc.Upa.FieldModifier[] modifiers) {
            return Or(null, modifiers);
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("EffectiveModifiers(");
            for (int i = 0; i < accepted.Length; i++) {
                if (i > 0) {
                    sb.Append(") or (");
                }
                bool first = true;
                foreach (Net.TheVpc.Upa.FieldModifier e in accepted[i]) {
                    if (first) {
                        first = false;
                    } else {
                        sb.Append(" and ");
                    }
                    sb.Append(e);
                }
                foreach (Net.TheVpc.Upa.FieldModifier e in rejected[i]) {
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
            if (other == null || !(other is Net.TheVpc.Upa.Filters.FieldModifierFilter)) {
                return false;
            }
            Net.TheVpc.Upa.Filters.FieldModifierFilter m = (Net.TheVpc.Upa.Filters.FieldModifierFilter) other;
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
