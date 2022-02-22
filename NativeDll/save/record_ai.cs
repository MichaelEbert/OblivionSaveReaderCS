
using System.Diagnostics;

public class RecordAI {
    public bool neverRun;

    public RecordAI(Record record, SaveBuffer buf) {
        this.neverRun = (record.flags & 0x10000000) == 0x10000000;
        if (buf.buffer.Length != buf.offset) {
            Debugger.Break();
        }
    }
}