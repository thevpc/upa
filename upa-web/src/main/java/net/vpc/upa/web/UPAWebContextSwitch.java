package net.vpc.upa.web;

import net.vpc.upa.InvokeContext;

import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;

public interface UPAWebContextSwitch {
    InvokeContext createInvokeContext(ServletRequest request);
}
