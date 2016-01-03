package net.vpc.upa.upaportable;

import net.vpc.j2cs.*;
import java.io.File;
import java.io.IOException;
import java.text.DecimalFormat;
import net.vpc.j2cs.parser.ParseException;
import net.vpc.j2cs.parser.ast.body.TypeDeclaration;
import net.vpc.j2cs.project.FilterAction;
import net.vpc.j2cs.project.ItemFilter;
import net.vpc.j2cs.project.Project;

public class UPAConverterMain {

    private static File xprojects = new File("/home/vpc/Data/xprojects");

    public static void main(String[] args) {
        long start = System.currentTimeMillis();
        try {
            buildUPA(null);
//            buildUPA("DefaultUPAContext");
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        long end = System.currentTimeMillis();
        System.out.println("Elapsed time " + J2CSUtils.formatPeriodFixed(end - start));
    }





    public static void buildUPA(String filter) throws IOException, ParseException {
        buildUPA(filter, filter);
    }

    public static void buildUPA(String filterAPI,String filterImpl) throws IOException, ParseException {
        buildAPI(filterAPI);
        buildImpl(filterImpl);
    }

    public static void buildAPI(String filterAPI) throws IOException, ParseException {
        String root = xprojects + "/net/vpc/upa/upa-api";
        Project project = new Project();
        project.addMavenProject(new File(root), "net.vpc.upa");
        project.addConvertConfigurator(new UPAConverterManagerConfigurator());
        ProjectProcessor processor = new ProjectProcessor(project);
        project.getTypeDeclarationFilters().add(typeDeclarationEquals(filterAPI));
        processor.process();
    }

    public static void buildImpl(String filterImpl) throws IOException, ParseException {
        String root = xprojects + "/net/vpc/upa/upa-impl";
        Project project = new Project();
        project.addMavenProject(new File(root), "net.vpc.upa.impl");
        project.addConvertConfigurator(new UPAConverterManagerConfigurator());

        project.getTypeDeclarationFilters().add(typeDeclarationEquals(filterImpl));
        ProjectProcessor processor = new ProjectProcessor(project);
        processor.process();
    }

    private static ItemFilter<TypeDeclaration> typeDeclarationEquals(final String typeName){
        return new ItemFilter<TypeDeclaration>() {
            //@Override
            public FilterAction accept(TypeDeclaration declaration) {
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
