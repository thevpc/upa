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



namespace Net.TheVpc.Upa.Impl.Config.Decorations
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public interface DecorationRepository {

         void Visit(Net.TheVpc.Upa.Config.Decoration d);

         Net.TheVpc.Upa.Config.Decoration[] GetTypeDecorations(string type);

         Net.TheVpc.Upa.Config.Decoration[] GetMethodDecorations(string type, string method);

         Net.TheVpc.Upa.Config.Decoration[] GetFieldDecorations(string type, string field);

         Net.TheVpc.Upa.Config.Decoration GetFieldDecoration(System.Reflection.FieldInfo field, System.Type annType);

         Net.TheVpc.Upa.Config.Decoration GetFieldDecoration(System.Reflection.FieldInfo field, string annType);

         Net.TheVpc.Upa.Config.Decoration GetFieldDecoration(string type, string field, System.Type annType);

         Net.TheVpc.Upa.Config.Decoration GetFieldDecoration(string type, string field, string annType);

         Net.TheVpc.Upa.Config.Decoration[] GetFieldDecorations(System.Reflection.FieldInfo field);

         Net.TheVpc.Upa.Config.Decoration GetMethodDecoration(System.Reflection.MethodInfo method, System.Type annType);

         Net.TheVpc.Upa.Config.Decoration GetMethodDecoration(System.Reflection.MethodInfo method, string annType);

         Net.TheVpc.Upa.Config.Decoration GetMethodDecoration(string type, string method, string annType);

         Net.TheVpc.Upa.Config.Decoration[] GetMethodDecorations(System.Reflection.MethodInfo method);

         Net.TheVpc.Upa.Config.Decoration GetTypeDecoration(System.Type type, System.Type annType);

         Net.TheVpc.Upa.Config.Decoration GetTypeDecoration(System.Type type, string annType);

         Net.TheVpc.Upa.Config.Decoration GetTypeDecoration(string type, string annType);

         Net.TheVpc.Upa.Config.Decoration[] GetTypeDecorations(System.Type type);

         Net.TheVpc.Upa.Config.Decoration[] GetTypeDecorations(string type, string annType);

         Net.TheVpc.Upa.Config.Decoration[] GetMethodDecorations(System.Reflection.MethodInfo method, string annType);

         Net.TheVpc.Upa.Config.Decoration[] GetMethodDecorations(string type, string method, string annType);

         string[] GetTypesForDecoration(string decorationName);

         Net.TheVpc.Upa.Config.Decoration[] GetDeclaredDecorations(string decorationName);
    }
}
