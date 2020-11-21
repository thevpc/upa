package net.thevpc.upa.nuts.box;

import net.thevpc.upa.xml.UpaXml;
import net.thevpc.upa.xml.UpaXmlParser;
import net.thevpc.common.io.IOUtils;
import net.thevpc.common.mvn.*;
import net.thevpc.common.webxml.WebListener;
import net.thevpc.common.webxml.WebXml;
import net.thevpc.common.webxml.WebXmlParser;
import net.thevpc.common.webxml.WebXmlVisitorAdapter;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.xml.sax.SAXException;

import javax.xml.parsers.ParserConfigurationException;
import java.io.File;
import java.io.IOException;
import java.io.PrintStream;
import java.io.UncheckedIOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import java.util.List;

import net.thevpc.nuts.NutsApplication;
import net.thevpc.nuts.NutsApplicationContext;
import net.thevpc.nuts.NutsCommandLine;
import net.thevpc.nuts.NutsId;
import net.thevpc.nuts.NutsArgument;

public class UpaBoxMain extends NutsApplication {

    public static void main(String[] args) {
        new UpaBoxMain().runAndExit(args);
    }

    @Override
    public void run(NutsApplicationContext appContext) {
        NutsCommandLine cmd = appContext.getCommandLine();
        PrintStream out = appContext.getSession().out();
        if (cmd.isExecMode()) {
            out.printf("**%s** version **%s** (c) vpc [[2018]]\n", appContext.getAppId().getArtifactId(), appContext.getAppId().getVersion());
        }
        cmd.required();
        NutsArgument a;
        Options o = new Options();
        if (cmd.hasNext()) {
            if ((a = cmd.next("in", "install")) != null) {
                try {
                    File targetFile = null;
                    while (cmd.hasNext()) {
                        if (appContext.configureFirst(cmd)) {
                            //ok
                        } else if ((a = cmd.nextBoolean("--override-pom-xml")) != null) {
                            o.overridePomXml = a.getBooleanValue();
                        } else if ((a = cmd.nextBoolean("--override-web-xml")) != null) {
                            o.overrideWebXml = a.getBooleanValue();
                        } else if ((a = cmd.nextBoolean("--override-upa-xml")) != null) {
                            o.overrideUpaXml = a.getBooleanValue();
                        } else if ((a = cmd.nextBoolean("--no")) != null) {
                            o.interactiveValue = !a.getBooleanValue();
                            o.interactive = false;
                        } else if ((a = cmd.nextBoolean("--yes")) != null) {
                            o.interactiveValue = a.getBooleanValue();
                            o.interactive = false;
                        } else if ((a = cmd.nextBoolean("--new")) != null) {
                            o.newFile = a.getBooleanValue();
                        } else if ((a = cmd.nextBoolean("--enable-spring")) != null) {
                            o.enableSpring = a.getBooleanValue();
                        } else if ((a = cmd.nextBoolean("--recommended")) != null) {
                            o.recommended = a.getBooleanValue();
                        } else if ((a = cmd.nextString("--db-type")) != null) {
                            o.dbtype = a.getStringValue();
                        } else if ((a = cmd.next("--derby-embedded")) != null) {
                            o.dbtype = "derby:embedded";
                        } else if ((a = cmd.next("--derby")) != null) {
                            o.dbtype = "derby";
                        } else if ((a = cmd.next("--mysql")) != null) {
                            o.dbtype = "mysql";
                        } else if (!cmd.peek().isOption()) {
                            if (targetFile != null) {
                                cmd.setCommandName("install").unexpectedArgument();
                            }
                            targetFile = new File(cmd.next().getString());
                        } else {
                            cmd.setCommandName("install").unexpectedArgument();
                        }
                    }
                    if (cmd.isExecMode()) {
                        installFile(appContext, cmd, o, targetFile);
                    }
                } catch (RuntimeException e) {
                    throw e;
                } catch (Exception e) {
                    throw new RuntimeException(e);
                }

            } else {
                cmd.setCommandName("upa-box").unexpectedArgument();
            }
        }
    }

