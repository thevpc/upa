/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Impl.Uql.Parser.Syntax
{

    /** Token Manager Error. */
    public class TokenMgrError : System.Exception {



        /**
           * Lexical error occurred.
           */
        internal const int LEXICAL_ERROR = 0;

        /**
           * An attempt was made to create a second instance of a static token manager.
           */
        internal const int STATIC_LEXER_ERROR = 1;

        /**
           * Tried to change to an invalid lexical state.
           */
        internal const int INVALID_LEXICAL_STATE = 2;

        /**
           * Detected (and bailed out of) an infinite loop in the token manager.
           */
        internal const int LOOP_DETECTED = 3;

        /**
           * Indicates the reason why the exception is thrown. It will have
           * one of the above 4 values.
           */
        internal int errorCode;

        /**
           * Replaces unprintable characters by their escaped (or unicode escaped)
           * equivalents in the given string
           */
        protected internal static string AddEscapes(string str) {
            System.Text.StringBuilder retval = new System.Text.StringBuilder();
            char ch;
            for (int i = 0; i < (str).Length; i++) {
                switch(str[i]) {
                    case (char)0:
                        continue;
                        break;
                    case '\b':
                        retval.Append("\\b");
                        continue;
                        break;
                    case '\t':
                        retval.Append("\\t");
                        continue;
                        break;
                    case '\n':
                        retval.Append("\\n");
                        continue;
                        break;
                    case '\f':
                        retval.Append("\\f");
                        continue;
                        break;
                    case '\r':
                        retval.Append("\\r");
                        continue;
                        break;
                    case '\"':
                        retval.Append("\\\"");
                        continue;
                        break;
                    case '\'':
                        retval.Append("\\\'");
                        continue;
                        break;
                    case '\\':
                        retval.Append("\\\\");
                        continue;
                        break;
                    default:
                        if ((ch = str[i]) < 0x20 || ch > 0x7e) {
                            string s = "0000" + System.Convert.ToString(ch, 16);
                            retval.Append("\\u" + s.Substring((s).Length - 4, (s).Length));
                        } else {
                            retval.Append(ch);
                        }
                        continue;
                        break;
                }
            }
            return retval.ToString();
        }

        /**
           * Returns a detailed message for the Error when it is thrown by the
           * token manager to indicate a lexical error.
           * Parameters :
           *    EOFSeen     : indicates if EOF caused the lexical error
           *    curLexState : lexical state in which this error occurred
           *    errorLine   : line number when the error occurred
           *    errorColumn : column number when the error occurred
           *    errorAfter  : prefix that was seen before this error occurred
           *    curchar     : the offending character
           * Note: You can customize the lexical error message by modifying this method.
           */
        protected internal static string LexicalError(bool EOFSeen, int lexState, int errorLine, int errorColumn, string errorAfter, char curChar) {
            return ("Lexical error at line " + errorLine + ", column " + errorColumn + ".  Encountered: " + (EOFSeen ? "<EOF> " : ("\"" + AddEscapes(System.Convert.ToString(curChar)) + "\"") + " (" + (int) curChar + "), ") + "after : \"" + AddEscapes(errorAfter) + "\"");
        }

        /** No arg constructor. */
        public TokenMgrError() {
        }

        /** Constructor with message and reason. */
        public TokenMgrError(string message, int reason)  : base(message){

            errorCode = reason;
        }

        /** Full Constructor. */
        public TokenMgrError(bool EOFSeen, int lexState, int errorLine, int errorColumn, string errorAfter, char curChar, int reason)  : this(LexicalError(EOFSeen, lexState, errorLine, errorColumn, errorAfter, curChar), reason){

        }
    }
}
