using System.Diagnostics;

public class FactionInfo
{
    public int faction;
    public int factionRank;

    public FactionInfo(int faction, int factionRank)
    {
        this.faction = faction;
        this.factionRank = factionRank;
    }

    public FactionInfo(int[] info)
    {
        this.faction = info[0];
        this.factionRank = info[1];
    }
}

public class RecordCreature {
    public int? flags;

    public int? strength;
    public int? intelligence;
    public int? willpower;
    public int? agility;
    public int? speed;
    public int? endurance;
    public int? personality;
    public int? luck;

    public int? dataFlags;
    public int? baseMagicka;
    public int? baseFatigue;
    public int? barterGold;
    public int? level;
    public int? calcMin;
    public int? calcMax;

    public int? factionsNum;
    public List<FactionInfo> factions = new List<FactionInfo>();

    public int? spellCount;
    public List<int> spellIds = new List<int>();

    public List<int> aiData = new List<int>();

    public int? baseHealth;

    public int? modCount;
    public List<Tuple<int, float>> modifiers = new List<Tuple<int, float>>();
    //    int valueIndex;
    //    int modValue;

    public string? fullName;

    public int? armorer;
    public int? athletics;
    public int? blade;
    public int? block;
    public int? blunt;
    public int? handToHand;
    public int? heavyArmor;
    public int? alchemy;
    public int? alteration;
    public int? conjuration;
    public int? destruction;
    public int? illusion;
    public int? mysticism;
    public int? restoration;
    public int? acrobatics;
    public int? lightArmor;
    public int? marksman;
    public int? mercantile;
    public int? security;
    public int? sneak;
    public int? speechcraft;

    public int? combatStyle;

    public RecordCreature(Record record, SaveBuffer buf) {
        if ((record.flags & 0x1) != 0) {
            this.flags = buf.readInt();
        }

        if ((record.flags & 0x8) != 0) {
            this.strength = buf.readByte();
            this.intelligence = buf.readByte();
            this.willpower = buf.readByte();
            this.agility = buf.readByte();
            this.speed = buf.readByte();
            this.endurance = buf.readByte();
            this.personality = buf.readByte();
            this.luck = buf.readByte();
        }

        if ((record.flags & 0x10) != 0) {
            this.dataFlags = buf.readInt();
            this.baseMagicka = buf.readShort();
            this.baseFatigue = buf.readShort();
            this.barterGold = buf.readShort();
            this.level = buf.readShort();
            this.calcMin = buf.readShort();
            this.calcMax = buf.readShort();
        }

        if ((record.flags & 0x40) != 0) {
            this.factionsNum = buf.readShort();
            for (var i = 0; i < this.factionsNum; ++i) {
                var faction = buf.readInt();
                var factionRank = buf.readByte();
                this.factions.Add(new FactionInfo(
                    faction,
                    factionRank
                ));
            }
        }

        if ((record.flags & 0x20) != 0) {
            this.spellCount = buf.readShort();
            for (var i = 0; i < this.spellCount; ++i) {
                this.spellIds.Add(buf.readInt());
            }
        }

        if ((record.flags & 0x100) != 0) {
            this.aiData.Add(buf.readByte());
            this.aiData.Add(buf.readByte());
            this.aiData.Add(buf.readByte());
            this.aiData.Add(buf.readByte());
        }

        if ((record.flags & 0x4) != 0) {
            this.baseHealth = buf.readInt();
        }

        if ((record.flags & 0x10000000) != 0) {
            this.modCount = buf.readShort();
            for (var i = 0; i < this.modCount; ++i) {
                var index = buf.readByte();
                var mod = buf.readFloat();
                this.modifiers.Add(new Tuple<int,float>(
                    index,
                    mod
                ));
            }
        }

        if ((record.flags & 0x80) != 0) {
            this.fullName = buf.readbString();
        }

        if ((record.flags & 0x200) != 0) {
            this.armorer = buf.readByte();
            this.athletics = buf.readByte();
            this.blade = buf.readByte();
            this.block = buf.readByte();
            this.blunt = buf.readByte();
            this.handToHand = buf.readByte();
            this.heavyArmor = buf.readByte();
            this.alchemy = buf.readByte();
            this.alteration = buf.readByte();
            this.conjuration = buf.readByte();
            this.destruction = buf.readByte();
            this.illusion = buf.readByte();
            this.mysticism = buf.readByte();
            this.restoration = buf.readByte();
            this.acrobatics = buf.readByte();
            this.lightArmor = buf.readByte();
            this.marksman = buf.readByte();
            this.mercantile = buf.readByte();
            this.security = buf.readByte();
            this.sneak = buf.readByte();
            this.speechcraft = buf.readByte();
        }

        if ((record.flags & 0x400) != 0) {
            this.combatStyle = buf.readInt();
        }
        if (buf.buffer.Length != buf.offset) {
            Debugger.Break();
        }
    }
}