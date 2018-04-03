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



namespace Net.Vpc.Upa.Bulk
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface ParseFormatManager {

         Net.Vpc.Upa.ObjectFactory GetFactory();

         void SetFactory(Net.Vpc.Upa.ObjectFactory factory);

         Net.Vpc.Upa.Bulk.TextFixedWidthParser CreateTextFixedWidthParser(object source) /* throws System.IO.IOException */ ;

         Net.Vpc.Upa.Bulk.TextCSVParser CreateTextCSVParser(object source) /* throws System.IO.IOException */ ;

         Net.Vpc.Upa.Bulk.SheetParser CreateSheetParser(object source) /* throws System.IO.IOException */ ;

         Net.Vpc.Upa.Bulk.XmlParser CreateXmlParser(object source) /* throws System.IO.IOException */ ;

         Net.Vpc.Upa.Bulk.TextFixedWidthFormatter CreateTextFixedWidthFormatter(object target) /* throws System.IO.IOException */ ;

         Net.Vpc.Upa.Bulk.TextCSVFormatter CreateTextCSVFormatter(object target) /* throws System.IO.IOException */ ;

         Net.Vpc.Upa.Bulk.SheetFormatter CreateSheetFormatter(object target) /* throws System.IO.IOException */ ;

         Net.Vpc.Upa.Bulk.XmlFormatter CreateXmlFormatter(object target) /* throws System.IO.IOException */ ;
    }
}
