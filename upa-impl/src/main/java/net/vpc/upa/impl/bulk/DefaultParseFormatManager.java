/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk;

import java.io.IOException;
import net.vpc.upa.ObjectFactory;
import net.vpc.upa.UPA;
import net.vpc.upa.bulk.*;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultParseFormatManager implements ParseFormatManager {

    private ObjectFactory factory;

    /**
     *
     * @return
     */
    public ObjectFactory getFactory() {
        return factory == null ? UPA.getBootstrapFactory() : factory;
    }

    /**
     *
     * @param factory
     */
    public void setFactory(ObjectFactory factory) {
        this.factory = factory;
    }

    /**
     *
     * @return
     */
    public DataSerializer createDefaultDataSerializer() {
        try {
            return getFactory().createObject(DataSerializer.class);
        } catch (Exception e) {
            //ignore;
        }
        return null;
    }

    /**
     *
     * @return
     */
    public DataDeserializer createDefaultDataDeserializer() {
        try {
            return getFactory().createObject(DataDeserializer.class);
        } catch (Exception e) {
            //ignore;
        }
        return null;
    }

    /**
     *
     * @param source
     * @return
     * @throws IOException
     */
    public TextFixedWidthParser createTextFixedWidthParser(Object source) throws IOException {
        TextFixedWidthParser t = getFactory().createObject(TextFixedWidthParser.class);
        t.configure(source);
        t.setDataDeserializer(createDefaultDataDeserializer());
        return t;
    }

    /**
     *
     * @param source
     * @return
     * @throws IOException
     */
    public TextCSVParser createTextCSVParser(Object source) throws IOException {
        TextCSVParser t = getFactory().createObject(TextCSVParser.class);
        t.configure(source);
        t.setDataDeserializer(createDefaultDataDeserializer());
        return t;
    }

    /**
     *
     * @param source
     * @return
     * @throws IOException
     */
    public SheetParser createSheetParser(Object source) throws IOException {
        SheetParser t = getFactory().createObject(SheetParser.class);
        t.configure(source);
        t.setDataDeserializer(createDefaultDataDeserializer());
        return t;
    }

    /**
     *
     * @param source
     * @return
     * @throws IOException
     */
    public XmlParser createXmlParser(Object source) throws IOException {
        XmlParser t = getFactory().createObject(XmlParser.class);
        t.configure(source);
        t.setDataDeserializer(createDefaultDataDeserializer());
        return t;
    }

    /**
     *
     * @param target
     * @return
     * @throws IOException
     */
    public TextFixedWidthFormatter createTextFixedWidthFormatter(Object target) throws IOException {
        TextFixedWidthFormatter t = getFactory().createObject(TextFixedWidthFormatter.class);
        t.configure(target);
        t.setDataSerializer(createDefaultDataSerializer());
        return t;
    }

    /**
     *
     * @param target
     * @return
     * @throws IOException
     */
    public TextCSVFormatter createTextCSVFormatter(Object target) throws IOException {
        TextCSVFormatter t = getFactory().createObject(TextCSVFormatter.class);
        t.configure(target);
        t.setDataSerializer(createDefaultDataSerializer());
        return t;
    }

    /**
     *
     * @param target
     * @return
     * @throws IOException
     */
    public SheetFormatter createSheetFormatter(Object target) throws IOException {
        SheetFormatter t = getFactory().createObject(SheetFormatter.class);
        t.configure(target);
        t.setDataSerializer(createDefaultDataSerializer());
        return t;
    }

    @Override
    public XmlFormatter createXmlFormatter(Object target) throws IOException {
        XmlFormatter t = getFactory().createObject(XmlFormatter.class);
        t.configure(target);
        t.setDataSerializer(createDefaultDataSerializer());
        return t;
    }

}
