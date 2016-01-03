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


    public class DefaultPrimitiveField : Net.Vpc.Upa.Impl.AbstractField, Net.Vpc.Upa.PrimitiveField {

        public static readonly Net.Vpc.Upa.Impl.DefaultPrimitiveField[] EMPTY_ARRAY = new Net.Vpc.Upa.Impl.DefaultPrimitiveField[0];

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
