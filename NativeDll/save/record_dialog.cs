
using System.Diagnostics;

public class RecordDialog {
    public bool topicSaidOnce;

    public RecordDialog(Record record, SaveBuffer buf) {
        this.topicSaidOnce = (record.flags & 0x10000000) == 0x10000000;
        if (buf.buffer.Length != buf.offset) {
            Debugger.Break();
        }
    }
}