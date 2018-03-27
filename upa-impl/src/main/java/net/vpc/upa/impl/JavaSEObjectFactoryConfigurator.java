/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.ObjectFactory;
import net.vpc.upa.ObjectFactoryConfigurator;
import net.vpc.upa.bulk.SheetFormatter;
import net.vpc.upa.bulk.SheetParser;
import net.vpc.upa.impl.bulk.sheet.ExternalFormatHelper;
import net.vpc.upa.impl.bulk.sheet.DefaultSheetFormatter;
import net.vpc.upa.impl.bulk.sheet.DefaultSheetParser;
import net.vpc.upa.impl.bulk.sheet.PoiExternalFormatHelper;
import net.vpc.upa.impl.util.PlatformTypeProxy;
import net.vpc.upa.impl.util.cglib.PlatformTypeProxyJavaCGLib;

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
