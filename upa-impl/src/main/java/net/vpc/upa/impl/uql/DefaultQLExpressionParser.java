/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import java.io.InputStream;
import java.io.Reader;
import java.io.StringReader;
import net.vpc.upa.QLExpressionParser;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.uql.parser.syntax.UQLParser;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DefaultQLExpressionParser implements QLExpressionParser {

    public Expression parse(Reader text) throws UPAException {
        return new UQLParser(text).Any();
    }

    public Expression parse(String reader) throws UPAException {
        /**
         * @PortabilityHint(target = "C#", name = "todo")
         * return null;
         */
        return new UQLParser(new StringReader(reader)).Any();
    }
    
    public Expression parse(InputStream inputStream) throws UPAException {
        /**
         * @PortabilityHint(target = "C#", name = "todo")
         * return null;
         */
        return new UQLParser(inputStream).Any();
    }

}
