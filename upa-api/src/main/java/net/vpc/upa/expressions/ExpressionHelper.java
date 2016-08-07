/**
 * ==================================================================== 
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort 
 * to raise programming language frameworks managing relational data in 
 * applications using Java Platform, Standard Edition and Java Platform, 
 * Enterprise Edition and Dot Net Framework equally to the next level of 
 * handling ORM for mutable data structures. UPA is intended to provide 
 * a solid reflection mechanisms to the mapped data structures while 
 * affording to make changes at runtime of those data structures. 
 * Besides, UPA has learned considerably of the leading ORM 
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few) 
 * failures to satisfy very common even known to be trivial requirement in 
 * enterprise applications. 
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.expressions;

import net.vpc.upa.exceptions.*;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ExpressionHelper {

    private static final Set<String> RESERVED_WORDS = new HashSet<String>(
            Arrays.asList(
                    "select", "update", "remove", "insert", "set", "from", "where", "and", "or", "if", "then", "switch", "case", "else", "elseif", "end", "true", "false", "null", "order", "group", "by", "desc", "asc", "inner", "left", "right", "full", "cross", "join", "having", "on", "not", "like"))
   ;

    public static boolean isReservedWord(String s) {
        return s != null && RESERVED_WORDS.contains(s.toLowerCase());
    }

    public static boolean isIdentifierStart(char s) {
        return (s>='a' && s<='z') 
                ||
               (s>='A' && s<='Z')
                ;
    }
    public static boolean isIdentifierPart(char s) {
        return (s>='a' && s<='z') 
                ||
               (s>='A' && s<='Z')
                ||
               (s>='0' && s<='9')
                ||
               (s=='_')
                ;
    }
    public static boolean isEscapeIdentifier(String s) {
        if (isReservedWord(s)) {
            return true;
        }
        if (s == null) {
            s = "";
        }
        if (s.length() == 0) {
            return true;
        }
        if (!isIdentifierStart(s.charAt(0))) {
            return true;
        }
        for (char c : s.substring(1).toCharArray()) {
            if (!isIdentifierPart(c)) {
                return true;
            }
        }
        return false;
    }

    public static String escapeIdentifier(String s) {
        if (isEscapeIdentifier(s)) {
            return "`" + escapeStringLiteral(s, false, false, true) + "`";
        }
        return s;
    }

    public static String escapeSimpleQuoteStringLiteral(String s) {
        if (s == null) {
            return "null";
        }
        return "\'" + escapeStringLiteral(s, false, true, false) + "\'";
    }

    public static String escapeDoubleQuoteStringLiteral(String s) {
        if (s == null) {
            return "null";
        }
        return "\'" + escapeStringLiteral(s, false, true, false) + "\'";
    }

    public static String escapeStringLiteral(String str, boolean escapeDoubleQuote, boolean escapeSingleQuote, boolean escapeAntiQuote) {
        StringBuilder outString = new StringBuilder();
        if (str == null) {
            return null;
        }
        int sz;
        sz = str.length();
        for (int i = 0; i < sz; i++) {
            char ch = str.charAt(i);

            // handle unicode
            if (ch > 0xfff) {
                outString.append("\\u").append(hex(ch));
            } else if (ch > 0xff) {
                outString.append("\\u0").append(hex(ch));
            } else if (ch > 0x7f) {
                outString.append("\\u00").append(hex(ch));
            } else if (ch < 32) {
                switch (ch) {
                    case '\b':
                        outString.append('\\');
                        outString.append('b');
                        break;
                    case '\n':
                        outString.append('\\');
                        outString.append('n');
                        break;
                    case '\t':
                        outString.append('\\');
                        outString.append('t');
                        break;
                    case '\f':
                        outString.append('\\');
                        outString.append('f');
                        break;
                    case '\r':
                        outString.append('\\');
                        outString.append('r');
                        break;
                    default:
                        if (ch > 0xf) {
                            outString.append("\\u00").append(hex(ch));
                        } else {
                            outString.append("\\u000").append(hex(ch));
                        }
                        break;
                }
            } else {
                switch (ch) {
                    case '\'':
                        if (escapeSingleQuote) {
                            outString.append('\\');
                        }
                        outString.append('\'');
                        break;
                    case '`':
                        if (escapeAntiQuote) {
                            outString.append('\\');
                        }
                        outString.append('`');
                        break;
                    case '"':
                        if (escapeDoubleQuote) {
                            outString.append('\\');
                        }
                        outString.append('"');
                        break;
                    case '\\':
                        outString.append('\\');
                        outString.append('\\');
                        break;
                    default:
                        outString.append(ch);
                        break;
                }
            }
        }
        return outString.toString();
    }

    private static String hex(char ch) {
        return Integer.toHexString(ch).toUpperCase();
    }

    public static String unescapeString(String str) {
        if (str == null) {
            return null;
        }
        StringBuilder outStr = new StringBuilder();
        int sz = str.length();
        StringBuffer unicode = new StringBuffer(4);
        boolean encountredSlash = false;
        boolean unicodeStr = false;
        for (int i = 0; i < sz; i++) {
            char ch = str.charAt(i);
            if (unicodeStr) {
                unicode.append(ch);
                if (unicode.length() == 4) {
                    try {
                        int value = Integer.parseInt(unicode.toString(), 16);
                        outStr.append((char) value);
                        unicode.delete(0,unicode.length());
                        unicodeStr = false;
                        encountredSlash = false;
                    } catch (NumberFormatException nfe) {
                        throw new net.vpc.upa.exceptions.IllegalArgumentException("Unable to parse unicode value: " + unicode, nfe);
                    }
                }
                continue;
            }
            if (encountredSlash) {
                encountredSlash = false;
                switch (ch) {
                    case '\\':
                        outStr.append('\\');
                        break;
                    case '\'':
                        outStr.append('\'');
                        break;
                    case '\"':
                        outStr.append('"');
                        break;
                    case 'r':
                        outStr.append('\r');
                        break;
                    case 'f':
                        outStr.append('\f');
                        break;
                    case 't':
                        outStr.append('\t');
                        break;
                    case 'n':
                        outStr.append('\n');
                        break;
                    case 'b':
                        outStr.append('\b');
                        break;
                    case 'u': {
                        unicodeStr = true;
                        break;
                    }
                    default:
                        outStr.append(ch);
                        break;
                }
                continue;
            } else if (ch == '\\') {
                encountredSlash = true;
                continue;
            }
            outStr.append(ch);
        }
        if (encountredSlash) {
            outStr.append('\\');
        }
        return outStr.toString();
    }
}
