package net.vpc.upa.impl;

import java.io.IOException;
import java.io.InputStream;
import java.io.Reader;
import net.vpc.upa.impl.xml.XmlDomElement;
import net.vpc.upa.impl.xml.XmlSAXParser;

public interface XmlFactory {

    void parse(InputStream stream,XmlSAXParser visitor) throws IOException;

    void parse(Reader stream, XmlSAXParser visitor) throws IOException;

    XmlDomElement parse(InputStream stream) throws IOException;

    boolean validateAgainstXSD(InputStream xml, InputStream xsd) ;
}
