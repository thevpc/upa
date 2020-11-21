package net.thevpc.upa.impl;

import net.thevpc.upa.FieldModifier;
import net.thevpc.upa.FlagSet;
import net.thevpc.upa.FlagSets;
import net.thevpc.upa.UserFieldModifier;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/15/12 7:35 PM
 */
class FieldModifierHelper {

    FlagSet<FieldModifier> modifiers = FlagSets.noneOf(FieldModifier.class);
    FlagSet<UserFieldModifier> positiveModifiers = FlagSets.noneOf(UserFieldModifier.class);
    FlagSet<UserFieldModifier> negativeModifiers = FlagSets.noneOf(UserFieldModifier.class);

    public FieldModifierHelper(FlagSet<UserFieldModifier> positive, FlagSet<UserFieldModifier> negative) {
        if (positive != null) {
            this.positiveModifiers=this.positiveModifiers.addAll(positive);
        }
        if (negative != null) {
            this.negativeModifiers=this.negativeModifiers.addAll(negative);
        }
    }

    public FlagSet<UserFieldModifier> getPositive() {
        return positiveModifiers;
    }

    public FlagSet<UserFieldModifier> getNegative() {
        return positiveModifiers;
    }

    public FlagSet<FieldModifier> getEffective() {
        return modifiers;
    }

//    public void addWhenFound(UserFieldModifier u, UserFieldModifier m){
//        if(positiveModifiers.contains(u) && !negativeModifiers.contains(u)){
//            modifiers=modifiers.add(m);
//        }
//    }
    public void add(FieldModifier m) {
        modifiers = modifiers.add(m);
    }

    public void addUnlessNegated(FieldModifier m, UserFieldModifier... all) {
        for (UserFieldModifier x : all) {
            if (negativeModifiers.contains(x)) {
                return;
            }
        }
        modifiers = modifiers.add(m);
    }

    public void addUnless(FieldModifier m, UserFieldModifier... all) {
        for (UserFieldModifier x : all) {
            if (positiveModifiers.contains(x)) {
                return;
            }
        }
        modifiers = modifiers.add(m);
    }

    public boolean isNotSet(UserFieldModifier m) {
        return !positiveModifiers.contains(m) && !negativeModifiers.contains(m);
    }

    public boolean contains(UserFieldModifier m) {
        return positiveModifiers.contains(m) && !negativeModifiers.contains(m);
    }

    public boolean containsNot(UserFieldModifier m) {
        return !positiveModifiers.contains(m) || negativeModifiers.contains(m);
    }

    public boolean rejects(UserFieldModifier m) {
        return negativeModifiers.contains(m);
    }

    public void addWhenFound(FieldModifier m, UserFieldModifier... any) {
        for (UserFieldModifier a : any) {
            if (positiveModifiers.contains(a) && !negativeModifiers.contains(a)) {
                modifiers = modifiers.add(m);
                return;
            }
        }
    }


}
