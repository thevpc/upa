package net.vpc.upa.impl.util.xml;

import java.io.IOException;
import java.io.InputStream;
import java.io.Reader;

public interface XmlFactory {

    void parse(InputStream stream,XmlSAXParser visitor) throws IOException;

    void parse(Reader stream, XmlSAXParser visitor) throws IOException;

    XmlDomElement parse(InputStream stream) throws IOException;

    boolean validateAgainstXSD(InputStream xml, InputStream xsd) ;
}
