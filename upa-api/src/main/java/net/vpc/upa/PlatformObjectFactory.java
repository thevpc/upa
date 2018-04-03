package net.vpc.upa;

public interface PlatformObjectFactory {
    <T> T createObject(Class<T> type, String name);
}
