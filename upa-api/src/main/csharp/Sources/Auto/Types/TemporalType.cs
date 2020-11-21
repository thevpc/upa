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



namespace Net.TheVpc.Upa.Types
{

    public abstract class TemporalType : Net.TheVpc.Upa.Types.DefaultDataType {

        protected internal TemporalType(string name, System.Type platformType)  : base(name, platformType){

        }

        protected internal TemporalType(string name, System.Type platformType, bool nullable)  : base(name, platformType, nullable){

        }

        protected internal TemporalType(string name, System.Type platformType, int scale, int precision, bool nullable)  : base(name, platformType, scale, precision, nullable){

        }

        public abstract Net.TheVpc.Upa.Types.TemporalOption GetTemporalOption();

        public abstract Net.TheVpc.Upa.Types.Temporal ValidateDate(Net.TheVpc.Upa.Types.Temporal date);

        public abstract Net.TheVpc.Upa.Types.Temporal Parse(string @value);
    }
}
