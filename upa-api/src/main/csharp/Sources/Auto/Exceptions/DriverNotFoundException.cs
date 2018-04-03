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



namespace Net.Vpc.Upa.Exceptions
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DriverNotFoundException : Net.Vpc.Upa.Exceptions.ConnectionException {

        private string driverName;

        public DriverNotFoundException() {
        }

        public DriverNotFoundException(string driverName)  : base("DriverNotFoundException", driverName){

            this.driverName = driverName;
        }

        public virtual string GetDriverName() {
            return driverName;
        }
    }
}
