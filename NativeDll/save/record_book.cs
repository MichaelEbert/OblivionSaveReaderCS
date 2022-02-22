using System.Diagnostics;

public class RecordBook {
    public int? flags;
    public int? value;
    public int? teaches;
    public RecordBook(Record record, SaveBuffer buf) {
        if ((record.flags & 0x1) != 0) {
            this.flags = buf.readInt();
        }
        if ((record.flags & 0x8) != 0) {
            this.value = buf.readInt();
        }
        if ((record.flags & 0x4) != 0) {
            this.teaches = buf.readByte();
        }
        if (buf.buffer.Length != buf.offset) {
            Debugger.Break();
        }
    }
}