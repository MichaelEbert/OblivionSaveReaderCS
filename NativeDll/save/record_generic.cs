using System.Diagnostics;

public class RecordGeneric {
    public int? flags;
    public int? value;
    public RecordGeneric(Record record, SaveBuffer buf) {
        if ((record.flags & 0x1) != 0) {
            this.flags = buf.readInt();
        }
        if ((record.flags & 0x8) != 0) {
            this.value = buf.readInt();
        }
        if (buf.buffer.Length != buf.offset) {
            Debugger.Break();
        }
    }
}