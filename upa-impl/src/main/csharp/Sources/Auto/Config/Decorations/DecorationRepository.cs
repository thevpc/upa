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
     * @author vpc
     */
    public interface DecorationRepository {

         void Visit(Net.Vpc.Upa.Config.Decoration d);

         Net.Vpc.Upa.Config.Decoration[] GetTypeDecorations(string type);

         Net.Vpc.Upa.Config.Decoration[] GetMethodDecorations(string type, string method);

         Net.Vpc.Upa.Config.Decoration[] GetFieldDecorations(string type, string field);

         Net.Vpc.Upa.Config.Decoration GetFieldDecoration(System.Reflection.FieldInfo field, System.Type annType);

         Net.Vpc.Upa.Config.Decoration GetFieldDecoration(System.Reflection.FieldInfo field, string annType);

         Net.Vpc.Upa.Config.Decoration GetFieldDecoration(string type, string field, System.Type annType);

         Net.Vpc.Upa.Config.Decoration GetFieldDecoration(string type, string field, string annType);

         Net.Vpc.Upa.Config.Decoration[] GetFieldDecorations(System.Reflection.FieldInfo field);

         Net.Vpc.Upa.Config.Decoration GetMethodDecoration(System.Reflection.MethodInfo method, System.Type annType);

         Net.Vpc.Upa.Config.Decoration GetMethodDecoration(System.Reflection.MethodInfo method, string annType);

         Net.Vpc.Upa.Config.Decoration GetMethodDecoration(string type, string method, string annType);

         Net.Vpc.Upa.Config.Decoration[] GetMethodDecorations(System.Reflection.MethodInfo method);

         Net.Vpc.Upa.Config.Decoration GetTypeDecoration(System.Type type, System.Type annType);

         Net.Vpc.Upa.Config.Decoration GetTypeDecoration(System.Type type, string annType);

         Net.Vpc.Upa.Config.Decoration GetTypeDecoration(string type, string annType);

         Net.Vpc.Upa.Config.Decoration[] GetTypeDecorations(System.Type type);

         Net.Vpc.Upa.Config.Decoration[] GetTypeDecorations(string type, string annType);

         Net.Vpc.Upa.Config.Decoration[] GetMethodDecorations(System.Reflection.MethodInfo method, string annType);

         Net.Vpc.Upa.Config.Decoration[] GetMethodDecorations(string type, string method, string annType);

         string[] GetTypesForDecoration(string decorationName);

         Net.Vpc.Upa.Config.Decoration[] GetDeclaredDecorations(string decorationName);
    }
}
