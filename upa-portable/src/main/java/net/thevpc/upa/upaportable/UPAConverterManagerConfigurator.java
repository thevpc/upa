package net.thevpc.upa.upaportable;


import net.thevpc.j2cs.csharp.CSharpVisitor;
import net.thevpc.j2cs.model.ConvertContext;
import net.thevpc.j2cs.SourcePrinter;
import net.thevpc.j2cs.csharp.converters.ConstructorConverter;
import net.thevpc.j2cs.csharp.converters.ConvertManager;
import net.thevpc.j2cs.csharp.converters.MethodConverter;
import net.thevpc.j2cs.csharp.converters.methods.MethodNameConverter;
import net.thevpc.j2cs.model.ClassTypeName;
import net.thevpc.j2cs.model.ConstructorInfo;
import net.thevpc.j2cs.model.MethodInfo;
import net.thevpc.j2cs.parser.ast.Node;
import net.thevpc.j2cs.parser.ast.expr.MethodCallExpr;
import net.thevpc.j2cs.parser.ast.expr.ObjectCreationExpr;
import net.thevpc.j2cs.project.ConvertConfigurator;

import java.lang.reflect.Modifier;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/22/12 9:26 PM
 */
public class UPAConverterManagerConfigurator implements ConvertConfigurator {

    public void configure(ConvertManager c) {
//        c.addTypeNameConverter("java.net.URL", "net.thevpc.upa.Types.URL");
        c.addTypeNameConverter("java.util.Calendar", "net.thevpc.upa.Types.Calendar");
        c.addTypeNameConverter("java.util.Date", "net.thevpc.upa.Types.Temporal");
        c.addTypeNameConverter("java.sql.Time", "net.thevpc.upa.Types.Time");
        c.addTypeNameConverter("java.sql.Timestamp", "net.thevpc.upa.Types.Timestamp");
        c.addTypeNameConverter("java.sql.Date", "net.thevpc.upa.Types.Date");
        c.addTypeNameConverter("java.beans.PropertyChangeListener", "net.thevpc.upa.PropertyChangeListener");
        c.addTypeNameConverter("java.beans.PropertyChangeEvent", "net.thevpc.upa.PropertyChangeEvent");
        c.addTypeNameConverter("java.beans.PropertyChangeSupport", "net.thevpc.upa.PropertyChangeSupport");


        c.addMethodConverter(new MethodNameConverter("java.util.Calendar", "getTimeInMillis", "GetTime"));
        c.addMethodConverter(new MethodConverter("java.util.Date", "setTime") {
            @Override
            public void convert(MethodCallExpr n, MethodInfo method, ConvertContext convertContext) {
                SourcePrinter printer = convertContext.getPrinter();
                if (n.getScope() != null) {
                    n.getScope().accept(convertContext.getVisitor(), convertContext.getVisitorArg());
                    printer.print(".");
                }
                printer.print("time=new System.DateTime");
                convertContext.getVisitor().visitArguments(n.getArgs(), convertContext.getVisitorArg());
            }
        });
        c.addMethodConverter(new MethodConverter("net.thevpc.upa.FlagSets", null) {
            @Override
            public boolean accept(MethodCallExpr n, MethodInfo method, ConvertContext convertContext) {
                return Modifier.isStatic(n.getMethod().getModifiers());
            }

            @Override
            protected void visitArguments(MethodCallExpr n, MethodInfo method, ConvertContext convertContext) {
                SourcePrinter printer = convertContext.getPrinter();
                String name = method.getName();
                if (name.equals("noneOf") || name.equals("ofType") || name.equals("allOf")) {
                    printer.print("()");
                } else {
                    super.visitArguments(n, method, convertContext);
                }
            }
        });
        c.addConstructorConverter(new
                                          ConstructorConverter("java.util.Date") {
                                              @Override
                                              public boolean accept(Node n, ConstructorInfo constructor, ConvertContext visitor) {
                                                  return n instanceof ObjectCreationExpr;
                                              }

                                              @Override
                                              public void convert(ObjectCreationExpr n, ConstructorInfo constructor, ConvertContext convertContext) {
                                                  CSharpVisitor visitor = convertContext.getVisitor();
                                                  SourcePrinter printer = convertContext.getPrinter();
                                                  printer.print("new ");
                                                  Object arg = convertContext.getVisitorArg();
                                                  visitor.visitTypeArgs(n.getTypeArgs(), arg);
                                                  printer.print(convertContext.getConvertManager().csTypeToString(new ClassTypeName("net.thevpc.upa.Types.DateTime"), convertContext));

                                                  visitor.visitArguments(n.getArgs(), arg);

                                                  if (n.getAnonymousClassBody() != null) {
                                                      printer.println(" {");
                                                      printer.indent();
                                                      visitor.visitMembers(n.getAnonymousClassBody(), arg);
                                                      printer.unindent();
                                                      printer.print("}");
                                                  }
                                              }
                                          });
    }

}