    private void installFile(NutsApplicationContext appContext, NutsCommandLine cmd, Options o, File targetFile) throws IOException, SAXException, ParserConfigurationException {
        File pomxml = null;
        File webxml = null;
        if (targetFile == null) {
            targetFile = new File(".").getCanonicalFile();
        }
        if (targetFile.isDirectory() && new File(targetFile, "pom.xml").isFile()) {
            pomxml = new File(targetFile, "pom.xml");
        } else if (targetFile.isDirectory() && new File(targetFile, "web.xml").isFile()) {
            webxml = new File(targetFile, "web.xml");
        } else if (targetFile.getName().equals("pom.xml")) {
            pomxml = targetFile;
        } else if (targetFile.getName().equals("web.xml")) {
            pomxml = targetFile;
        }
        if (pomxml == null && webxml == null) {
            throw new IllegalArgumentException("Pom File not found at " + targetFile);
        }
        if (pomxml != null) {
            Pom pom = processPomXml(appContext, pomxml, o);
            File upaxml = new File(pomxml.getParent(), "src/main/resources/META-INF/upa.xml");
            try {
                processUpaXml(appContext, upaxml, o, pom);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            if ("war".equals(pom.getPackaging())) {
                webxml = new File(pomxml.getParent(), "src/main/webapp/WEB-INF/web.xml");
            }
        }
        if (webxml != null) {
            processWebXml(appContext, webxml, o);
        }

    }

//    private static boolean enableOverride(NutsApplicationContext appContext, boolean enableOverride, Options o, String message) {
//    }
//
    private void processWebXml(final NutsApplicationContext appContext, final File webxml, final Options o) throws ParserConfigurationException, SAXException, IOException {
        if (!webxml.isFile()) {
            File newFile = webxml;
            if (o.newFile) {
                newFile = new File(webxml.getPath() + ".new");
            }
            saveString("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n"
                    + "<web-app xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" version=\"3.1\" xmlns=\"http://xmlns.jcp.org/xml/ns/javaee\"\n"
                    + "         xsi:schemaLocation=\"http://xmlns.jcp.org/xml/ns/javaee http://xmlns.jcp.org/xml/ns/javaee/web-app_3_1.xsd\">\n"
                    + "    <context-param>\n"
                    + "        <param-name>upa.web.context-url-filter</param-name>\n"
                    + "        <param-value>*.xhtml|/fs/*|/p/*|/u/*|/ws/*|/services/rss/*</param-value>\n"
                    + "    </context-param>\n"
                    + "\n"
                    + "    <listener>\n"
                    + "        <listener-class>net.thevpc.upa.web.UPAServletContextListener</listener-class>\n"
                    + "    </listener>\n"
                    + "\n"
                    + "    <session-config>\n"
                    + "        <session-timeout>\n"
                    + "            30\n"
                    + "        </session-timeout>\n"
                    + "    </session-config>\n"
                    + "    <welcome-file-list>\n"
                    + "        <welcome-file>index.xhtml</welcome-file>\n"
                    + "    </welcome-file-list>\n"
                    + "</web-app>\n", newFile, appContext, o, o.overrideWebXml, "web.xml");
            return;
        }
        WebXmlParser.parse(webxml, new WebXmlVisitorAdapter() {
            private boolean listenerOk = false;
            private boolean filterParamOk = false;

            @Override
            public void visitEndListener(Element listenerElement, WebListener listener) {
                if ("net.thevpc.upa.web.UPAServletContextListener".equals(listener.getListenerClass())) {
                    listenerOk = true;
                }
            }

            @Override
            public void visitEndContextParam(Element contextElement, String key, String val) {
//        <param-name>upa.web.context-url-filter</param-name>
//        <param-value>*.xhtml|/fs/*|/p/*|/u/*|/ws/*|/services/rss/*</param-value>

                if ("upa.web.context-url-filter".equals(key)) {
                    filterParamOk = true;
                }
            }

            @Override
            public void visitEndDocument(Document document, WebXml pom) {
                boolean save = false;
                if (!listenerOk) {
                    WebXmlParser.appendOrReplaceListener(new WebListener("net.thevpc.upa.web.UPAServletContextListener", null, null, null), null, document);
                    save = true;
                }
                if (!filterParamOk) {
                    document.getDocumentElement().appendChild(WebXmlParser.createContextParamElement(document, "upa.web.context-url-filter", "*.xhtml|/fs/*|/p/*|/u/*|/ws/*|/services/rss/*"));
                    save = true;
                }
                if (save) {
                    try {
                        File newFile = prepareCreateFile(webxml, appContext, o, o.overrideWebXml, "web.xml", null);
                        if (newFile != null) {
                            WebXmlParser.writeDocument(document, newFile);
                        }
                    } catch (RuntimeException e) {
                        throw e;
                    } catch (Exception e) {
                        throw new RuntimeException(e);
                    }
                } else {
                    appContext.getSession().out().printf("Ignore existing ==%s==\n", webxml.getPath());
                }
            }
        });
    }

    private String resolveDbtype(final NutsApplicationContext appContext, final File upaxml, final Options o) {
        String dbtype = o.dbtype;
        if (!o.recommended) {
            if (dbtype == null) {
                dbtype = "derby:embedded";
            }
        } else {
            if (dbtype == null) {
                dbtype = "mysql";
            }
        }
        return dbtype;
    }

    private String resolveCurrentConnectionString(List<UpaXml.Connection> connectionList) {
        for (UpaXml.Connection connection : connectionList) {
            Boolean enabled = connection.getEnabled();
            if (enabled == null || enabled) {
                if (connection.getConnectionString() != null && connection.getConnectionString().length() > 0) {
                    return connection.getConnectionString();
                }
            }
        }
        return null;
    }

    private String resolveCurrentConnectionString(final File upaxml) throws IOException, ParserConfigurationException, SAXException {
        if (upaxml.isFile()) {
            UpaXml p = UpaXmlParser.parse(upaxml);
            String s = resolveCurrentConnectionString(p.getConnections());
            if (s != null) {
                return s;
            }
            for (UpaXml.PersistenceUnit persistenceUnit : p.getPersistenceUnits()) {
                s = resolveCurrentConnectionString(persistenceUnit.getConnections());
                if (s != null) {
                    return s;
                }
            }
            for (UpaXml.PersistenceGroup persistenceGroup : p.getPersistenceGroups()) {
                for (UpaXml.PersistenceUnit persistenceUnit : persistenceGroup.getPersistenceUnits()) {
                    s = resolveCurrentConnectionString(persistenceUnit.getConnections());
                    if (s != null) {
                        return s;
                    }
                }
            }
        }
        return null;
    }

    private void processUpaXml(final NutsApplicationContext appContext, final File upaxml, final Options o, Pom pom) throws IOException, ParserConfigurationException, SAXException {
//        String s = resolveCurrentConnectionString(upaxml);
//        if (s != null) {
//            if(!o.interactive){
//                if(!o.interactiveValue){
//                    return;
//                }
//            }else if(!appContext.terminal().ask(NutsQuestion.forBoolean(
//                    "Could you @@confirm@@ overriding ==%s==\n", "upa.xml"
//            ).setDefautValue(false))) {
//                return;
//            }
//        }
        String dbtype = resolveDbtype(appContext, upaxml, o);
        if (!o.recommended) {
            String url = "derby:embedded://${user.home}/workspace/" + pom.getPomId().getArtifactId() + "/db;structure=create;userName=appuser;password=appsecret";
            if (!"derby:embedded".equals(dbtype)) {
                url = dbtype + "://localhost/" + pom.getPomId().getArtifactId() + "/db;structure=create;userName=appuser;password=appsecret";
            }

            saveString("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n"
                    + "<upa xmlns=\"http://github.com/thevpc/upa/upa-1.0.xsd\" version=\"1.0\">\n"
                    + "    <scan types=\"" + (pom.getPomId().getGroupId().replace("\"", "\\\"")) + ".**\"/>\n"
                    + "    <connectionString>\n"
                    + "    " + url + "\n"
                    + "    </connectionString>\n"
                    + "</upa>\n", upaxml, appContext, o, o.overrideUpaXml, "upa.xml");
        } else {
            if (dbtype == null) {
                dbtype = "mysql";
            }
            String url = "derby:embedded://${user.home}/workspace/" + pom.getPomId().getArtifactId() + "/db;structure=create;userName=appuser;password=appsecret";
            if (!"derby:embedded".equals(dbtype)) {
                url = dbtype + "://localhost/" + pom.getPomId().getArtifactId() + "/db;\n"
                        + "                structure=create;\n"
                        + "                userName=appuser;\n"
                        + "                password=appsecret;\n"
                        + "                pool=true;\n"
                        + "                poolMaxSize=200;\n"
                        + "                monitor=javamelody";
            }
            saveString("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n"
                    + "<upa xmlns=\"http://github.com/thevpc/upa/upa-1.0.xsd\" version=\"1.0\">\n"
                    + "    <scan types=\"" + (pom.getPomId().getGroupId().replace("\"", "\\\"")) + ".**\"/>\n"
                    + "    <include>\n"
                    + "        <file path=\"${user.home}/workspace/" + pom.getPomId().getArtifactId() + "/config/upa.xml\" failSafe=\"true\"/>\n"
                    + "        <!-- this is a fallback connection if the file fails to be included -->\n"
                    + "        <default>\n"
                    + "            <persistenceUnit>\n"
                    + "                <connection>\n"
                    + "                    <connectionString>\n"
                    + "                        " + url + "\n"
                    + "                    </connectionString>\n"
                    + "                </connection>\n"
                    + "            </persistenceUnit>\n"
                    + "        </default>\n"
                    + "    </include>\n"
                    + "</upa>\n", upaxml, appContext, o, o.overrideUpaXml, "upa.xml");

        }
    }

    private NutsId resolveDatabaseDriver(final NutsApplicationContext appContext, File upaxml, final Options o) throws ParserConfigurationException, SAXException, IOException {
        String s = resolveCurrentConnectionString(upaxml);
        String baseId = null;
        if (s == null) {
            s = resolveDbtype(appContext, upaxml, o);
        }
        if (s.startsWith("derby:embdedded")) {
            baseId = "org.apache.derby:derby";
        } else if (s.startsWith("derby")) {
            baseId = "org.apache.derby:derbyclient";
        } else if (s.startsWith("mysql")) {
            baseId = "mysql:mysql-connector-java";
        } else if (s.startsWith("oracle")) {
            baseId = "oracle:ojdbc6";
        } else if (s.startsWith("mssqlserver")) {
            baseId = "com.microsoft.sqlserver:mssql-jdbc#7.1.3.jre8-preview";
        } else if (s.startsWith("mssqlserver")) {
            baseId = "org.postgresql:postgresql";
        } else {
            return null;
        }
        NutsId nn = appContext.getWorkspace().search()
                .setSession(appContext.getSession())
                .addId(baseId).setLatest(true).getResultIds().required();
        if (nn != null) {
            appContext.getSession().out().printf("Detected version ==%s==\n", nn.getLongName());
        }
        return nn;
    }

    private Pom processPomXml(final NutsApplicationContext appContext, final File pomxml, final Options o) {
        try {
            //will check for dependency of db driver too!
            File upaxml = new File(pomxml.getParent(), "src/main/resources/META-INF/upa.xml");
            final NutsId dbDriver = resolveDatabaseDriver(appContext, upaxml, o);

            return new PomXmlParser().parse(pomxml, new PomDomVisitorAdapter() {
                PomDependency api = null;
                Element apiElement = null;
                PomDependency impl = null;
                Element implElement = null;
                PomDependency web = null;
                Element webElement = null;
                PomDependency spring = null;
                Element springElement = null;
                Element dbdriverElement = null;
                Element dependenciesElement = null;
                Element repositoriesElement = null;
                PomRepository gitRepositoryElement;

                @Override
                public void visitEndDependency(Element dependencyElement, PomDependency dependency) {
                    if ("net.thevpc.upa".equals(dependency.getGroupId())) {
                        if ("upa-api".equals(dependency.getArtifactId())) {
                            api = dependency;
                            apiElement = dependencyElement;
                        } else if ("upa-impl".equals(dependency.getArtifactId())) {
                            impl = dependency;
                            implElement = dependencyElement;
                        } else if ("upa-web".equals(dependency.getArtifactId())) {
                            web = dependency;
                            webElement = dependencyElement;
                        } else if ("upa-spring".equals(dependency.getArtifactId())) {
                            spring = dependency;
                            springElement = dependencyElement;
                        }
                    } else if (dbDriver != null) {
                        if (dbDriver.getGroupId().equals(dependency.getGroupId())
                                && dbDriver.getArtifactId().equals(dependency.getArtifactId())) {
                            dbdriverElement = dependencyElement;
                        }
                    }
                }

                @Override
                public void visitStartDependencies(Element dependenciesElement) {
                    this.dependenciesElement = dependenciesElement;
                }

                @Override
                public void visitStartRepositories(Element repositoriesElement) {
                    this.repositoriesElement = repositoriesElement;
                }

                @Override
                public void visitEndRepository(Element dependencyElement, PomRepository repository) {
                    if ("https://raw.github.com/thevpc/vpc-public-maven/master".equals(repository.getUrl())) {
                        gitRepositoryElement = repository;
                    }
                }

                @Override
                public void visitEndDocument(Document document, Pom pom) {
                    String action = "install";
                    boolean enableWeb = false;
                    boolean save = false;
                    switch (action) {
                        case "install": {
                            boolean generate = false;
                            if (api != null || impl != null || web != null || spring != null) {
                                if (!o.overridePomXml) {
                                    generate = true;
                                }
                            } else {
                                generate = true;
                            }
                            if (generate) {
                                if ("war".equals(pom.getPackaging())) {
                                    enableWeb = true;
                                }
                                if (dependenciesElement == null) {
                                    dependenciesElement = document.createElement("dependencies");
                                    document.getDocumentElement().appendChild(dependenciesElement);
                                }
                                PomDependency apiDep = new PomDependency("net.thevpc.upa", "upa-api", getApiVersion());
                                save |= PomXmlParser.appendOrReplaceDependency(apiDep, apiElement, dependenciesElement);
                                if (enableWeb) {
                                    save |= PomXmlParser.appendOrReplaceDependency(new PomDependency("net.thevpc.upa", "upa-web", getWarVersion(apiDep.getVersion())),
                                            webElement, dependenciesElement);
                                }
                                save |= PomXmlParser.appendOrReplaceDependency(new PomDependency("net.thevpc.upa", "upa-impl", getImplVersion(apiDep.getVersion())),
                                        implElement, dependenciesElement);
                                if (o.enableSpring) {
                                    save |= PomXmlParser.appendOrReplaceDependency(new PomDependency("net.thevpc.upa", "upa-spring", getSpringVersion(apiDep.getVersion())),
                                            springElement, dependenciesElement);
                                }
                                if (dbDriver != null) {
                                    save |= PomXmlParser.appendOrReplaceDependency(new PomDependency(dbDriver.getGroupId(), dbDriver.getArtifactId(), dbDriver.getVersion().toString()),
                                            dbdriverElement, dependenciesElement);
                                }
                                if (repositoriesElement == null) {
                                    repositoriesElement = document.createElement("repositories");
                                    document.getDocumentElement().appendChild(repositoriesElement);
                                }
                                if (gitRepositoryElement == null) {
                                    save |= PomXmlParser.appendOrReplaceRepository(new PomRepository("vpc-public-maven", null, "https://raw.github.com/thevpc/vpc-public-maven/master", null, null, null),
                                            webElement, repositoriesElement);
                                }

                            }
                        }
                    }
                    if (save) {
                        try {
                            File newFile = prepareCreateFile(pomxml, appContext, o, o.overridePomXml, "pom.xml", null);
                            if (newFile != null) {
                                PomXmlParser.writeDocument(document, newFile);
                            }
                        } catch (RuntimeException e) {
                            throw e;
                        } catch (Exception e) {
                            throw new RuntimeException(e);
                        }
                    } else {
                        appContext.getSession().out().printf("Ignore existing ==%s==\n", pomxml.getPath());
                    }
                }

                private String getSpringVersion(String apiVersion) {
                    NutsId id
                            = appContext.getWorkspace().search()
                                    .setSession(appContext.getSession())
                                    .addId("net.thevpc.upa:upa-spring").setLatest(true)
                                    .getResultIds().required();
                    appContext.getSession().out().printf("Detected version ==%s==\n", id.getLongName());
                    return id.getVersion().getValue();
                }

                private String getImplVersion(String apiVersion) {
                    NutsId id = appContext.getWorkspace().search().setSession(appContext.getSession())
                            .addId("net.thevpc.upa:upa-impl").setLatest(true)
                            .getResultIds().required();
                    appContext.getSession().out().printf("Detected version ==%s==\n", id.getLongName());
                    return id.getVersion().getValue();
                }

                private String getApiVersion() {
                    NutsId id = appContext.getWorkspace().search()
                            .setSession(appContext.getSession())
                            .addId("net.thevpc.upa:upa-api").setLatest(true)
                            .getResultIds().required();
                    appContext.getSession().out().printf("Detected version ==%s==\n", id.getLongName());
                    return id.getVersion().getValue();
                }

                private String getWarVersion(String apiVersion) {
                    NutsId id = appContext.getWorkspace().search()
                            .setSession(appContext.getSession())
                            .addId("net.thevpc.upa:upa-web").setLatest(true)
                            .getResultIds().required();
                    appContext.getSession().out().printf("Detected version ==%s==\n", id.getLongName());
                    return id.getVersion().getValue();
                }
            });

        } catch (RuntimeException e) {
            throw e;
        } catch (Exception e) {
            throw new IllegalArgumentException(e);
        }
    }

    private interface ExtraFilter {

        boolean accept(File baseFile, File newFile);
    }

    private static File prepareCreateFile(File baseFile, final NutsApplicationContext appContext, Options o, boolean overrideType, String msg, ExtraFilter extra) throws IOException {
        File newFile = baseFile;
        if (o.newFile) {
            newFile = new File(baseFile.getPath() + ".new");
        }
        if (baseFile.isFile()) {
            boolean canOverride = true;
            if (overrideType) {
                canOverride = true;
            } else if (!o.interactive) {
                canOverride = o.interactiveValue;
            }
            if (canOverride && extra != null && !extra.accept(baseFile, newFile)) {
                canOverride = false;
            }
            if (canOverride) {
                canOverride = appContext.getSession().getTerminal().ask()
                        .forBoolean("Could you @@confirm@@ override existing ==%s==", msg)
                        .setDefaultValue(false).getBooleanValue();
            }
            if (!canOverride) {
                appContext.getSession().out().printf("Ignore existing ==%s==\n", baseFile.getPath());
                return null;
            }
            appContext.getSession().out().printf("Override ==%s==\n", baseFile.getPath());
        } else {
            appContext.getSession().out().printf("Create   ==%s==\n", baseFile.getPath());
        }
        if (!o.newFile) {
            if (baseFile.exists()) {
                if (newFile.getParentFile() != null) {
                    newFile.getParentFile().mkdirs();
                }
                Files.move(baseFile.toPath(), new File(baseFile.getPath() + ".old").toPath(), StandardCopyOption.ATOMIC_MOVE, StandardCopyOption.REPLACE_EXISTING);
            }
        }
        return newFile;
    }

    public static void saveString(final String content, final File baseFile, final NutsApplicationContext appContext, Options o, boolean overrideType, String msg) throws IOException {
        File newFile = prepareCreateFile(baseFile, appContext, o, overrideType, msg, new ExtraFilter() {
            @Override
            public boolean accept(File b, File n) {
                String pp;
                try {
                    pp = IOUtils.loadString(baseFile);
                } catch (IOException ex) {
                    throw new UncheckedIOException(ex);
                }
                return (!content.equals(pp));
            }
        });
        if (newFile != null) {
            IOUtils.saveString(content, newFile);
        }
    }

    public static class Options {

        public boolean enableSpring = false;
        public String dbtype = null;
        public boolean recommended = false;
        public boolean overrideWebXml;
        public boolean overrideUpaXml;
        public boolean overridePomXml;
        public boolean interactive = true;
        public boolean interactiveValue = true;
        public boolean newFile = false;
    }

}
