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



namespace Net.Vpc.Upa
{


    /**
     * UnspecifiedValue is used to identify the "unspecified value" of fields of an entity
     * when dealing with unstructured records or Prototype records (Find by example).
     * Each field has has a unique value that is defined as "unspecified value",
     * if the field value is equal to that value, the field is supposed not to be explicitly
     * mentioned by user so that in "query by example" object for instance, that value is not
     * used in the where clause, and in update, that field is not updated either.
     * "Unspecified Value" is modified using "Field.setUnspecifiedValue".
     * If the value passed to that method corresponds to UnspecifiedValue.DEFAULT (which is the
     * default by the way), the unspecified value is the field's default type value ie
     * <code>null</code> for references, <code>0 (zero)</code> for numbers and <code>false</code>
     * for boolean.
     * <pre>
     *     PersistenceUnit s=UPAContext.getPersistenceUnit();
     *     //if the id field is numeric, zero is considered as the default value
     *     s.getEntity(Client.class).getField("id").setUnspecifiedValue(UnspecifiedValue.DEFAULT);
     *     //We suppose that Client has 2 attributes id of type int with default value 0
     *     //and name of type String and with default value null
     *     Client c=new Client();
     *     c.setName("Hammadi");
     *
     *     //this will list all Client name="Hammadi"
     *     //even though id=0, that value will not be used in where clause
     *     List&lt;Client> found=s.find(new QueryBuilder().byPrototype(c)).getEntityList();
     *
     *
     *     //if the id field is numeric, zero is considered as the default value
     *     s.getEntity(Client.class).getField("id").setUnspecifiedValue(-1);
     *
     *     //this will list all Client having id=0 and name="Hammadi"
     *     List&lt;Client> found2=s.find(new QueryBuilder().byPrototype(c)).getEntityList();
     * </pre>
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/29/12 2:44 AM
     */
    public sealed class UnspecifiedValue {

        public static Net.Vpc.Upa.UnspecifiedValue DEFAULT = new Net.Vpc.Upa.UnspecifiedValue();

        private UnspecifiedValue() {
        }


        public override int GetHashCode() {
            return 731;
        }


        public object Clone() {
            return this;
        }


        public override string ToString() {
            return "<UnspecifiedValue>";
        }


        public override bool Equals(object obj) {
            return obj is Net.Vpc.Upa.UnspecifiedValue;
        }
    }
}
