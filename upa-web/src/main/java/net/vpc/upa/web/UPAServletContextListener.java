package net.vpc.upa.web;

import net.vpc.upa.Properties;
import net.vpc.upa.UPA;

import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;

/**
 * Created by vpc on 8/6/16.
 */
public class UPAServletContextListener implements ServletContextListener {
    public void contextInitialized(ServletContextEvent sce) {
        if(!UPA.getBootstrap().isContextInitialized()){
            //
            Properties properties = UPA.getBootstrap().getProperties();

            properties.setObject("upa.system.extra.ServletContext",sce.getServletContext());
            properties.setString("upa.system.type","web");
            properties.setString("upa.system.web.context-path",sce.getServletContext().getContextPath());
            properties.setString("upa.system.web.server-info",sce.getServletContext().getServerInfo());
            properties.setString("upa.system.web.root-folder",sce.getServletContext().getRealPath("/"));
            properties.setString("upa.app-folder",sce.getServletContext().getRealPath("/"));
        }
        sce.getServletContext().addFilter(UPAServletRequestFilter.class.getName(),UPAServletRequestFilter.class)
                .addMappingForUrlPatterns(
                        null,false,"/*"
                );
    }

    public void contextDestroyed(ServletContextEvent sce) {

    }
}
