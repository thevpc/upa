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


    public class DefaultPrimitiveField : Net.TheVpc.Upa.Impl.AbstractField, Net.TheVpc.Upa.PrimitiveField {

        public static readonly Net.TheVpc.Upa.Impl.DefaultPrimitiveField[] EMPTY_ARRAY = new Net.TheVpc.Upa.Impl.DefaultPrimitiveField[0];

        public DefaultPrimitiveField()  : base(){

        }

        public static string GetFieldAlias(string name) {
            int index;
            if ((index = name.IndexOf('.')) < 0) {
                return null;
            } else {
                return name.Substring(0, index);
            }
        }
    }
}
