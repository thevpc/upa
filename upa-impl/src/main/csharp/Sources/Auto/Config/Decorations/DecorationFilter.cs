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



namespace Net.Vpc.Upa.Impl.Config.Decorations
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public interface DecorationFilter {

         bool AcceptTypeDecoration(string name, string targetType, object @value);

        /**
             * when true acceptMethodDecoration and acceptFieldDecoration will not be
             * invoked if acceptTypeDecoration returns false
             *
             * @return
             */
         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.Config.DecorationTarget> GetDecorationTargets();

         bool AcceptMethodDecoration(string name, string targetMethod, string targetType, object @value);

         bool AcceptFieldDecoration(string name, string targetField, string targetType, object @value);
    }
}
