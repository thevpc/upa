package net.vpc.upa.impl.util;

import java.util.*;

public class UPADeadLock {
    static long maxId=Long.MIN_VALUE;
    static Set<VrDeadLockInfo> all=new HashSet<>();
    static Timer timer=new Timer();
    static long maxWait=5*1000;
    static {
        timer.scheduleAtFixedRate(new TimerTask() {
            @Override
            public void run() {
                checkDeadLocks();
            }
        }, 1000L,30000);

    }

    public static class VrDeadLockInfo{
        long id;
        String name;
        String desc;
        Throwable throwable;
        Date startTime;
        long endTime;

        public VrDeadLockInfo(long id,String name,String desc,Throwable throwable, Date startTime,int maxTimeSeconds) {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.throwable = throwable;
            if(maxTimeSeconds<=0){
                maxTimeSeconds=(int)(maxWait/1000);
            }
            this.startTime = startTime;
            this.endTime = startTime.getTime()+maxTimeSeconds*1000;
        }
        public void release(){
            synchronized (UPADeadLock.class) {
                all.remove(this);
            }
        }

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;

            VrDeadLockInfo that = (VrDeadLockInfo) o;

            return id == that.id;
        }

        @Override
        public int hashCode() {
            return (int) (id ^ (id >>> 32));
        }
    }

    public static <T,E extends Throwable> T monitor(String name,String desc,int time,Throwable throwable, TAction<T,E> a) throws E{
        VrDeadLockInfo t = addMonitor(name,desc,time,throwable);
        T v=null;
        try {
            v = a.run();
        }finally {
            t.release();
        }
        return v;
    }

    public static VrDeadLockInfo addMonitor(String name,String desc,int time, Throwable throwable){
        synchronized (UPADeadLock.class){
            VrDeadLockInfo e = new VrDeadLockInfo(maxId++, name,desc,throwable, new Date(),time);
            all.add(e);
            return e;
        }
    }

    public static void checkDeadLocks() {
        synchronized (UPADeadLock.class) {
            for (VrDeadLockInfo vrDeadLockInfo : all) {
                long l = System.currentTimeMillis() - vrDeadLockInfo.startTime.getTime();
                if(l>maxWait){
                    System.err.println("Lock detected ["+vrDeadLockInfo.id+"] ["+vrDeadLockInfo.name+"] :");
                    System.err.println("\t"+vrDeadLockInfo.desc);
                    vrDeadLockInfo.throwable.printStackTrace();
                }
            }
        }
    }
    public interface TAction<T,E extends Throwable>{
        T run() throws E;
    }
}
