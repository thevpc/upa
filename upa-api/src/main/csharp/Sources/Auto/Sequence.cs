/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public sealed class Sequence : Net.TheVpc.Upa.Formula {

        private Net.TheVpc.Upa.SequenceStrategy strategy = Net.TheVpc.Upa.SequenceStrategy.AUTO;

        private int initialValue = 1;

        private int allocationSize = 50;

        private string format;

        private string group;

        private string name;

        public Sequence()  : this(Net.TheVpc.Upa.SequenceStrategy.AUTO){

        }

        public Sequence(Net.TheVpc.Upa.SequenceStrategy strategy)  : this(strategy, 1, 50, null, null, null){

        }

        public Sequence(Net.TheVpc.Upa.SequenceStrategy strategy, int initialValue, int allocationSize)  : this(strategy, initialValue, allocationSize, null, null, null){

        }

        public Sequence(Net.TheVpc.Upa.SequenceStrategy strategy, int seed, int allocationSize, string name, string group, string format) {
            this.strategy = strategy;
            this.initialValue = seed;
            this.allocationSize = allocationSize;
            this.format = format;
            this.group = group;
            this.name = name;
        }

        public Net.TheVpc.Upa.SequenceStrategy GetStrategy() {
            return strategy;
        }

        public string GetFormat() {
            return format;
        }

        public void SetFormat(string format) {
            this.format = format;
        }

        public string GetGroup() {
            return group;
        }

        public void SetGroup(string group) {
            this.group = group;
        }

        public string GetName() {
            return name;
        }

        public void SetName(string name) {
            this.name = name;
        }

        public int GetInitialValue() {
            return initialValue;
        }

        public void SetInitialValue(int seed) {
            this.initialValue = seed;
        }

        public int GetAllocationSize() {
            return allocationSize;
        }

        public void SetAllocationSize(int increment) {
            this.allocationSize = increment;
        }
    }
}
