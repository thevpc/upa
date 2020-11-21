package net.thevpc.upa.upaportable;

import net.thevpc.j2cs.*;
import java.io.File;
import java.io.IOException;

import net.thevpc.j2cs.parser.ParseException;
import net.thevpc.j2cs.parser.ast.body.TypeDeclaration;
import net.thevpc.j2cs.project.FilterAction;
import net.thevpc.j2cs.project.ItemFilterAction;
import net.thevpc.j2cs.project.Project;
import net.thevpc.j2cs.util.J2CSUtils;

public class UPAConverterMain {

    private static File xprojects = new File("/data/vpc/Data/xprojects");

    public static void main(String[] args) {
        long start = System.currentTimeMillis();
        try {
            //"DecorationEntityDescriptorResolver"
            buildUPA("FieldDesc",false);
//            buildUPA("Date",false);
//            buildUPA("PersistenceUnit",true);
//            buildUPA("EntityException");
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        long end = System.currentTimeMillis();
        System.out.println("Elapsed time " + J2CSUtils.formatPeriodFixed(end - start));
    }





    public static void buildUPA(String filter,boolean erase) throws IOException, ParseException {
        buildAPI(filter,erase);
//        buildImpl(filter, erase);
    }

    public static void buildAPI(String filterAPI,boolean erase) throws IOException, ParseException {
        String root = xprojects + "/net/thevpc/upa/upa-api";
        Project project = new Project("upa-api");
        project.addMavenProject(new File(root), "net.thevpc.upa");
        project.addConvertConfigurator(new UPAConverterManagerConfigurator());
        project.getTypeDeclarationFilters().add(typeDeclarationEquals(filterAPI));

        ProjectProcessor processor = new ProjectProcessor(project);
        processor.setErase(erase);
        processor.process();
    }

    public static void buildImpl(String filterImpl,boolean erase) throws IOException, ParseException {
        String root = xprojects + "/net/thevpc/upa/upa-core";
        Project project = new Project("upa-core");
        project.addMavenProject(new File(root), "net.thevpc.upa.impl");
        project.addConvertConfigurator(new UPAConverterManagerConfigurator());

        project.getTypeDeclarationFilters().add(typeDeclarationEquals(filterImpl));
        ProjectProcessor processor = new ProjectProcessor(project);
        processor.setErase(erase);
        processor.process();
    }

    private static ItemFilterAction<TypeDeclaration> typeDeclarationEquals(final String typeName){
        return new ItemFilterAction<TypeDeclaration>() {
            //@Override
            public FilterAction acceptAction(TypeDeclaration declaration) {
//                NameExpr pck = declaration.getPackage();
                String name = declaration.getName();
                String expectedName = typeName;
                if (expectedName == null || name.equals(expectedName)) {
                    return FilterAction.ACCEPT;
                }
                return FilterAction.REJECT;
            }
        };
    }


}
