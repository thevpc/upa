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
package net.thevpc.upa.types;

import net.thevpc.upa.PortabilityHint;

import java.io.*;
import java.net.URL;

@PortabilityHint(target = "C#", name = "partial")
public class FileData implements Serializable {
    @PortabilityHint(target = "C#", name = "suppress")
    public static final long serialVersionUID = 1L;
    protected byte[] data;
    protected String sourceName;

    public FileData(String sourceName, byte[] data) {
        this.sourceName = sourceName;
        this.data = data != null ? data : new byte[0];
    }

    @PortabilityHint(target = "C#", name = "suppress")
    public FileData(File file) throws IOException {
        load(file.getName(), new FileInputStream(file));
    }

    public FileData(InputStream inputStream) throws IOException {
        load(null, inputStream);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    public FileData(String file) throws IOException {
        load(file, new FileInputStream(file));
    }

    public FileData(URL url) throws IOException {
        load(getURLName(url), url.openStream());
    }

    public byte[] getData() {
        return data;
    }

    @PortabilityHint(target = "C#", name = "suppress")
    private synchronized void load(String src, InputStream inputStream) throws IOException {
        if (inputStream == null) {
            data = null;
            sourceName = src;
        } else {
            data = new byte[inputStream.available()];
            inputStream.read(data);
            sourceName = src;
        }
    }

    @PortabilityHint(target = "C#", name = "ignore")
    public void save(File file) throws IOException {
        file.getParentFile().mkdirs();
        save(new FileOutputStream(file));
    }

    @PortabilityHint(target = "C#", name = "ignore")
    public void save(OutputStream outputStream) throws IOException {
        outputStream.write(getData());
    }

    @PortabilityHint(target = "C#", name = "ignore")
    public void save(String file) throws IOException {
        (new File(file)).getParentFile().mkdirs();
        save(((OutputStream) (new FileOutputStream(file))));
    }

    @PortabilityHint(target = "C#", name = "suppress")
    public void save(URL url) throws IOException {
        save(url.openConnection().getOutputStream());
    }

    public long size() {
        return data != null ? data.length : -1L;
    }

    public String getSourceName() {
        return sourceName;
    }

    public String getFileType() {
        return sourceName == null ? null : getFileExtension(sourceName);
    }

    private static String getFileExtension(String fileName) {
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

    private String getURLName(URL url) {
        String p = url.getPath();
        int slash = p.lastIndexOf('/');
        if (slash < 0) {
            slash = p.lastIndexOf(':');
        }
        return slash == 0 ? p : p.substring(slash);
    }
}
