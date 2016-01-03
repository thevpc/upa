/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.decorations;

import net.vpc.upa.config.Decoration;
import java.util.List;
import java.util.Map;

/**
 *
 * @author vpc
 */
class DefaultDecorationRepositoryTypeInfo {
    String typeName;
    List<Decoration> decorations;
    Map<String, List<Decoration>> methods;
    Map<String, List<Decoration>> fields;
    
}
