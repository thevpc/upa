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



namespace Net.TheVpc.Upa.Impl.Util.Filters
{


    /**
     * Created by vpc on 7/3/16.
     */
    public class Fields2 {

        public static readonly Net.TheVpc.Upa.Filters.FieldFilter VIEW = Net.TheVpc.Upa.Filters.Fields.ByModifiersAnyOf(Net.TheVpc.Upa.FieldModifier.SELECT_STORED);

        public static readonly Net.TheVpc.Upa.Filters.FieldFilter PERSIST_FORMULA = Net.TheVpc.Upa.Filters.Fields.ByModifiersAnyOf(Net.TheVpc.Upa.FieldModifier.PERSIST_FORMULA).And(Net.TheVpc.Upa.Filters.Fields.ByModifiersNotAllOf(Net.TheVpc.Upa.FieldModifier.PERSIST_SEQUENCE));

        public static readonly Net.TheVpc.Upa.Filters.FieldFilter UPDATE_FORMULA = Net.TheVpc.Upa.Filters.Fields.Regular().And(Net.TheVpc.Upa.Filters.Fields.ByModifiersAnyOf(Net.TheVpc.Upa.FieldModifier.UPDATE_FORMULA)).And(Net.TheVpc.Upa.Filters.Fields.ByModifiersNoneOf(Net.TheVpc.Upa.FieldModifier.UPDATE_SEQUENCE));

        public static readonly Net.TheVpc.Upa.Filters.FieldFilter COPY_ON_CLONE = Net.TheVpc.Upa.Filters.Fields.Regular().And(Net.TheVpc.Upa.Filters.Fields.ByModifiersNoneOf(Net.TheVpc.Upa.FieldModifier.PERSIST_FORMULA, Net.TheVpc.Upa.FieldModifier.UPDATE_FORMULA, Net.TheVpc.Upa.FieldModifier.TRANSIENT));

        public static readonly Net.TheVpc.Upa.Filters.FieldFilter COPY_ON_RENAME = Net.TheVpc.Upa.Filters.Fields.Regular().And(Net.TheVpc.Upa.Filters.Fields.ByModifiersNoneOf(Net.TheVpc.Upa.FieldModifier.PERSIST_FORMULA, Net.TheVpc.Upa.FieldModifier.UPDATE_FORMULA, Net.TheVpc.Upa.FieldModifier.TRANSIENT));

        public static readonly Net.TheVpc.Upa.Filters.FieldFilter PERSIST = Net.TheVpc.Upa.Filters.Fields.ByModifiersAllOf(Net.TheVpc.Upa.FieldModifier.PERSIST);

        public static readonly Net.TheVpc.Upa.Filters.FieldFilter PERSISTENT_NON_FORMULA = Net.TheVpc.Upa.Filters.Fields.ByModifiersNoneOf(Net.TheVpc.Upa.FieldModifier.PERSIST_FORMULA, Net.TheVpc.Upa.FieldModifier.UPDATE_FORMULA, Net.TheVpc.Upa.FieldModifier.TRANSIENT);

        public static readonly Net.TheVpc.Upa.Filters.FieldFilter UPDATE = Net.TheVpc.Upa.Filters.Fields.ByModifiersAllOf(Net.TheVpc.Upa.FieldModifier.UPDATE);

        public static readonly Net.TheVpc.Upa.Filters.FieldFilter READ = Net.TheVpc.Upa.Filters.Fields.Regular().And(Net.TheVpc.Upa.Filters.Fields.ByModifiersAnyOf(Net.TheVpc.Upa.FieldModifier.SELECT_DEFAULT, Net.TheVpc.Upa.FieldModifier.SELECT_STORED, Net.TheVpc.Upa.FieldModifier.SELECT_LIVE)).AndNot(Net.TheVpc.Upa.Filters.Fields.ByAllAccessLevel(Net.TheVpc.Upa.AccessLevel.PRIVATE));
    }
}
