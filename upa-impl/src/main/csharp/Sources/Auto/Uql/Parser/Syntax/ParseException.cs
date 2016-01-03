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


    /**
     * This exception is thrown when parse errors are encountered.
     * You can explicitly create objects of this exception type by
     * calling the method generateParseException in the generated
     * parser.
     *
     * You can modify this class to customize your error reporting
     * mechanisms so long as you retain the public fields.
     */
    public class ParseException : Net.Vpc.Upa.Exceptions.UPAException {



        /**
           * This constructor is used by the method "generateParseException"
           * in the generated parser.  Calling this constructor generates
           * a new object of this type with the fields "currentToken",
           * "expectedTokenSequences", and "tokenImage" set.
           */
        public ParseException(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token currentTokenVal, int[][] expectedTokenSequencesVal, string[] tokenImageVal)  : base(Initialise(currentTokenVal, expectedTokenSequencesVal, tokenImageVal)){

            currentToken = currentTokenVal;
            expectedTokenSequences = expectedTokenSequencesVal;
            tokenImage = tokenImageVal;
        }

        /**
           * The following constructors are for use by you for whatever
           * purpose you can think of.  Constructing the exception in this
           * manner makes the exception behave in the normal way - i.e., as
           * documented in the class "Throwable".  The fields "errorToken",
           * "expectedTokenSequences", and "tokenImage" do not contain
           * relevant information.  The JavaCC generated code does not use
           * these constructors.
           */
        public ParseException()  : base(){

        }

        /** Constructor with message. */
        public ParseException(string message)  : base(message){

        }

        /**
           * This is the last token that has been consumed successfully.  If
           * this object has been created due to a parse error, the token
           * followng this token will (therefore) be the first error token.
           */
        public Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token currentToken;

        /**
           * Each entry in this array is an array of integers.  Each array
           * of integers represents a sequence of tokens (by their ordinal
           * values) that is expected at this point of the parse.
           */
        public int[][] expectedTokenSequences;

        /**
           * This is a reference to the "tokenImage" array of the generated
           * parser within which the parse error occurred.  This array is
           * defined in the generated ...Constants interface.
           */
        public string[] tokenImage;

        /**
           * It uses "currentToken" and "expectedTokenSequences" to generate a parse
           * error message and returns it.  If this object has been created
           * due to a parse error, and you do not catch it (it gets thrown
           * from the parser) the correct error message
           * gets displayed.
           */
        private static string Initialise(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token currentToken, int[][] expectedTokenSequences, string[] tokenImage) {
            string eol = Net.Vpc.Upa.Impl.Util.PlatformUtils.GetSystemLineSeparator();
            System.Text.StringBuilder expected = new System.Text.StringBuilder();
            int maxSize = 0;
            for (int i = 0; i < expectedTokenSequences.Length; i++) {
                if (maxSize < expectedTokenSequences[i].Length) {
                    maxSize = expectedTokenSequences[i].Length;
                }
                for (int j = 0; j < expectedTokenSequences[i].Length; j++) {
                    expected.Append(tokenImage[expectedTokenSequences[i][j]]).Append(' ');
                }
                if (expectedTokenSequences[i][expectedTokenSequences[i].Length - 1] != 0) {
                    expected.Append("...");
                }
                expected.Append(eol).Append("    ");
            }
            string retval = "Encountered \"";
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token tok = currentToken.next;
            for (int i = 0; i < maxSize; i++) {
                if (i != 0) retval += " ";
                if (tok.kind == 0) {
                    retval += tokenImage[0];
                    break;
                }
                retval += " " + tokenImage[tok.kind];
                retval += " \"";
                retval += Add_escapes(tok.image);
                retval += " \"";
                tok = tok.next;
            }
            retval += "\" at line " + currentToken.next.beginLine + ", column " + currentToken.next.beginColumn;
            retval += "." + eol;
            if (expectedTokenSequences.Length == 1) {
                retval += "Was expecting:" + eol + "    ";
            } else {
                retval += "Was expecting one of:" + eol + "    ";
            }
            retval += expected.ToString();
            return retval;
        }

        /**
           * The end of line string for this machine.
           */
        protected internal string eol = Net.Vpc.Upa.Impl.Util.PlatformUtils.GetSystemLineSeparator();

        /**
           * Used to convert raw characters to their escaped version
           * when these raw version cannot be used as part of an ASCII
           * string literal.
           */
        internal static string Add_escapes(string str) {
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
    }
}
