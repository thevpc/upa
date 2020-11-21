package net.thevpc.upa.impl;

import net.thevpc.upa.impl.xml.DefaultXmlDomElement;
import net.thevpc.upa.impl.xml.XmlDomElement;
import net.thevpc.upa.impl.xml.XmlSAXParser;
import net.thevpc.upa.impl.xml.XmlSAXParserHandlerAdapter;
import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.exceptions.UPAException;
import org.w3c.dom.Document;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;

import javax.xml.XMLConstants;
import javax.xml.parsers.*;
import javax.xml.transform.stream.StreamSource;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;
import javax.xml.validation.Validator;
import java.io.IOException;
import java.io.InputStream;
import java.io.Reader;

@PortabilityHint(target = "C#", name = "suppress")
public class DefaultXmlFactory implements XmlFactory {

    @Override
    public void parse(InputStream stream, XmlSAXParser visitor) throws IOException {
        SAXParserFactory factory = SAXParserFactory.newInstance();
        try {
            SAXParser saxParser = factory.newSAXParser();
            saxParser.parse(new InputSource(stream), new XmlSAXParserHandlerAdapter(visitor));
        } catch (ParserConfigurationException e) {
            throw new UPAException(e);
        } catch (SAXException e) {
            throw new UPAException(e);
        }
    }

    @Override
    public void parse(Reader stream, XmlSAXParser visitor) throws IOException {
        SAXParserFactory factory = SAXParserFactory.newInstance();
        try {
            SAXParser saxParser = factory.newSAXParser();
            saxParser.parse(new InputSource(stream), new XmlSAXParserHandlerAdapter(visitor));
        } catch (ParserConfigurationException e) {
            throw new UPAException(e);
        } catch (SAXException e) {
            throw new UPAException(e);
        }
    }

    @Override
    public XmlDomElement parse(InputStream stream) throws IOException {
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();

        //Using factory get an instance of document builder
        DocumentBuilder db = null;
        try {
            db = dbf.newDocumentBuilder();

            //parse using builder to get DOM representation of the XML file
            if (stream != null) {
                Document dom = null;
                dom = db.parse(stream);
                return new DefaultXmlDomElement(dom.getDocumentElement());
            }
        } catch (SAXException e) {
            throw new UPAException(e);
        } catch (ParserConfigurationException e) {
            throw new UPAException(e);
        }
        return null;
    }

    public boolean validateAgainstXSD(InputStream xml, InputStream xsd) {
        /**
         * @PortabilityHint(target="C#",name="todo")
         * return false;
         */
        {
            try {
                SchemaFactory factory =
                        SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
                Schema schema = factory.newSchema(new StreamSource(xsd));
                Validator validator = schema.newValidator();
                validator.validate(new StreamSource(xml));
                return true;
            } catch (Exception ex) {
                ex.printStackTrace();
                return false;
            }
        }
    }
}
