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



namespace Net.TheVpc.Upa.Impl.Uql.Parser.Syntax
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
    public class ParseException : Net.TheVpc.Upa.Exceptions.UPAException {





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












    }
}
