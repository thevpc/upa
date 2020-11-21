/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl;

import net.thevpc.upa.impl.bulk.sheet.DefaultSheetFormatter;
import net.thevpc.upa.impl.bulk.sheet.DefaultSheetParser;
import net.thevpc.upa.impl.bulk.sheet.ExternalFormatHelper;
import net.thevpc.upa.impl.bulk.sheet.PoiExternalFormatHelper;
import net.thevpc.upa.impl.util.PlatformTypeProxy;
import net.thevpc.upa.impl.util.cglib.PlatformTypeProxyJavaCGLib;
import net.thevpc.upa.ObjectFactory;
import net.thevpc.upa.ObjectFactoryConfigurator;
import net.thevpc.upa.bulk.SheetFormatter;
import net.thevpc.upa.bulk.SheetParser;

/**
 *
 * @author vpc
 */
public class JavaSEObjectFactoryConfigurator implements ObjectFactoryConfigurator {

    @Override
    public void configure(ObjectFactory factory) {
        factory.register(ExternalFormatHelper.class, PoiExternalFormatHelper.class);
        factory.register(PlatformTypeProxy.class, PlatformTypeProxyJavaCGLib.class);
        factory.register(SheetParser.class, DefaultSheetParser.class);
        factory.register(SheetFormatter.class, DefaultSheetFormatter.class);
    }

    @Override
    public int getContextSupportLevel() {
        return 1;
    }

}
