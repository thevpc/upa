/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort
 * to raise programming language frameworks managing relational data in
 * applications using Java Platform, Standard Edition and Java Platform,
 * Enterprise Edition and Dot Net Framework equally to the next level of
 * handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while
 * affording to make changes at runtime of those data structures.
 * Besides, UPA has learned considerably of the leading ORM
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
 * failures to satisfy very common even known to be trivial requirement in
 * enterprise applications.
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.types;

import net.vpc.upa.DataTypeInfo;
import net.vpc.upa.PortabilityHint;

/**
 * User: taha Date: 16 juin 2003 Time: 15:47:42
 */
public class FileType extends LOBType {

    @PortabilityHint(target = "C#", name = "new")
    public static final FileType DEFAULT = new FileType("FILE", null, null, true);
    private Integer maxSize;
    private String[] extensions;

    public FileType(String name, boolean nullable) {
        this(name, -1, null, nullable);
    }

    public FileType(String name, Integer maxSize, String[] extensions, boolean nullable) {
        super(name, FileData.class, nullable);
        this.maxSize = maxSize;
        this.extensions = extensions;
    }

    @Override
    public void check(Object value, String name, String description)
            throws ConstraintsException {
        super.check(value, name, description);
        if (value == null) {
            return;
        }
        if (!(value instanceof FileData)) {
            throw new ConstraintsException("InvalidCast", name, description, value, maxSize);
        }
        FileData fileData = ((FileData) value);
        String fileName = fileData.getSourceName();
        if (extensions != null && extensions.length != 0 && fileName != null) {
            boolean ok = false;
            String fileExt = __getFileExtension(fileName).toLowerCase();
            for (String extension : extensions) {
                if (extension.toLowerCase().equals(fileExt)) {
                    ok = true;
                    break;
                }
            }
            if (!ok) {
                throw new ConstraintsException("FileBadExtension", name, description, value, fileExt);
            }
        }
        if (getMaxSize() > 0 && getMaxSize() < ((FileData) value).size()) {
            throw new ConstraintsException("FileSizeTooBig", name, description, value, maxSize);
        }
    }

    public void setExtensions(String[] extensions) {
        this.extensions = extensions;
    }

    public String[] getExtensions() {
        return extensions;
    }

    public Integer getMaxSize() {
        return maxSize;
    }

    public void setMaxSize(Integer maxSize) {
        this.maxSize = maxSize;
    }

    private static String __getFileExtension(String fileName) {
        int x = fileName.lastIndexOf('.');
        if (x > 0) {
            if (x + 1 < fileName.length()) {
                return fileName.substring(x + 1);
            } else {
                return "";
            }
        } else {
            return "";
        }
    }

    @Override
    public DataTypeInfo getInfo() {
        DataTypeInfo d = super.getInfo();
        if(maxSize!=null) {
            d.getProperties().put("maxSize", String.valueOf(maxSize));
        }
        if(extensions!=null){
            StringBuilder s=new StringBuilder();
            for (int i = 0; i < extensions.length; i++) {
                if(i>0){
                    s.append(",");
                }
                String extension = extensions[i];
                s.append(extension);
            }
            d.getProperties().put("extensions", String.valueOf(s));
        }
        return d;
    }

}
