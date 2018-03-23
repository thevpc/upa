package net.vpc.upa.web;

import net.vpc.upa.InvokeContext;
import net.vpc.upa.UPA;
import net.vpc.upa.VoidAction;
import net.vpc.upa.exceptions.ExecutionException;

import javax.servlet.*;
import javax.servlet.http.HttpServletRequest;
import java.io.IOException;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by vpc on 5/19/16.
 */
//@WebFilter("/*")
public class UPAServletRequestFilter implements Filter {
    private Pattern pattern;
    private UPAWebContextSwitch switcher;
    public void init(FilterConfig filterConfig) throws ServletException {
        WebUPAContext.fallBackContext.setServletContext(filterConfig.getServletContext());
        String filter = filterConfig.getServletContext().getInitParameter("upa.web.context-url-filter");
        if(filter!=null && filter.trim().length()>0) {
            pattern = Pattern.compile(WebHelper.simpexpToRegexp(filter.trim()));
        }
        String switcherType = filterConfig.getServletContext().getInitParameter("upa.web.context-switch");
        if(switcherType!=null){
            switcherType=switcherType.trim();
            if(switcherType.length()>0){
                try {
                    switcher=(UPAWebContextSwitch) Class.forName(switcherType,true,Thread.currentThread().getContextClassLoader()).getDeclaredConstructor().newInstance();
                } catch (Exception e) {
                    throw new ServletException("Unable to instantiate context switch",e);
                }
            }
        }
    }
    public void doFilter(final ServletRequest request, final ServletResponse response, final FilterChain chain) throws IOException, ServletException {
        HttpServletRequest httpServletRequest=(HttpServletRequest) request;
        boolean enabledContext=true;
        if(pattern!=null){
            try {
                String sp=httpServletRequest.getServletPath();
                if(sp==null){
                    sp="";
                }
                String p = httpServletRequest.getPathInfo();
                if(p!=null && p.length()>0){
                    if(!p.startsWith("/")){
                        sp+="/";
                    }
                    sp+=p;
                }
                Matcher matcher = pattern.matcher(sp);
                if(!matcher.matches()){
                    enabledContext=false;
                }
            }catch(Exception e){
                //
            }
        }
        if(enabledContext){
            InvokeContext invokeContext=null;
            if(switcher!=null){
                invokeContext = switcher.createInvokeContext(request);
                if(invokeContext==null){
                    enabledContext=false;
                }
            }
            if(enabledContext) {
                WebUPAContext nfo = new WebUPAContext();
                nfo.setServletContext(request.getServletContext());
                nfo.setRequest((HttpServletRequest) request);
                WebUPAContext.Current.set(nfo);
                try {
                    UPA.getContext().invoke(new VoidAction() {
                        public void run() {
                            try {
                                chain.doFilter(request, response);
                            } catch (Throwable e) {
                                throw new ExecutionException(e);
                            }
                        }
                    }, invokeContext);
                } catch (ExecutionException e) {
                    Throwable cause = e.getCause();
                    if (cause instanceof IOException) {
                        throw (IOException) cause;
                    }
                    if (cause instanceof ServletException) {
                        ServletException cause1 = (ServletException) cause;
//                    Throwable rootCause = cause1.getRootCause();
//                    if(rootCause instanceof ViewExpiredException){
//
//                    }
                        throw cause1;
                    }
                    throw e;
                } finally {
                    WebUPAContext.Current.set(null);
                }
            }else{
                chain.doFilter(request, response);
            }
        }else{
            chain.doFilter(request, response);
        }
    }

    public void destroy() {
        WebUPAContext.fallBackContext.setServletContext(null);
        UPA.close();
    }
}
