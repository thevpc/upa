package net.thevpc.upa.test.syntax;

import net.thevpc.upa.UPA;
import net.thevpc.upa.impl.config.ContextElement;
import net.thevpc.upa.impl.config.DefaultUPAContextLoader;
import net.thevpc.upa.impl.util.DefaultVarContext;
import net.thevpc.upa.impl.DefaultXmlFactory;
import org.junit.Assert;
import org.junit.Test;

import javax.xml.parsers.ParserConfigurationException;
import java.io.IOException;
import java.net.URL;
import net.thevpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;

/**
 * Created by vpc on 1/29/17.
 */
public class SyntaxUPAXmlValidatorUC {

    @BeforeClass
    public static void setup() {
        PUUtils.reset();
    }

    @Test
    public void main() throws ParserConfigurationException, IOException {
        DefaultUPAContextLoader loader = new DefaultUPAContextLoader(null);
        ContextElement contextElement = new ContextElement();
        URL xsdURL = UPA.class.getResource("/net/thevpc/upa/upa-1.0.xsd");
        URL xmlURL = SyntaxUPAXmlValidatorUC.class.getResource("/test-resources/upa-bloated.xml");
        boolean b = loader.parseURL(
                xmlURL,
                contextElement,
                new DefaultVarContext()
        );
        Assert.assertEquals(true, b);
        Assert.assertEquals(true, new DefaultXmlFactory().validateAgainstXSD(xmlURL.openStream(), xsdURL.openStream()));
    }
}
