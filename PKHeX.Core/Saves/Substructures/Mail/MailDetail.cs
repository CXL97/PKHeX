using System;

namespace PKHeX.Core;

public abstract class MailDetail(Memory<byte> Raw, int dataOffset = 0)
{
    protected Span<byte> Data => Raw.Span;
    protected readonly int DataOffset = dataOffset;

    public virtual void CopyTo(SaveFile sav) => sav.SetData(Raw.Span, DataOffset);
    public virtual void CopyTo(PK4 pk4) { }
    public virtual void CopyTo(PK5 pk5) { }
    public virtual string GetMessage(bool isLastLine) => string.Empty;
    public virtual ushort GetMessage(int index1, int index2) => 0;
    public virtual void SetMessage(string line1, string line2, bool userEntered) { }
    public virtual void SetMessage(int index1, int index2, ushort value) { }
    public virtual string AuthorName { get; set; } = string.Empty;
    public virtual ushort AuthorTID { get; set; }
    public virtual ushort AuthorSID { get; set; }
    public virtual byte AuthorVersion { get; set; }
    public virtual byte AuthorLanguage { get; set; }
    public virtual byte AuthorGender { get; set; }
    public virtual ushort AppearPKM { get; set; }
    public virtual int MailType { get; set; }
    public abstract bool? IsEmpty { get; } // true: empty, false: legal mail, null: illegal mail
    public virtual bool UserEntered { get; }
    public virtual void SetBlank() { }
}
