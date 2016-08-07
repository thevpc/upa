/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.web;

import java.util.HashMap;
import java.util.Map;
import javax.servlet.ServletContext;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class WebUPAContext {

    public final static WebUPAContext fallBackContext = new WebUPAContext();
    public final static ThreadLocal<WebUPAContext> Current = new ThreadLocal<WebUPAContext>();
    public final static ThreadLocal<Map<String, Object>> currentRequestAttributes = new ThreadLocal<Map<String, Object>>();
    public final static ThreadLocal<Map<String, Object>> currentSessionAttributes = new ThreadLocal<Map<String, Object>>();
    public final static Map<String, Object> currentAppAttributes = new HashMap<String, Object>();
    private HttpServletRequest request;
    private ServletContext servletContext;

    public HttpServletRequest getRequest() {
        return request;
    }

    public void setRequest(HttpServletRequest request) {
        this.request = request;
    }

    public ServletContext getServletContext() {
        return servletContext;
    }

    public void setServletContext(ServletContext servletContext) {
        this.servletContext = servletContext;
    }

    public static WebUPAContext getSafeWebUPAContext() {
        WebUPAContext c = Current.get();
        if (c == null) {
            c = fallBackContext;
        }
        return c;
    }

    public static Object getRequestAttribute(String name) {
        WebUPAContext c = getSafeWebUPAContext();
        HttpServletRequest r = c.getRequest();
        if (r != null) {
            return r.getAttribute(name);
        }
        ServletContext sc = c.getServletContext();
        if (sc != null) {
            return sc.getAttribute(name);
        }
        Map<String, Object> m = currentRequestAttributes.get();
        if (m != null) {
            return m.get(name);
        }
        return null;
    }

    public static void setRequestAttribute(String name, Object value) {
        WebUPAContext c = getSafeWebUPAContext();
        HttpServletRequest r = c.getRequest();
        if (r != null) {
            if (value != null) {
                r.setAttribute(name, value);
            } else {
                r.removeAttribute(name);
            }
            return;
        }
        ServletContext sc = c.getServletContext();
        if (sc != null) {
            if (value != null) {
                sc.setAttribute(name, value);
            } else {
                sc.removeAttribute(name);
            }
            return;
        }

        if (value != null) {
            Map<String, Object> m = currentRequestAttributes.get();
            if (m == null) {
                m = new HashMap<String, Object>();
                currentRequestAttributes.set(m);
            }
            m.put(name, value);
        } else {
            Map<String, Object> m = currentRequestAttributes.get();
            if (m != null) {
                m.remove(name);
            }
        }
    }

    public static Object getSessionAttribute(String name) {
        WebUPAContext c = getSafeWebUPAContext();
        HttpServletRequest r = c.getRequest();
        if (r != null) {
            HttpSession session = r.getSession();
            return session.getAttribute(name);
        }
        ServletContext sc = c.getServletContext();
        if (sc != null) {
            return sc.getAttribute(name);
        }
        Map<String, Object> m = currentSessionAttributes.get();
        if (m != null) {
            return m.get(name);
        }
        return null;
    }

    public static void setSessionAttribute(String name, Object value) {
        WebUPAContext c = getSafeWebUPAContext();
        HttpServletRequest r = c.getRequest();
        if (r != null) {
            HttpSession session = r.getSession();
            if (value != null) {
                session.setAttribute(name, value);
            } else {
                session.removeAttribute(name);
            }
            return;
        }
        ServletContext sc = c.getServletContext();
        if (sc != null) {
            if (value != null) {
                sc.setAttribute(name, value);
            } else {
                sc.removeAttribute(name);
            }
            return;
        }

        if (value != null) {
            Map<String, Object> m = currentSessionAttributes.get();
            if (m == null) {
                m = new HashMap<String, Object>();
                currentSessionAttributes.set(m);
            }
            m.put(name, value);
        } else {
            Map<String, Object> m = currentSessionAttributes.get();
            if (m != null) {
                m.remove(name);
            }
        }
    }

    public static Object getApplicationAttribute(String name) {
        WebUPAContext c = getSafeWebUPAContext();
        ServletContext sc = c.getServletContext();
        if (sc != null) {
            return sc.getAttribute(name);
        }
        Map<String, Object> m = currentAppAttributes;
        if (m != null) {
            return m.get(name);
        }
        return null;
    }

    public static void setApplicationAttribute(String name, Object value) {
        WebUPAContext c = getSafeWebUPAContext();
        ServletContext sc = c.getServletContext();
        if (sc != null) {
            if (value != null) {
                sc.setAttribute(name, value);
            } else {
                sc.removeAttribute(name);
            }
            return;
        }

        if (value != null) {
            currentAppAttributes.put(name, value);
        } else {
            currentAppAttributes.remove(name);
        }
    }
}
