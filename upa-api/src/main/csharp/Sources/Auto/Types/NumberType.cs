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



namespace Net.Vpc.Upa.Types
{

    public abstract class NumberType : Net.Vpc.Upa.Types.DataType {

        protected internal NumberType(string name, System.Type platformType)  : base(name, platformType){

        }

        protected internal NumberType(string name, System.Type platformType, bool nullable)  : base(name, platformType, nullable){

        }

        protected internal NumberType(string name, System.Type platformType, int scale, int precision, bool nullable)  : base(name, platformType, scale, precision, nullable){

        }

        public abstract object Parse(string @value);
    }
}
