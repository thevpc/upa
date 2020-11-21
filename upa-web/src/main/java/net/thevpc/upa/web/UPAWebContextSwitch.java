package net.thevpc.upa.web;

import net.thevpc.upa.InvokeContext;

import javax.servlet.ServletRequest;

public interface UPAWebContextSwitch {
    InvokeContext createInvokeContext(ServletRequest request);
}
