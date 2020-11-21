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



namespace Net.TheVpc.Upa.Bulk
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface ParseFormatManager {

         Net.TheVpc.Upa.ObjectFactory GetFactory();

         void SetFactory(Net.TheVpc.Upa.ObjectFactory factory);

         Net.TheVpc.Upa.Bulk.TextFixedWidthParser CreateTextFixedWidthParser(object source) /* throws System.IO.IOException */ ;

         Net.TheVpc.Upa.Bulk.TextCSVParser CreateTextCSVParser(object source) /* throws System.IO.IOException */ ;

         Net.TheVpc.Upa.Bulk.SheetParser CreateSheetParser(object source) /* throws System.IO.IOException */ ;

         Net.TheVpc.Upa.Bulk.XmlParser CreateXmlParser(object source) /* throws System.IO.IOException */ ;

         Net.TheVpc.Upa.Bulk.TextFixedWidthFormatter CreateTextFixedWidthFormatter(object target) /* throws System.IO.IOException */ ;

         Net.TheVpc.Upa.Bulk.TextCSVFormatter CreateTextCSVFormatter(object target) /* throws System.IO.IOException */ ;

         Net.TheVpc.Upa.Bulk.SheetFormatter CreateSheetFormatter(object target) /* throws System.IO.IOException */ ;

         Net.TheVpc.Upa.Bulk.XmlFormatter CreateXmlFormatter(object target) /* throws System.IO.IOException */ ;
    }
}
