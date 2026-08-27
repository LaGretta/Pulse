namespace Pulse.Domain.Entities;

public class ChatRoom
{
       public int Id { get; set; }
       public string Name { get; set; } = string.Empty;
       public bool IsPrivate { get; set; }
       
       public DateTime CreatedAt { get; set; }

       public List<Message> Messages { get; set; } = new();
       public List<ChatRoomMember> Members { get; set; } = new();
}