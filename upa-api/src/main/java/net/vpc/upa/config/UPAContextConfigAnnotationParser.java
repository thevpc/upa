/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.config;

import net.vpc.upa.persistence.UPAContextConfig;

/**
 *
 * @author vpc
 */
public interface UPAContextConfigAnnotationParser {
    UPAContextConfig parse(Class clazz);
}
