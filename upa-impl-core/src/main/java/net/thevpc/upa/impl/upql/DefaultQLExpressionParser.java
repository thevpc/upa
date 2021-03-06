/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql;

import java.io.InputStream;
import java.io.Reader;
import java.io.StringReader;

import net.thevpc.upa.impl.upql.parser.syntax.UPQLParser;
import net.thevpc.upa.QLExpressionParser;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.types.I18NString;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DefaultQLExpressionParser implements QLExpressionParser {

    public Expression parse(Reader text) throws UPAException {
        return parse(new UPQLParser(text), null);
    }

    public Expression parse(String reader) throws UPAException {
        /**
         * @PortabilityHint(target = "C#", name = "todo") return null;
         */
        return parse(new UPQLParser(new StringReader(reader)), null);
    }

    public Expression parse(InputStream inputStream) throws UPAException {
        /**
         * @PortabilityHint(target = "C#", name = "todo") return null;
         */
        return parse(new UPQLParser(inputStream), null);
    }

    public Expression parse(UPQLParser parser, String message) throws UPAException {
        try {
            return parser.Any();
        } catch (RuntimeException ex) {
            if (message == null) {
                throw ex;
            }
            throw new UPAException(ex, new I18NString("UnableToParseQuery"), message);
        }
    }
}
