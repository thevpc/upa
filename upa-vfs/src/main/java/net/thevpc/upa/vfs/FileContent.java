/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.vfs;

import net.thevpc.upa.config.*;
import net.thevpc.upa.config.*;

/**
 *
 * @author taha.bensalah@gmail.com
 */
@Entity
@Path("FileSystem")
public class FileContent {

    @Id
    @Main
    public Integer id;
    public byte[] content;
    @Summary
    public long length;
    @Summary
    public long lastModified;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public byte[] getContent() {
        return content;
    }

    public void setContent(byte[] content) {
        this.content = content;
    }

    public long getLength() {
        return length;
    }

    public void setLength(long length) {
        this.length = length;
    }

    public long getLastModified() {
        return lastModified;
    }

    public void setLastModified(long lastModified) {
        this.lastModified = lastModified;
    }

}
