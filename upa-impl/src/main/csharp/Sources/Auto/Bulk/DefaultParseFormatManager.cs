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



namespace Net.Vpc.Upa.Impl.Bulk
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultParseFormatManager : Net.Vpc.Upa.Bulk.ParseFormatManager {

        private Net.Vpc.Upa.ObjectFactory factory;

        /**
             *
             * @return
             */
        public virtual Net.Vpc.Upa.ObjectFactory GetFactory() {
            return factory == null ? Net.Vpc.Upa.UPA.GetBootstrapFactory() : factory;
        }

        /**
             *
             * @param factory
             */
        public virtual void SetFactory(Net.Vpc.Upa.ObjectFactory factory) {
            this.factory = factory;
        }

        /**
             *
             * @return
             */
        public virtual Net.Vpc.Upa.Bulk.DataSerializer CreateDefaultDataSerializer() {
            try {
                return GetFactory().CreateObject<Net.Vpc.Upa.Bulk.DataSerializer>(typeof(Net.Vpc.Upa.Bulk.DataSerializer));
            } catch (System.Exception e) {
            }
            //ignore;
            return null;
        }

        /**
             *
             * @return
             */
        public virtual Net.Vpc.Upa.Bulk.DataDeserializer CreateDefaultDataDeserializer() {
            try {
                return GetFactory().CreateObject<Net.Vpc.Upa.Bulk.DataDeserializer>(typeof(Net.Vpc.Upa.Bulk.DataDeserializer));
            } catch (System.Exception e) {
            }
            //ignore;
            return null;
        }

        /**
             *
             * @param source
             * @return
             * @throws IOException
             */
        public virtual Net.Vpc.Upa.Bulk.TextFixedWidthParser CreateTextFixedWidthParser(object source) /* throws System.IO.IOException */  {
            Net.Vpc.Upa.Bulk.TextFixedWidthParser t = GetFactory().CreateObject<Net.Vpc.Upa.Bulk.TextFixedWidthParser>(typeof(Net.Vpc.Upa.Bulk.TextFixedWidthParser));
            t.Configure(source);
            t.SetDataDeserializer(CreateDefaultDataDeserializer());
            return t;
        }

        /**
             *
             * @param source
             * @return
             * @throws IOException
             */
        public virtual Net.Vpc.Upa.Bulk.TextCSVParser CreateTextCSVParser(object source) /* throws System.IO.IOException */  {
            Net.Vpc.Upa.Bulk.TextCSVParser t = GetFactory().CreateObject<Net.Vpc.Upa.Bulk.TextCSVParser>(typeof(Net.Vpc.Upa.Bulk.TextCSVParser));
            t.Configure(source);
            t.SetDataDeserializer(CreateDefaultDataDeserializer());
            return t;
        }

        /**
             *
             * @param source
             * @return
             * @throws IOException
             */
        public virtual Net.Vpc.Upa.Bulk.SheetParser CreateSheetParser(object source) /* throws System.IO.IOException */  {
            Net.Vpc.Upa.Bulk.SheetParser t = GetFactory().CreateObject<Net.Vpc.Upa.Bulk.SheetParser>(typeof(Net.Vpc.Upa.Bulk.SheetParser));
            t.Configure(source);
            t.SetDataDeserializer(CreateDefaultDataDeserializer());
            return t;
        }

        /**
             *
             * @param source
             * @return
             * @throws IOException
             */
        public virtual Net.Vpc.Upa.Bulk.XmlParser CreateXmlParser(object source) /* throws System.IO.IOException */  {
            Net.Vpc.Upa.Bulk.XmlParser t = GetFactory().CreateObject<Net.Vpc.Upa.Bulk.XmlParser>(typeof(Net.Vpc.Upa.Bulk.XmlParser));
            t.Configure(source);
            t.SetDataDeserializer(CreateDefaultDataDeserializer());
            return t;
        }

        /**
             *
             * @param target
             * @return
             * @throws IOException
             */
        public virtual Net.Vpc.Upa.Bulk.TextFixedWidthFormatter CreateTextFixedWidthFormatter(object target) /* throws System.IO.IOException */  {
            Net.Vpc.Upa.Bulk.TextFixedWidthFormatter t = GetFactory().CreateObject<Net.Vpc.Upa.Bulk.TextFixedWidthFormatter>(typeof(Net.Vpc.Upa.Bulk.TextFixedWidthFormatter));
            t.Configure(target);
            t.SetDataSerializer(CreateDefaultDataSerializer());
            return t;
        }

        /**
             *
             * @param target
             * @return
             * @throws IOException
             */
        public virtual Net.Vpc.Upa.Bulk.TextCSVFormatter CreateTextCSVFormatter(object target) /* throws System.IO.IOException */  {
            Net.Vpc.Upa.Bulk.TextCSVFormatter t = GetFactory().CreateObject<Net.Vpc.Upa.Bulk.TextCSVFormatter>(typeof(Net.Vpc.Upa.Bulk.TextCSVFormatter));
            t.Configure(target);
            t.SetDataSerializer(CreateDefaultDataSerializer());
            return t;
        }

        /**
             *
             * @param target
             * @return
             * @throws IOException
             */
        public virtual Net.Vpc.Upa.Bulk.SheetFormatter CreateSheetFormatter(object target) /* throws System.IO.IOException */  {
            Net.Vpc.Upa.Bulk.SheetFormatter t = GetFactory().CreateObject<Net.Vpc.Upa.Bulk.SheetFormatter>(typeof(Net.Vpc.Upa.Bulk.SheetFormatter));
            t.Configure(target);
            t.SetDataSerializer(CreateDefaultDataSerializer());
            return t;
        }


        public virtual Net.Vpc.Upa.Bulk.XmlFormatter CreateXmlFormatter(object target) /* throws System.IO.IOException */  {
            Net.Vpc.Upa.Bulk.XmlFormatter t = GetFactory().CreateObject<Net.Vpc.Upa.Bulk.XmlFormatter>(typeof(Net.Vpc.Upa.Bulk.XmlFormatter));
            t.Configure(target);
            t.SetDataSerializer(CreateDefaultDataSerializer());
            return t;
        }
    }
}
