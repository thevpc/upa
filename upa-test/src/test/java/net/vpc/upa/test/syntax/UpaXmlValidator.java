package net.vpc.upa.test.syntax;

import net.vpc.upa.UPA;
import net.vpc.upa.impl.config.ContextElement;
import net.vpc.upa.impl.config.DefaultUPAContextLoader;
import net.vpc.upa.impl.util.DefaultVarContext;
import net.vpc.upa.impl.util.xml.DefaultXmlFactory;
import org.junit.Assert;
import org.junit.Test;
import org.xml.sax.SAXException;

import javax.xml.parsers.ParserConfigurationException;
import java.io.IOException;
import java.net.URL;

/**
 * Created by vpc on 1/29/17.
 */
public class UpaXmlValidator {

    @Test
    public void main() throws ParserConfigurationException, SAXException, IOException {
        DefaultUPAContextLoader loader = new DefaultUPAContextLoader(null);
        ContextElement contextElement = new ContextElement();
        URL xsdURL = UPA.class.getResource("/net/vpc/upa/upa-1.0.xsd");
        URL xmlURL = UpaXmlValidator.class.getResource("/test-resources/upa-bloated.xml");
        boolean b = loader.parseURL(
                xmlURL,
                contextElement,
                new DefaultVarContext()
        );
        Assert.assertEquals(true,b);
        new DefaultXmlFactory().validateAgainstXSD(xmlURL.openStream(), xsdURL.openStream());
        Assert.assertEquals(true,true);
    }
}
