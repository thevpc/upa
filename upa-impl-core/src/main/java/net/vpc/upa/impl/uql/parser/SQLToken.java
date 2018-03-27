//package net.vpc.upa.impl.uql.parser;
//
//
//import java.util.Arrays;
//import java.util.Collection;
//import java.util.Collections;
//import java.util.TreeSet;
//
//public class SQLToken {
//    public static final int UNKNOWN = 0;
//    public static final int WHITE = 1;
//    public static final int KEYWORD = 2;
//    public static final int VAR = 4;
//    public static final int STR = 8;
//    public static final int STR_SEP = 16;
//    public static final int NUM = 32;
//    public static final int OPERATOR = 64;
//    public static final int PAR = 128;
//    public static final int CLOSE_PAR = 256;
//    public static final int OPEN_PAR = 512;
//    public static final int SEPARATOR = 1024;
//    public static final Collection SQL_KEYWORDS = Collections.unmodifiableCollection(new TreeSet<String>(Arrays.asList(new String[]{
//            "SELECT", "FROM", "WHERE", "AND", "OR", "NOT", "IN", "IS", "INNER", "OUTER",
//            "FULL", "JOIN", "ON", "ORDER", "BY", "DESC", "ASC", "UPDATE", "DELETE", "INSERT",
//            "INTO", "VALUES", "CREATE", "TABLE", "DATABASE", "DROP"
//    })));
//    public static final Collection SQL_OPERATORS = Collections.unmodifiableCollection(new TreeSet<String>(Arrays.asList(new String[]{
//            "IN", "AND", "OR", "NOT", "IS", "+", "-", "*", "/", "%",
//            ">", "<", "<=", ">=", "<>", "=", "!="
//    })));
//    private String query;
//    private String value;
//    private int start;
//    private int end;
//    public int type;
//
//    public static boolean isNumber(char c) {
//        return Character.isDigit(c) || c == '.';
//    }
//
//    public static boolean isLitteral(char c) {
//        return Character.isLetterOrDigit(c) || c == '.' || c == '_' || c == '{' || c == '}';
//    }
//
//    public static boolean isOperator(char c) {
//        return c == '=' || c == '<' || c == '>' || c == '&' || c == '|' || c == '+' || c == '-' || c == '/' || c == '*';
//    }
//
//    public static boolean isSeparator(char c) {
//        return c == ',';
//    }
//
//    public static boolean isParentheses(char c) {
//        return c == '(' || c == ')';
//    }
//
//    public SQLToken(String query, int start, int end, int type) {
//        this.query = query;
//        this.start = start;
//        this.end = end;
//        this.type = type;
//        this.value = substring(query, start, end);
//    }
//
//    private static String substring(String string, int start, int end) {
//        if (string == null || string.length() == 0)
//            return "";
//        if (start < 0)
//            start = 0;
//        if (end > string.length())
//            end = string.length();
//        if (end <= start)
//            return "";
//        else
//            return string.substring(start, end);
//    }
//
//    public String getQuery() {
//        return query;
//    }
//
//    public String getValue() {
//        return value;
//    }
//
//    public int getStart() {
//        return start;
//    }
//
//    public int getEnd() {
//        return end;
//    }
//
//    public int getType() {
//        return type;
//    }
//
//    public boolean accept(int i) {
//        return (type & i) != 0;
//    }
//
//    public boolean accept(String value, int positive, int negative) {
//        return (positive == 0 || (type & positive) != 0) && (negative == 0 || (type & negative) == 0) && (value == null || value.equals(this.value));
//    }
//
//    public String toString() {
//        String s = null;
//        switch (type) {
//            case WHITE: // '\001'
//                s = "WHITE";
//                break;
//
//            case KEYWORD: // '\002'
//                s = "KEYWORD";
//                break;
//
//            case VAR: // '\004'
//                s = "VAR";
//                break;
//
//            case KEYWORD | OPERATOR: // 'B'
//                s = "KEYWORD|OPERATOR";
//                break;
//
//            case STR: // '\b'
//                s = "STR";
//                break;
//
//            case STR_SEP: // '\020'
//                s = "STR_SEP";
//                break;
//
//            case NUM: // ' '
//                s = "NUM";
//                break;
//
//            case OPERATOR: // '@'
//                s = "OPERATOR";
//                break;
//
//            case OPEN_PAR:
//                s = "OPEN_PAR";
//                break;
//
//            case CLOSE_PAR:
//                s = "CLOSE_PAR";
//                break;
//
//            case PAR:
//                s = "PAR";
//                break;
//
//            case SEPARATOR:
//                s = "SEPARATOR";
//                break;
//
//            case UNKNOWN: // '\0'
//                s = "UNKNOWN";
//                break;
//
//            default:
//                s = "TOKEN_[" + type + "]";
//                break;
//        }
//        return s + " " + start + "," + end + ", \"" + value + "\"";
//    }
//
////    public static SQLToken getNextToken(String query, int index, boolean acceptWhite, boolean expanded) {
////
////    }
////
////    public static SQLToken getPreviousToken(String query, int index, boolean acceptWhite, boolean expanded) {
////
////    }
////
////    public static SQLToken getNearByToken(String query, int index, boolean acceptWhite, boolean expanded) {
////
////    }
//
//    public static SQLToken getForewardTokenAt(String query, int index, boolean acceptWhite, boolean expanded) {
//        if (index < 0 || index >= query.length())
//            return null;
//        int start = index;
//        int end = index + 1;
//        int type = UNKNOWN;
//        char c = query.charAt(index);
//        if (Character.isWhitespace(c)) {
//            for (; start > 0 && Character.isWhitespace(query.charAt(start - 1)); start--) ;
//            for (; end < query.length() && Character.isWhitespace(query.charAt(end)); end++) ;
//            if (!acceptWhite) {
//                return getForewardTokenAt(query, end, true, expanded);
//            } else {
//                return new SQLToken(query, start, end, WHITE);
//            }
//        }
//        if (isLitteral(c)) {
//            for (; start > 0 && isLitteral(query.charAt(start - 1)); start--) ;
//            for (; end < query.length() && isLitteral(query.charAt(end)); end++) ;
//            type = NUM;
//            for (int i = start; i < end; i++) {
//                if (isNumber(query.charAt(start)))
//                    continue;
//                type = VAR;
//                break;
//            }
//
//            if (type == VAR) {
//                String sbstr = query.substring(start, end).toUpperCase();
//                if (SQL_KEYWORDS.contains(sbstr))
//                    type = KEYWORD;
//                if (SQL_OPERATORS.contains(sbstr))
//                    type = OPERATOR | KEYWORD;
//            }
//        } else if (isOperator(c)) {
//            for (; start > 0 && isOperator(query.charAt(start - 1)); start--) ;
//            for (; end < query.length() && isOperator(query.charAt(end)); end++) ;
//            type = OPERATOR;
//        } else if (c == '(') {
//            if (expanded) {
//                int counter = 1;
//                int i = start + 1;
//                boolean doReturn;
//                for (doReturn = false; i < query.length() && !doReturn; ) {
//                    char cc = query.charAt(i);
//                    i++;
//                    switch (cc) {
//                        case '(': // '('
//                            counter++;
//                            break;
//
//                        case ')': // ')'
//                            counter--;
//                            break;
//
//                        case '\'': // '\''
//                            for (; i < query.length(); i++) {
//                                if (query.charAt(i) == '\'') {
//                                    if (i + 1 < query.length() && query.charAt(i + 1) == '\'') {
//                                        i++;
//                                    } else {
//                                        break;
//                                    }
//                                }
//                            }
//                            if (i >= query.length()) {
//                                i = -1;
//                                doReturn = true;
//                            } else {
//                                i++;
//                            }
//                            break;
//                    }
//                    if (counter == 0) {
//                        doReturn = true;
//                        break;
//                    }
//                }
//
//                end = doReturn ? i : -1;
//                type = PAR;
//            } else {
//                type = OPEN_PAR;
//            }
//        } else {
//            if (c == ')') {
//                if (expanded) {
//                    end = start + 1;
//                    int counter = -1;
//                    int i = end - 2;
//                    boolean doReturn;
//                    for (doReturn = false; i > 0 && !doReturn; i--) {
//                        char cc = query.charAt(i);
//                        switch (cc) {
//                            case '(': // '('
//                                counter++;
//                                break;
//
//                            case ')': // ')'
//                                counter--;
//                                break;
//
//                            case '\'': // '\''
//                                for (; i >= 0; i--) {
//                                    if (query.charAt(i) == '\'') {
//                                        if (i > 0 && query.charAt(i - 1) == '\'') {
//                                            i--;
//                                        } else {
//                                            break;
//                                        }
//                                    }
//                                }
//
//                                if (i <= 0) {
//                                    i = -1;
//                                    doReturn = true;
//                                } else {
//                                    i--;
//                                }
//                                break;
//                        }
//                        if (counter != 0)
//                            continue;
//                        doReturn = true;
//                        break;
//                    }
//
//                    start = doReturn ? i : -1;
//                    type = PAR;
//                } else {
//                    type = CLOSE_PAR;
//                }
//                return new SQLToken(query, start, end, type);
//            }
//            if (isSeparator(c)) {
//                for (; start > 0 && isSeparator(query.charAt(start - 1)); start--) ;
//                for (; end < query.length() && isSeparator(query.charAt(end)); end++) ;
//                type = SEPARATOR;
//            } else if (c == '\'') {
//                //corr_bug taha :
////                    for (end++; end < query.length() && query.charAt(end) != '\''; end++){
////                        if (query.charAt(end) == '\\'){
////                            end++;
////                        }
////                    }
//                while (end < query.length()) {
//                    char cc = query.charAt(end);
//                    if (cc == '\'') {
//                        if ((end + 1) < query.length() && query.charAt(end + 1) == '\'') {
//                            end++;
//                        } else {
//                            break;
//                        }
//                    }
//                    end++;
//                }
//
//                end++;
//                type = STR;
//                return new SQLToken(query, start, end, type);
//            }
//        }
//        return new SQLToken(query, start, end, type);
//    }
//
//
//    public static SQLToken findForwardToken(String query, int index, String value, int positive, int negative, boolean expanded) {
//        SQLToken token;
//        for (int i = index; i < query.length(); i = token.getEnd()) {
//            token = getForewardTokenAt(query, i, true, expanded);
//            if (token == null)
//                return null;
//            if ((positive == 0 || token.accept(positive)) && (negative == 0 || !token.accept(negative)) && (value == null || value.equals(token.getValue())))
//                return token;
//        }
//
//        return null;
//    }
//
//
//    public static SQLToken nextToken(String query, SQLToken token, boolean acceptWhites) {
//        return getForewardTokenAt(query, token != null ? token.getEnd() : 0, acceptWhites);
//    }
//
//
//    public static SQLToken getForewardTokenAt(String query, int index, boolean acceptWhite) {
//        return getForewardTokenAt(query, index, acceptWhite, true);
//    }
//
//
//    /*<--------------------------------->*/
//    public static SQLToken findBackwardToken(String query, int index, boolean expanded, String value, int positive, int negative) {
//        SQLToken token;
//        for (int i = index; i < query.length(); i = token.getStart() - 1) {
//            token = getTokenAt(query, i, true, false, expanded);
//            if (token == null)
//                return null;
//            if ((positive == 0 || token.accept(positive)) && (negative == 0 || !token.accept(negative)) && (value == null || value.equals(token.getValue())))
//                return token;
//        }
//
//        return null;
//    }
//
//
//    public static SQLToken getTokenAt(String query, int index, boolean acceptWhite, boolean forword, boolean expanded) {
//        if (index < 0 || index >= query.length())
//            return null;
//        int start = index;
//        int end = index + 1;
//        int type = UNKNOWN;
//        char c = query.charAt(index);
//        if (Character.isWhitespace(c)) {
//            for (; start > 0 && Character.isWhitespace(query.charAt(start - 1)); start--) ;
//            for (; end < query.length() && Character.isWhitespace(query.charAt(end)); end++) ;
//            if (!acceptWhite) {
//                if (forword)
//                    return getTokenAt(query, end, true, true, expanded);
//                else
//                    return getTokenAt(query, start - 1, true, false, expanded);
//            } else {
//                return new SQLToken(query, start, end, WHITE);
//            }
//        }
//        if (isLitteral(c)) {
//            for (; start > 0 && isLitteral(query.charAt(start - 1)); start--) ;
//            for (; end < query.length() && isLitteral(query.charAt(end)); end++) ;
//            type = NUM;
//            for (int i = start; i < end; i++) {
//                if (isNumber(query.charAt(start)))
//                    continue;
//                type = VAR;
//                break;
//            }
//
//            if (type == VAR) {
//                if (SQL_KEYWORDS.contains(query.substring(start, end).toUpperCase()))
//                    type = KEYWORD;
//                if (SQL_OPERATORS.contains(query.substring(start, end).toUpperCase()))
//                    type = OPERATOR | KEYWORD;
//            }
//        } else if (isOperator(c)) {
//            for (; start > 0 && isOperator(query.charAt(start - 1)); start--) ;
//            for (; end < query.length() && isOperator(query.charAt(end)); end++) ;
//            type = OPERATOR;
//        } else if (c == '(') {
//            if (expanded) {
//                int counter = 1;
//                int i = start + 1;
//                boolean doReturn;
//                for (doReturn = false; i < query.length() && !doReturn; ) {
//                    char cc = query.charAt(i);
//                    i++;
//                    switch (cc) {
//                        case '(': // '('
//                            counter++;
//                            break;
//
//                        case ')': // ')'
//                            counter--;
//                            break;
//
//                        case '\'': // '\''
//                            for (; i < query.length() && query.charAt(i) != '\''; i++)
//                                if (query.charAt(i) == '\\')
//                                    i++;
//
//                            if (i >= query.length()) {
//                                i = -1;
//                                doReturn = true;
//                            } else {
//                                i++;
//                            }
//                            break;
//                    }
//                    if (counter == 0) {
//                        doReturn = true;
//                        break;
//                    }
//                }
//
//                end = doReturn ? i : -1;
//                type = PAR;
//            } else {
//                type = OPEN_PAR;
//            }
//        } else {
//            if (c == ')') {
//                if (expanded) {
//                    end = start + 1;
//                    int counter = -1;
//                    int i = end - 2;
//                    boolean doReturn;
//                    for (doReturn = false; i > 0 && !doReturn; i--) {
//                        char cc = query.charAt(i);
//                        switch (cc) {
//                            case '(': // '('
//                                counter++;
//                                break;
//
//                            case ')': // ')'
//                                counter--;
//                                break;
//
//                            case '\'': // '\''
//                                for (; i >= 0; i--) {
//                                    if (i > 0 && query.charAt(i) == '\\') {
//                                        i--;
//                                        continue;
//                                    }
//                                    if (query.charAt(i) == '\'')
//                                        break;
//                                }
//
//                                if (i <= 0) {
//                                    i = -1;
//                                    doReturn = true;
//                                } else {
//                                    i--;
//                                }
//                                break;
//                        }
//                        if (counter != 0)
//                            continue;
//                        doReturn = true;
//                        break;
//                    }
//
//                    start = doReturn ? i : -1;
//                    type = PAR;
//                } else {
//                    type = CLOSE_PAR;
//                }
//                return new SQLToken(query, start, end, type);
//            }
//            if (isSeparator(c)) {
//                for (; start > 0 && isSeparator(query.charAt(start - 1)); start--) ;
//                for (; end < query.length() && isSeparator(query.charAt(end)); end++) ;
//                type = SEPARATOR;
//            } else if (c == '\'') {
//                StringBuilder str = new StringBuilder();
//                if (forword) {
//                    //corr_bug taha :
////                    for (end++; end < query.length() && query.charAt(end) != '\''; end++){
////                        if (query.charAt(end) == '\\'){
////                            end++;
////                        }
////                    }
//                    while (end < query.length()) {
//                        char cc = query.charAt(end);
//                        if (cc == '\'') {
//                            if ((end + 1) < query.length() && query.charAt(end + 1) == '\'') {
//                                end++;
//                            } else {
//                                break;
//                            }
//                        }
//                        str.append(cc);
//                        end++;
//                    }
//
//                    end++;
//                } else {
//                    //corr_bug taha : le \\ n'est pas un masque pour SQL
//                    for (start--; start >= 0; start--) {
//                        if (start > 0 && query.charAt(start) == '\\') {
//                            start--;
//                            continue;
//                        }
//                        if (query.charAt(start) == '\'')
//                            break;
//                    }
//
//                    if (start <= 0)
//                        start = -1;
//                    else
//                        start--;
//                }
//                type = STR;
//                return new SQLToken(query, start, end, type);
//            }
//        }
//        return new SQLToken(query, start, end, type);
//    }
//
//    public static SQLToken previousToken(String query, SQLToken token, boolean acceptWhites) {
//        return getTokenAt(query, token != null ? token.getStart() - 1 : 0, acceptWhites, false);
//    }
//
//    public static SQLToken getTokenAt(String query, int index, boolean acceptWhite, boolean forword) {
//        return getTokenAt(query, index, acceptWhite, forword, true);
//    }
//}
