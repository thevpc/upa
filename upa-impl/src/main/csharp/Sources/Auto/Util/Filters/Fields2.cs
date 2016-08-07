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



namespace Net.Vpc.Upa.Impl.Util.Filters
{


    /**
     * Created by vpc on 7/3/16.
     */
    public class Fields2 {

        public static readonly Net.Vpc.Upa.Filters.FieldFilter VIEW = Net.Vpc.Upa.Filters.Fields.ByModifiersAnyOf(Net.Vpc.Upa.FieldModifier.SELECT_STORED);

        public static readonly Net.Vpc.Upa.Filters.FieldFilter PERSIST_FORMULA = Net.Vpc.Upa.Filters.Fields.ByModifiersAnyOf(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA).And(Net.Vpc.Upa.Filters.Fields.ByModifiersNotAllOf(Net.Vpc.Upa.FieldModifier.PERSIST_SEQUENCE));

        public static readonly Net.Vpc.Upa.Filters.FieldFilter UPDATE_FORMULA = Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByModifiersAnyOf(Net.Vpc.Upa.FieldModifier.UPDATE_FORMULA)).And(Net.Vpc.Upa.Filters.Fields.ByModifiersNoneOf(Net.Vpc.Upa.FieldModifier.UPDATE_SEQUENCE));

        public static readonly Net.Vpc.Upa.Filters.FieldFilter COPY_ON_CLONE = Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByModifiersNoneOf(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA, Net.Vpc.Upa.FieldModifier.UPDATE_FORMULA, Net.Vpc.Upa.FieldModifier.TRANSIENT));

        public static readonly Net.Vpc.Upa.Filters.FieldFilter COPY_ON_RENAME = Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByModifiersNoneOf(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA, Net.Vpc.Upa.FieldModifier.UPDATE_FORMULA, Net.Vpc.Upa.FieldModifier.TRANSIENT));

        public static readonly Net.Vpc.Upa.Filters.FieldFilter PERSIST = Net.Vpc.Upa.Filters.Fields.ByModifiersAllOf(Net.Vpc.Upa.FieldModifier.PERSIST);

        public static readonly Net.Vpc.Upa.Filters.FieldFilter PERSISTENT_NON_FORMULA = Net.Vpc.Upa.Filters.Fields.ByModifiersNoneOf(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA, Net.Vpc.Upa.FieldModifier.UPDATE_FORMULA, Net.Vpc.Upa.FieldModifier.TRANSIENT);

        public static readonly Net.Vpc.Upa.Filters.FieldFilter UPDATE = Net.Vpc.Upa.Filters.Fields.ByModifiersAllOf(Net.Vpc.Upa.FieldModifier.UPDATE);

        public static readonly Net.Vpc.Upa.Filters.FieldFilter READ = Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByModifiersAnyOf(Net.Vpc.Upa.FieldModifier.SELECT_DEFAULT, Net.Vpc.Upa.FieldModifier.SELECT_STORED, Net.Vpc.Upa.FieldModifier.SELECT_LIVE)).AndNot(Net.Vpc.Upa.Filters.Fields.ByAllAccessLevel(Net.Vpc.Upa.AccessLevel.PRIVATE));
    }
}
