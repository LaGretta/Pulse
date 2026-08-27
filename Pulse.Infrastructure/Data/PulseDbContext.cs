using Microsoft.EntityFrameworkCore;
using Pulse.Domain.Entities;

namespace Pulse.Infrastructure.Data;

public class PulseDbContext : DbContext
{
    public PulseDbContext(DbContextOptions<PulseDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<ChatRoom> ChatRooms { get; set; }
    public DbSet<ChatRoomMember> ChatRoomMembers { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<MessageReaction> MessageReactions { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<MessageReadReceipt> MessageReadReceipts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(e =>
        {
            e.HasIndex(x => x.Email).IsUnique();
            e.HasIndex(x => x.UserName).IsUnique();
        });

        modelBuilder.Entity<ChatRoomMember>(e =>
        {
            e.HasIndex(x => new { x.ChatRoomId, x.UserId }).IsUnique();

            e.HasOne(x => x.ChatRoom)
                .WithMany(r => r.Members)
                .HasForeignKey(x => x.ChatRoomId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.User)
                .WithMany(u => u.Memberships)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Message>(e =>
        {
            e.HasOne(x => x.ChatRoom)
                .WithMany(r => r.Messages)
                .HasForeignKey(x => x.ChatRoomId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Sender)
                .WithMany(u => u.Messages)
                .HasForeignKey(x => x.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(x => x.ReplyToMessage)
                .WithMany()
                .HasForeignKey(x => x.ReplyToMessageId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MessageReaction>(e =>
        {
            e.HasIndex(x => new { x.MessageId, x.UserId, x.Emoji }).IsUnique();

            e.HasOne(x => x.Message)
                .WithMany(m => m.Reactions)
                .HasForeignKey(x => x.MessageId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Attachment>(e =>
        {
            e.HasOne(x => x.Message)
                .WithMany(m => m.Attachments)
                .HasForeignKey(x => x.MessageId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<MessageReadReceipt>(e =>
        {
            e.HasIndex(x => new { x.MessageId, x.UserId }).IsUnique();

            e.HasOne(x => x.Message)
                .WithMany(m => m.ReadReceipts)
                .HasForeignKey(x => x.MessageId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}