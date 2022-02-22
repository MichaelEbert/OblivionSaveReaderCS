using System.Diagnostics;

struct Reaction {
    int unknown1;
    int unknown2;

    public Reaction(int unknown1, int unknown2)
    {
        this.unknown1 = unknown1;
        this.unknown2 = unknown2;
    }
}
public class RecordFaction {
    int? reactionsNum;
    List<Reaction> reactions = new List<Reaction>();
    int? flags;
    public RecordFaction(Record record, SaveBuffer buf) {
        if ((record.flags & 0x8) != 0) {
            this.reactionsNum = buf.readShort();
            for (var i = 0; i < this.reactionsNum; ++i) {
                var u1 = buf.readInt();
                var u2 = buf.readInt();
                this.reactions.Add(new Reaction(
                    u1,
                    u2
                ));
            }
        }
        if ((record.flags & 0x4) != 0) {
            this.flags = buf.readByte();
        }
        if (buf.buffer.Length != buf.offset) {
            Debugger.Break();
        }
    }
}