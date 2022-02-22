using System.Collections.Generic;
using System.Diagnostics;

public class RecordCell {
    public bool cellCreated;
    public bool unknown2;
    public byte[]? unknown26;
    public int? time;
    public int? flags;

    byte[] seenUnknown = new byte[0];
    int? dataNum;
    int? dataFlags;
    List<byte[]> data = new List<byte[]>();

    string? fullName;

    int? owner;

    int? pathgridDataLen;
    IEnumerable<short> pathgridData = new short[0];

    public RecordCell(Record record, SaveBuffer buf) {
        var startOffset = buf.offset;
        this.cellCreated = (record.flags & 0x1) == 0x1;
        this.unknown2 = (record.flags & 0x4) == 0x4;

        if ((record.flags & 0x4000000) != 0) {
            this.unknown26 = buf.readByteArray(4);
        }

        if ((record.flags & 0x8000000) != 0) {
            this.time = buf.readInt();
        }

        if ((record.flags & 0x8) != 0) {
            this.flags = buf.readByte();
        }

        if ((record.flags & 0x10000000) != 0) {
            // Due to the format of this not being well understood, this part is complex.
            // Basically just try from the biggest format to smallest, and if the size exceeds the record length,
            // retry with the next smallest
            SaveBuffer? clone = null;
            for (var seenType = 4; seenType >= 0; --seenType) {
                clone = buf.clone();
                if ((record.dataSize - clone.offset) >= 32 && seenType > 0) {
                    this.seenUnknown = clone.readByteArray(32);
                }
                if ((record.dataSize - clone.offset) >= 2 && seenType > 1) {
                    this.dataNum = clone.readShort();
                }
                if ((record.dataSize - clone.offset) >= 2 && seenType > 2) {
                    this.dataFlags = clone.readShort();
                }
                if ((record.dataSize - clone.offset) >= (34*((this.dataNum??0)-1)) && seenType > 3) {
                    for (var i = 0; i < (this.dataNum ?? 0) - 1; ++i) {
                        this.data.Add(clone.readByteArray(34));
                        if (clone.offset > startOffset + record.dataSize) break;
                    }
                }
                if ((record.flags & 0x10) != 0 && (record.dataSize - clone.offset) >= 1 && (record.dataSize - clone.offset) >= 1 + clone.peekByte()) {
                    this.fullName = clone.readbString();
                }
        
                if ((record.flags & 0x20) != 0 && (record.dataSize - clone.offset) >= 4) {
                    this.owner = clone.readInt();
                }
        
                if ((record.flags & 0x1000000) != 0 && (record.dataSize - clone.offset) >= 2 && (record.dataSize - clone.offset) >= 2 + (clone.peekShort() * 2)) {
                    this.pathgridDataLen = clone.readShort();
                    this.pathgridData = clone.readShortArray(this.pathgridDataLen.Value);
                }
                // Now check to make sure we consumed all data, reset if not
                if ((clone.offset - startOffset) != record.dataSize) {
                    if (seenType == 0) {
                        Debugger.Break();
                    }
                    this.dataNum = null;
                    this.dataFlags = null;
                    this.fullName = null;
                    this.owner = null;
                    this.pathgridDataLen = null;
                    this.seenUnknown = new byte[0];
                    this.data.Clear();
                    this.pathgridData = new short[0];
                } else {
                    break;
                }
            }
            if (clone != null) {
                buf.advance(clone.offset - buf.offset);
            }
        } else {
            if ((record.flags & 0x10) != 0) {
                this.fullName = buf.readbString();
            }
    
            if ((record.flags & 0x20) != 0) {
                this.owner = buf.readInt();
            }
    
            if ((record.flags & 0x1000000) != 0) {
                this.pathgridDataLen = buf.readShort();
                for (var i = 0; i < this.pathgridDataLen; ++i) {
                    this.pathgridData = this.pathgridData.Append(buf.readShort());
                }
            }
        }
        if (buf.buffer.Length != buf.offset) {
            Debugger.Break();
        }
    }
}