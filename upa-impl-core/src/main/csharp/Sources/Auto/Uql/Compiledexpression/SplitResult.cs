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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{

    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/8/13 12:22 AM*/
    internal class SplitResult {

        private string @value;

        private bool delimiter;

        public SplitResult(string @value, bool delimiter) {
            this.@value = @value;
            this.delimiter = delimiter;
        }

        public virtual string GetValue() {
            return @value;
        }

        public virtual bool IsDelimiter() {
            return delimiter;
        }


        public override string ToString() {
            return delimiter ? ("Delimiter{" + @value + "}") : ("Value{" + @value + "}");
        }
    }
}
