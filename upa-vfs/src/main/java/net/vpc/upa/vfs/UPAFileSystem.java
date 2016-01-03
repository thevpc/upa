/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.vfs;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.types.DateTime;
import net.vpc.common.vfs.VFSSecurityManager;
import net.vpc.common.vfs.VFile;
import net.vpc.common.vfs.VFileFilter;
import net.vpc.common.vfs.VFileType;
import net.vpc.common.vfs.impl.AbstractVirtualFileSystem;
import net.vpc.common.vfs.impl.DefaultFile;
import net.vpc.common.vfs.impl.DefaultVFSSecurityManager;
import net.vpc.common.vfs.impl.DefaultVirtualFileACL;
import net.vpc.common.vfs.VirtualFileACL;

/**
 *
 * @author vpc
 */
public class UPAFileSystem extends AbstractVirtualFileSystem {

    private DefaultFile ROOT = new DefaultFile("/", this);
    private final PersistenceUnit persistenceUnit;

    public UPAFileSystem(String id) {
        this(id, null);
    }

    public UPAFileSystem(String id, PersistenceUnit persistenceUnit) {
        super(id);
        this.persistenceUnit = persistenceUnit;
    }

    @Override
    public VFile getBase(String path, String vfsId) {
        if (vfsId == null || vfsId.length() == 0 || vfsId.equalsIgnoreCase(getId())) {
            return get(path);
        }
        return null;
    }

    public PersistenceUnit getPersistenceUnit() throws UPAException {
        return persistenceUnit != null ? persistenceUnit : UPA.getPersistenceUnit();
    }

    protected FileEntry getDirEntry(VFile path) {
        return getDirEntry(path.getPath());
    }

    protected FileEntry getDirEntry(String path) {
        PersistenceUnit pu = getPersistenceUnit();
        FileEntry entity = pu.createQueryBuilder(FileEntry.class).addAndField("path", path).getEntity();
        if (entity == null) {
            if (path.equals("/")) {
                entity = new FileEntry();
                entity.setLastModifed(new DateTime());
                entity.setName("/");
                entity.setPath("/");
                entity.setType(VFileType.DIRECTORY);
                pu.persist(entity);
            }
        }
        return entity;
    }

    @Override
    public boolean exists(String path) {
        return getDirEntry(path) != null;
    }

    @Override
    public long lastModified(String path) {
        FileEntry dirEntry = getDirEntry(path);
        return dirEntry == null ? 0 : dirEntry.getLastModifed().getTime();
    }

    @Override
    public long length(String path) {
        FileEntry dirEntry = getDirEntry(path);
        return dirEntry == null ? 0 : dirEntry.getLength();
    }

    @Override
    public boolean isFile(String file) {
        FileEntry dirEntry = getDirEntry(file);
        return dirEntry != null && dirEntry.getType() == VFileType.FILE;
    }

    @Override
    public VFileType getFileType(String path) {
        FileEntry dirEntry = getDirEntry(path);
        return dirEntry != null ? null : dirEntry.getType();
    }

    @Override
    public VFSSecurityManager getSecurityManager() {
        return DefaultVFSSecurityManager.INSTANCE;
    }

    @Override
    public boolean isDirectory(String file) {
        FileEntry dirEntry = getDirEntry(file);
        return dirEntry != null && dirEntry.getType() == VFileType.DIRECTORY;
    }

    @Override
    public InputStream getInputStream(String path) throws IOException {
        FileEntry dirEntry = getDirEntry(path);
        if (dirEntry != null) {
            Integer c = dirEntry.getContentId();
            if (c != null) {
                FileContent fc = (FileContent) getPersistenceUnit().findById(FileContent.class, c);
                if (fc != null && fc.getContent() != null) {
                    return new ByteArrayInputStream(fc.getContent());
                }
            }
        }
        return null;
    }

