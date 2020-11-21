package net.thevpc.upa.impl.bulk;

import net.thevpc.upa.PortabilityHint;

/**
 * @author taha.bensalah@gmail.com on 7/6/16.
 */
@PortabilityHint(target = "C#",name = "suppress")
class SyncStat {

    long validMerges;
    long validPersists;
    long erronousPersists;
    long erronousMerges;

    public void add(SyncStat o) {
        validMerges += o.validMerges;
        validPersists += o.validPersists;
        erronousPersists += o.erronousPersists;
        erronousMerges += o.erronousMerges;
    }

    public String debugString() {
        StringBuilder sb = new StringBuilder();
        sb.append("persists : " + (validPersists + erronousPersists) + "=" + validPersists + "ok + " + erronousPersists + "ko");
        sb.append(" ;; ");
        sb.append("merges   : " + (validMerges + erronousMerges) + "=" + validMerges + "ok + " + erronousMerges + "ko");
        return sb.toString();
    }

}
