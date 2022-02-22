using System.Diagnostics;
using System.Dynamic;

public class QuestEntry
{
    public int entryNum;
    public float entryValFloat;
    public int entryValInt;
    public byte[] entryValByteArray;

    public QuestEntry(int entryNum, float entryValFloat, int entryValInt, byte[] entryValByteArray)
    {
        this.entryNum = entryNum;
        this.entryValFloat = entryValFloat;
        this.entryValInt = entryValInt;
        this.entryValByteArray = entryValByteArray;
    }
}

public class QuestStage
{
    public int index;
    public int flag;
    public int entryNum;
    public List<QuestEntry> entries;
    public QuestStage(int index, int flag, int entryNum, List<QuestEntry> entries)
    {
        this.index = index;
        this.flag = flag;
        this.entryNum = entryNum;
        this.entries = entries;
    }
}

public class RecordQuest {
    public int? flags;
    public int? stageNum;
    public List<QuestStage> stage = new List<QuestStage>();
    public int? dataNum;
    public int? dataUnknown;
    public List<byte[]> data = new List<byte[]>();
    public RecordQuest(Record record, SaveBuffer buf) {
        var startOffset = buf.offset;
        if ((record.flags & 0x4) != 0) {
            this.flags = buf.readByte();
        }
        if ((record.flags & 0x10000000) != 0) {
            this.stageNum = buf.readByte();
            for (var i = 0; i < this.stageNum; ++i) {
                var index = buf.readByte();
                var flag = buf.readByte();
                var entryNum = buf.readByte();
                List<QuestEntry> entries = new List<QuestEntry>();
                for (var j = 0; j < entryNum; ++j) {
                    var entryFlag = buf.readByte();
                    // Read from a clone of buf for the other two since it's the same data represented 3 ways
                    var tmp = buf.clone();
                    var tmp2 = buf.clone();

                    var entryValFloat = buf.readFloat();

                    var entryValInt = tmp.readInt();
                    var entryValByteArray = tmp2.readByteArray(4);

                    entries.Add(new QuestEntry(
                        entryNum: entryFlag,
                        entryValFloat: entryValFloat,
                        entryValInt: entryValInt,
                        entryValByteArray: entryValByteArray
                    ));
                }
                this.stage.Add(new QuestStage(
                    index: index,
                    flag: flag,
                    entryNum: entryNum,
                    entries: entries
                ));
            }
        }
        if ((record.flags & 0x8000000) != 0) {
            this.dataNum = buf.readShort();
            this.dataUnknown = buf.readByte();
            for (var i = 0; i < this.dataNum; ++i) {
                var l = 12;
                if (i + 1 == this.dataNum) {
                    l = (startOffset + record.dataSize) - buf.offset;
                }
                this.data.Add(buf.readByteArray(l));
                if (buf.offset > (startOffset + record.dataSize)) {
                    break;
                }
            }
        }
        if (buf.buffer.Length != buf.offset) {
            Debugger.Break();
        }
    }
}