    @Override
    public OutputStream getOutputStream(String path) throws IOException {
        VFile f = get(path);
        VFile p = f.getParentFile();
        if (!p.exists()) {
            throw new IOException("Parent does not exists");
        }
        FileEntry dirEntry = getDirEntry(path);
        if (dirEntry == null) {
            dirEntry = new FileEntry();
            dirEntry.setName(p.getName());
            dirEntry.setPath(p.getPath());
            dirEntry.setParentPath(p.getParentPath());
            dirEntry.setParent(getDirEntry(p.getParentFile()));
            dirEntry.setType(VFileType.FILE);
            getPersistenceUnit().persist(dirEntry);
        }
        Integer cid = dirEntry.getContentId();
        FileContent c = null;
        if (cid == null) {
            c = new FileContent();
            c.setLastModified(new DateTime().getTime());
            c.setLength(0);
            getPersistenceUnit().persist(c);
            dirEntry.setContentId(c.getId());
        } else {
            c = (FileContent) getPersistenceUnit().findById(FileContent.class, cid);
            if (c == null) {
                c = new FileContent();
                c.setLastModified(new DateTime().getTime());
                c.setLength(0);
                getPersistenceUnit().persist(c);
                dirEntry.setContentId(c.getId());
            }
        }
        getPersistenceUnit().merge(dirEntry);
        final FileContent fc = c;
        final FileEntry fe = dirEntry;
        return new ByteArrayOutputStream() {

            @Override
            public void close() throws IOException {
                super.close();
                byte[] ba = this.toByteArray();
                fc.setContent(ba);
                fc.setLength(ba.length);
                fc.setLastModified(System.currentTimeMillis());
                fe.setLastModifed(new DateTime(fc.getLastModified()));
                fe.setLength(fc.getLength());
                getPersistenceUnit().merge(fc);
                getPersistenceUnit().merge(fe);
            }

        };
    }

    @Override
    public OutputStream getOutputStream(String path, boolean append) throws IOException {
        if (!append) {
            return getOutputStream(path);
        } else {
            throw new IllegalArgumentException("Unsupported");
        }
    }

    @Override
    public boolean mkdir(String path) {
        VFile f = get(path);
        if (f.exists()) {
            return false;
        }
        VFile p = f.getParentFile();
        if (!p.exists()) {
            return false;
        }
        FileEntry pdir = getDirEntry(p);
        FileEntry me = new FileEntry();
        me.setLastModifed(new DateTime());
        me.setName(f.getName());
        me.setParent(pdir);
        me.setParentPath(pdir.getPath());
        me.setPath(f.getPath());
        me.setType(VFileType.DIRECTORY);
        getPersistenceUnit().persist(me);
        return true;
    }

    @Override
    public boolean mkdirs(String path) {
        VFile f = get(path);
        if (f.exists()) {
            return false;
        }
        String p = f.getParentPath();
        if (mkdirs(p)) {
            FileEntry pdir = getDirEntry(p);
            FileEntry me = new FileEntry();
            me.setLastModifed(new DateTime());
            me.setName(f.getName());
            me.setParent(pdir);
            me.setParentPath(pdir.getPath());
            me.setPath(f.getPath());
            me.setType(VFileType.DIRECTORY);
            getPersistenceUnit().persist(me);
            return true;
        }
        return false;
    }

    @Override
    public VFile[] listFiles(String path, VFileFilter fileFilter) {
        FileEntry d = getDirEntry(path);
        if (d == null || d.getType() != VFileType.DIRECTORY) {
            return new VFile[0];
        }
        List<FileEntry> childen = getPersistenceUnit().createQueryBuilder(FileEntry.class)
                .addAndField(
                        "parentPath", path
                ).getEntityList();
        List<VFile> ret = new ArrayList<>();
        for (FileEntry c : childen) {
            DefaultFile ff = new DefaultFile(c.getPath(), this);
            if (fileFilter == null || fileFilter.accept(ff)) {
                ret.add(ff);
            }
        }
        return ret.toArray(new VFile[ret.size()]);
    }

    @Override
    public VFile[] getRoots() {
        return new VFile[]{ROOT};
    }

    @Override
    public void delete(String path) throws IOException {
        final FileEntry e = getDirEntry(path);
        if (e != null) {
            getPersistenceUnit().remove(e);
        }
    }

    @Override
    public VirtualFileACL getACL(String path) {
        return DefaultVirtualFileACL.READ_WRITE;
    }

}
